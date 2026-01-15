//using Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ViewModel.BaseDB;

namespace ViewModel
{
    public class DifficultyDB : BaseDB
    {
        public DifficultyList SelectAll()
        {
            command.CommandText = $"SELECT * FROM DifficultyTbl";
            DifficultyList aList = new DifficultyList(base.Select());
            return aList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            difficulty a = entity as difficulty;
            a.Diff = int.Parse(reader["diff"].ToString());


            base.CreateModel(entity);
            return a;
        }
        public override BaseEntity NewEntity()
        {
            return new difficulty();
        }
        static private DifficultyList list = new DifficultyList();
        public static difficulty SelectById(int id)
        {
            DifficultyDB db = new DifficultyDB();
            list = db.SelectAll();

            difficulty g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            difficulty x = entity as difficulty;
            if (x != null)
            {
                string sqlStr = $"DELETE FROM DifficultyTbl where id=@pid";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pid", x.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            difficulty c = entity as difficulty;
            if (c != null)
            {
                string sqlStr = $"Insert INTO DifficultyTbl (diff) VALUES (@diff)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@diff", c.Diff));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            difficulty c = entity as difficulty;
            if (c != null)
            {
                string sqlStr = $"UPDATE DifficultyTbl  SET diff=@diff WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@diff", c.Diff));
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
        //    difficulty c = entity as difficulty;
        //    if (c != null)
        //    {
        //        string sqlStr = $"UPDATE DifficultyTbl  SET diff=@diff WHERE ID=@id";

        //        command.CommandText = sqlStr;
        //        command.Parameters.Add(new OleDbParameter("@diff", c.Diff));
        //        command.Parameters.Add(new OleDbParameter("@id", c.Id));
        //    }
        //}
    }
}