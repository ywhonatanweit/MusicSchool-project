using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using static ViewModel.BaseDB;


namespace ViewModel
{
    public class GenreDB :BaseDB
    {
        public GenreList SelectAll()
        {
            command.CommandText = $"SELECT * FROM GenreTbl";
            GenreList aList = new GenreList(base.Select());
            return aList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            genre a = entity as genre;
            a.Genrename = reader["genre"].ToString();
            base.CreateModel(entity);
            return a;
        }
        public override BaseEntity NewEntity()
        {
            return new genre();
        }
        static private GenreList list = new GenreList();
        public static genre SelectById(int id)
        {
            GenreDB db = new GenreDB();
            list = db.SelectAll();

            genre  g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            genre x = entity as genre;
            if (x != null)
            {
                string sqlStr = $"DELETE FROM GenreTbl where id=@pid";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pid", x.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            genre c = entity as genre;
            if (c != null)
            {
                string sqlStr = $"Insert INTO genreTbl (genre) VALUES (@genre)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@genre", c.Genrename));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            genre c = entity as genre;
            if (c != null)
            {
                string sqlStr = $"UPDATE genreTbl  SET genre=@gName WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@gName", c.Genrename));
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
    
