using Model;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ViewModel
{
    public class ChordDB : BaseDB
    {
        public ChordList SelectAll()
        {
            command.CommandText = $"SELECT * FROM ChordTbl";
            ChordList aList = new ChordList(base.Select());
            return aList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            chord a = entity as chord;
            a.Name = reader["chord"].ToString();
            a.Difficulty =DifficultyDB.SelectById( int.Parse (reader["difficulty"].ToString())  );


            base.CreateModel(entity);
            return a;
        }
        public override BaseEntity NewEntity()
        {
            return new chord();
        }
        static private ChordList list = new ChordList();
        public static chord SelectById(int id)
        {
            ChordDB db = new ChordDB();
            list = db.SelectAll();

            chord g = list.Find(item => item.Id == id );
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            chord x = entity as chord;
            if (x != null)
            {
                string sqlStr = $"DELETE FROM ChordTbl where id=@pid";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pid", x.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            chord p = entity as chord;
            if (p != null)
            {
                string sqlStr = $"Insert INTO ChordTbl (Id,chord,difficulty) " +
                                "VALUES (@id,@chord,@diff)";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@id", p.Id));
                command.Parameters.Add(new OleDbParameter("@chord", p.Name));
                command.Parameters.Add(new OleDbParameter("@difficulty", p.Difficulty.Id));


            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            chord c = entity as chord;
            if (c != null)
            {
                string sqlStr = $"UPDATE ChordTbl  SET difficulty=@cName, chord=@chname WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cName", c.Difficulty.Id));
              
                command.Parameters.Add(new OleDbParameter("@chName", c.Name));
                command.Parameters.Add(new OleDbParameter("@id", c.Id));

            }

        }
            //שלב ב
            //protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
            //{
            //    Person c = entity as Person;
            //    if (c != null)
            //    {
            //        string sqlStr = $"DELETE FROM PersonTbl where id=@pid";

            //        command.CommandText = sqlStr;
            //        command.Parameters.Add(new OleDbParameter("@pid", c.Id));
            //    }
            //}
            //protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
            //{
            //    Person c = entity as Person;
            //    if (c != null)
            //    {
            //        string sqlStr = $"Insert INTO  PersonTbl (PersonName) VALUES (@cName)";

            //        command.CommandText = sqlStr;
            //        command.Parameters.Add(new OleDbParameter("@cName", c.PersonName));
            //    }
            //}

            //protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
            //{
            //    Person c = entity as Person;
            //    if (c != null)
            //    {
            //        string sqlStr = $"UPDATE PersonTbl  SET PersonName=@cName WHERE ID=@id";

            //        command.CommandText = sqlStr;
            //        command.Parameters.Add(new OleDbParameter("@cName", c.PersonName));
            //        command.Parameters.Add(new OleDbParameter("@id", c.Id));
            //    }
            //}
        }
    }