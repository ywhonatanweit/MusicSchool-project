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
    public class AdminDB : PersonDB
    {
        public AdminList SelectAll()
        {
            command.CommandText =
                "SELECT PersonTbl.ID, PersonTbl.Pname, PersonTbl.Pcode " +
                "FROM PersonTbl INNER JOIN AdminTbl ON PersonTbl.ID = AdminTbl.ID";

            AdminList aList = new AdminList(base.Select());
            return aList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Admin  a = entity as Admin;
            base.CreateModel(entity);
            return a;
        }
        public override BaseEntity NewEntity()
        {
            return new Admin();
        }
        static private AdminList list = new AdminList();
        public static Admin SelectById(int id)
        {
            AdminDB db = new AdminDB();
            list = db.SelectAll();

            Admin g = list.Find(item => item.Id == id);
            return g;
        }

        //  שלב ב
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Admin c = entity as Admin;

            if (c != null)
            {
                string sqlStr = "DELETE FROM AdminTbl WHERE id=@aid";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@aid", c.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Admin c = entity as Admin;

            if (c != null)
            {
                string sqlStr = "INSERT INTO AdminTbl (ID) VALUES (@aid)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@aid", c.Id));
            }
        }
        //לא רושם את הפעולה של העדכון כי אין מה לעדכן, יש רק מפתח ראשי
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {


        }
    }
}
