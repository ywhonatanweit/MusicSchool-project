using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
            command.CommandText = $"SELECT PersonTbl.Id, PersonTbl.Pname, PersonTbl.Pcode " +
                  $"FROM(PersonTbl INNER JOIN" +
                         $" ArtistTbl ON PersonTbl.Id = ArtistTbl.ID)";

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

      //  שלב ב
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Artist c = entity as Artist;
            if (c != null)
            {
                string sqlStr = $"DELETE FROM ArtistTbl where id=@aid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@aid", c.Id));
            }
        }
        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Artist c = entity as Artist;
            if (c != null)
            {
                string sqlStr = $"Insert INTO  ArtistTbl (ID) VALUES (@aid)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@aid", c.Id));
            }
        }
        //לא רושם את הפעולה של העדכון כי אין מה לעדכן, יש רק מפתח ראשי
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
             {
          

             }

        }
    } 
