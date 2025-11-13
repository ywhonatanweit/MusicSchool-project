using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ArtistDB : PersonDB
    {
        public ArtistList SelectAll()
        {
            command.CommandText = $"SELECT PersonTbl.Id, PersonTbl.Pname, PersonTbl.Pcode" +
                  $"FROM(PersonTbl INNER JOIN" +
                         $"ArtistTbl ON PersonTbl.Id = ArtistTbl.ID)";

            ArtistList aList = new ArtistList(base.Select());
            return aList;

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Artist a = entity as Artist;
            base.CreateModel(entity);
            return a;
        }
        public override BaseEntity NewEntity()
        {
            return new Artist();
        }
        static private ArtistList list = new ArtistList();
        public static Artist SelectById(int id)
        {
            ArtistDB db = new ArtistDB();
            list = db.SelectAll();

            Artist g = list.Find(item => item.Id == id);
            return g;
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