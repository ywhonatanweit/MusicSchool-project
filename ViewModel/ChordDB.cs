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
        public string SelectChordPicByChordId(int id)
        {
            ChordList cList = SelectAll();
            chord chord = cList.Find(x => x.Id == id);

            string pic = chord.Chordpic;
            return pic;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            chord a = entity as chord;

            a.Name = reader["chord"].ToString();
            int diffValue = int.Parse(reader["difficulty"].ToString());

            a.Difficulty = new difficulty
            {
                Id = diffValue,
                Diff = diffValue
            };
            a.Chordpic = reader["chordpic"] == DBNull.Value ? "" : reader["chordpic"].ToString();
            a.Chordpath = reader["chordPath"] == DBNull.Value ? "" : reader["chordPath"].ToString();

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

            db.command.Parameters.Clear();
            db.command.CommandText = "SELECT * FROM ChordTbl WHERE ID=@id";
            db.command.Parameters.Add(new OleDbParameter("@id", id));

            ChordList result = new ChordList(db.Select());

            return result.FirstOrDefault();
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
                string sqlStr =
                    "INSERT INTO ChordTbl (chord, difficulty, chordpic, chordPath) " +
                    "VALUES (@chord, @difficulty, @chp, @cpa)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@chord", p.Name ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@difficulty", p.Difficulty.Id));
                cmd.Parameters.Add(new OleDbParameter("@chp", p.Chordpic ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@cpa", p.Chordpath ?? ""));
            }
        }


        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            chord c = entity as chord;

            if (c != null)
            {
                string sqlStr =
                    "UPDATE ChordTbl " +
                    "SET chord=@chName, difficulty=@dif, chordpic=@chp, chordPath=@cpa " +
                    "WHERE ID=@id";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@chName", c.Name ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@dif", c.Difficulty.Id));
                cmd.Parameters.Add(new OleDbParameter("@chp", c.Chordpic ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@cpa", c.Chordpath ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
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