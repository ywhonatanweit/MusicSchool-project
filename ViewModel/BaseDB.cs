using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class BaseDB
    {
        private static readonly object dbLock = new object();

        private static string GetDbPath()
        {
            string dbFileName = "MusicSchoolDB.accdb";

            string currentDir = Directory.GetCurrentDirectory();
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string[] startFolders =
            {
                currentDir,
                baseDir
            };

            foreach (string startFolder in startFolders)
            {
                DirectoryInfo? dir = new DirectoryInfo(startFolder);

                for (int i = 0; i < 8 && dir != null; i++)
                {
                    string option1 = System.IO.Path.Combine(dir.FullName, "ViewModel", dbFileName);
                    string option2 = System.IO.Path.Combine(dir.FullName, dbFileName);

                    if (File.Exists(option1))
                        return option1;

                    if (File.Exists(option2))
                        return option2;

                    dir = dir.Parent;
                }
            }

            throw new Exception("לא נמצא קובץ מסד הנתונים MusicSchoolDB.accdb");
        }

        protected static string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            GetDbPath() +
            @";Persist Security Info=False;";

        protected OleDbCommand command;
        protected OleDbDataReader? reader;

        public BaseDB()
        {
            command = new OleDbCommand();
        }

        public abstract BaseEntity NewEntity();

        protected List<BaseEntity> Select()
        {
            lock (dbLock)
            {
                List<BaseEntity> list = new List<BaseEntity>();

                using (OleDbConnection localConnection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand localCommand = new OleDbCommand(command.CommandText, localConnection))
                    {
                        foreach (OleDbParameter parameter in command.Parameters)
                        {
                            localCommand.Parameters.Add(
                                new OleDbParameter(parameter.ParameterName, parameter.Value)
                            );
                        }

                        try
                        {
                            localConnection.Open();

                            using (OleDbDataReader localReader = localCommand.ExecuteReader())
                            {
                                reader = localReader;

                                while (reader.Read())
                                {
                                    BaseEntity entity = NewEntity();
                                    list.Add(CreateModel(entity));
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message + "\nSQL:" + command.CommandText);
                        }
                        finally
                        {
                            reader = null;
                        }
                    }
                }

                return list;
            }
        }

        protected async Task<List<BaseEntity>> SelectAsync(string sqlStr)
        {
            List<BaseEntity> list = new List<BaseEntity>();

            using (OleDbConnection localConnection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand localCommand = new OleDbCommand(sqlStr, localConnection))
                {
                    try
                    {
                        localConnection.Open();

                        using (OleDbDataReader localReader =
                               (OleDbDataReader)await localCommand.ExecuteReaderAsync())
                        {
                            reader = localReader;

                            while (reader.Read())
                            {
                                BaseEntity entity = NewEntity();
                                list.Add(CreateModel(entity));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + sqlStr);
                        throw new Exception(e.Message + "\nSQL:" + sqlStr);
                    }
                    finally
                    {
                        reader = null;
                    }
                }
            }

            return list;
        }

        protected virtual BaseEntity CreateModel(BaseEntity entity)
        {
            entity.Id = (int)reader["id"];
            return entity;
        }

        protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd);

        public static List<ChangeEntity> deleted = new List<ChangeEntity>();
        public static List<ChangeEntity> inserted = new List<ChangeEntity>();
        public static List<ChangeEntity> updated = new List<ChangeEntity>();

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();

            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
            }
        }

        public int SaveChanges()
        {
            lock (dbLock)
            {
                OleDbTransaction? trans = null;
                int recordsAffected = 0;

                using (OleDbConnection localConnection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand localCommand = new OleDbCommand())
                    {
                        try
                        {
                            localConnection.Open();

                            trans = localConnection.BeginTransaction();

                            localCommand.Connection = localConnection;
                            localCommand.Transaction = trans;

                            foreach (var entity in inserted)
                            {
                                localCommand.Parameters.Clear();

                                entity.CreateSql(entity.Entity, localCommand);

                                recordsAffected += localCommand.ExecuteNonQuery();

                                localCommand.CommandText = "Select @@Identity";
                                entity.Entity.Id = Convert.ToInt32(localCommand.ExecuteScalar());
                            }

                            foreach (var entity in updated)
                            {
                                localCommand.Parameters.Clear();

                                entity.CreateSql(entity.Entity, localCommand);

                                recordsAffected += localCommand.ExecuteNonQuery();
                            }

                            foreach (var entity in deleted)
                            {
                                localCommand.Parameters.Clear();

                                entity.CreateSql(entity.Entity, localCommand);

                                recordsAffected += localCommand.ExecuteNonQuery();
                            }

                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans?.Rollback();

                            throw new Exception(ex.Message + "\n SQL:" + localCommand.CommandText);
                        }
                        finally
                        {
                            inserted.Clear();
                            updated.Clear();
                            deleted.Clear();
                        }
                    }
                }

                return recordsAffected;
            }
        }

        public class ChangeEntity
        {
            private BaseEntity entity;
            private CreateSql createSql;

            public ChangeEntity(CreateSql createSql, BaseEntity entity)
            {
                this.createSql = createSql;
                this.entity = entity;
            }

            public BaseEntity Entity
            {
                get => entity;
                set => entity = value;
            }

            public CreateSql CreateSql
            {
                get => createSql;
                set => createSql = value;
            }
        }

        public delegate void CreateSql(BaseEntity entity, OleDbCommand command);
    }
}