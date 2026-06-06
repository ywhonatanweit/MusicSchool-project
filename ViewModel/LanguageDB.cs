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
    public class LanguageDB : BaseDB
    {
        public LanguageList SelectAll()
        {
            command.CommandText = $"SELECT * FROM  LanguageTbl";
            LanguageList aList = new LanguageList(base.Select());
            return aList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            language a = entity as language;

            a.Languagename = reader["language"].ToString();

            base.CreateModel(entity);
            return a;
        }
        public override BaseEntity NewEntity()
        {
            return new language();
        }
        static private LanguageList list = new LanguageList();
        public static language SelectById(int id)
        {
            LanguageDB db = new LanguageDB();
            list = db.SelectAll();

            language g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            language x = entity as language;
            if (x != null)
            {
                string sqlStr = $"DELETE FROM LanguageTbl where id=@pid";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pid", x.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            language c = entity as language;
            if (c != null)
            {
                string sqlStr = $"Insert INTO languageTbl ([language]) VALUES (@language)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@language", c.Languagename));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            language c = entity as language;
            if (c != null)
            {
                string sqlStr = $"UPDATE languageTbl  SET [language]=@lan WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@lan", c.Languagename));
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
        //    language c = entity as language;
        //    if (c != null)
        //    {
        //        string sqlStr = $"UPDATE languageTbl  SET language=@lan WHERE ID=@id";

        //        command.CommandText = sqlStr;
        //        command.Parameters.Add(new OleDbParameter("@clan", c.Languagename));
        //        command.Parameters.Add(new OleDbParameter("@id", c.Id));
        //    }
        //}
    }
}
