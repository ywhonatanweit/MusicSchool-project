using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ViewModel
{
    public class PersonDB : BaseDB
    {
        public PersonList SelectAll()
        {
            command.CommandText = $"SELECT * FROM PersonTbl";
            PersonList pList = new PersonList(base.Select());
            return pList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            person p = entity as person;
            p.Name = reader["Pname"].ToString();
            p.Code = (reader["Pcode"].ToString());
            //p.LivingCity = CityDB.SelectById((int)reader["cityCode"]);
            base.CreateModel(entity);
            return p;
        }
        public override BaseEntity NewEntity()
        {
            return new person();
        }
        static private PersonList list = new PersonList();
        public static person SelectById(int id)
        {
            PersonDB db = new PersonDB();
            list = db.SelectAll();

            person g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            person x = entity as person;
            if (x != null)
            {
                string sqlStr = $"DELETE FROM PersonTbl where id=@pid";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pid", x.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            person c = entity as person;

            if (c != null)
            {
                string sqlStr = "INSERT INTO PersonTbl (Pname, Pcode) VALUES (@Pname, @Pcode)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@Pname", c.Name ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@Pcode", c.Code ?? ""));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {

            person c = entity as person;
            if (c != null)
            {
                string sqlStr = $"UPDATE PersonTbl  SET Pname=@pName, Pcode=@pcode WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pName", c.Name));
                command.Parameters.Add(new OleDbParameter("@pcode", c.Code));
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