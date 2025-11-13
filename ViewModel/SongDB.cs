using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading.Tasks;
using static ViewModel.BaseDB;

namespace ViewModel
{
    public class SongDB : BaseDB
    {
        public SongList SelectAll()
        {
            command.CommandText = $"SELECT * FROM  SongTbl";
            SongList aList = new SongList(base.Select());
            return aList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            song a = entity as song;
            a.Name = reader["songname"].ToString();
            a.Artistid =ArtistDB.SelectById( int.Parse(reader["artistid"].ToString())  );
            a.Gaenreid = GenreDB.SelectById(int.Parse(reader["genreid"].ToString()));
            a.Difficultyid = DifficultyDB.SelectById(int.Parse(reader["difficultyid"].ToString()));
            a.Languageid = LanguageDB.SelectById(int.Parse(reader["languageid"].ToString()));


            base.CreateModel(entity);
            return a;
        }
        public override BaseEntity NewEntity()
        {
            return new song();
        }
        static private SongList list = new SongList();
        public static song SelectById(int id)
        {
            SongDB db = new SongDB();
            list = db.SelectAll();

            song g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
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
