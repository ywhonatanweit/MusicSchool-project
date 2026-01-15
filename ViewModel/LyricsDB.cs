using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using static ViewModel.BaseDB;

namespace ViewModel
{
    public class LyricsDB : BaseDB
    {
        public LyricsList SelectAll()
        {
            command.CommandText = $"SELECT * FROM  LyricsTbl";
            LyricsList aList = new LyricsList(base.Select());
            return aList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            lyrics a = entity as lyrics;
            a.Songid = SongDB.SelectById(int.Parse(reader["songid"].ToString()));
            a.Chordid = ChordDB.SelectById(int.Parse(reader["chordid"].ToString()));
            a.Placment = int.Parse( reader["placment"].ToString());
            a.Lyricsname = reader["lyrics"].ToString();



            base.CreateModel(entity);
            return a;
        }
        public override BaseEntity NewEntity()
        {
            return new lyrics();
        }
        static private LyricsList list = new LyricsList();
        public static lyrics SelectById(int id)
        {
            LyricsDB db = new LyricsDB();
            list = db.SelectAll();

            lyrics g = list.Find(item => item.Id == id);
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
            lyrics p = entity as lyrics;
            if (p != null)
            {
                string sqlStr = $"Insert INTO LyricsTbl (id,songid,placment,chordid,lyrics) " +
                                "VALUES (@id,@sid,@pl,@chid,@lyrics)";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@id", p.Id));
                command.Parameters.Add(new OleDbParameter("@sid", p.Songid.Id));
                command.Parameters.Add(new OleDbParameter("@pl", p.Placment));
                command.Parameters.Add(new OleDbParameter("@chid", p.Chordid.Id));
                command.Parameters.Add(new OleDbParameter("@lyrics", p.Lyricsname));

            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            lyrics c = entity as lyrics;
            if (c != null)
            {
                string sqlStr = $"UPDATE  LyricsTbl  SET [lyrics]=@cName,songid=@sid,placment=@pl,chordid=@chid WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cName", c.Lyricsname)); 
                command.Parameters.Add(new OleDbParameter("@sid", c.Songid.Id));
                command.Parameters.Add(new OleDbParameter("@pl", c.Placment));
                command.Parameters.Add(new OleDbParameter("@chid", c.Chordid.Id));
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
            //    lyrics c = entity as lyrics;
            //    if (c != null)
            //    {
            //        string sqlStr = $"UPDATE  LyricsTbl  SET PersonName=@cName WHERE ID=@id";

            //        command.CommandText = sqlStr;
            //        command.Parameters.Add(new OleDbParameter("@cName", c.PersonName));
            //        command.Parameters.Add(new OleDbParameter("@id", c.Id));
            //    }
            //}
        }
    }
