using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ViewModel.BaseDB;
using System.IO;

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

            base.CreateModel(entity);

            a.Name = reader["songname"].ToString();

            a.Artistid = ArtistDB.SelectById(int.Parse(reader["artistid"].ToString()));
            a.Gaenreid = GenreDB.SelectById(int.Parse(reader["ganreid"].ToString()));
            a.Difficultyid = DifficultyDB.SelectById(int.Parse(reader["difficultyid"].ToString()));
            a.Languageid = LanguageDB.SelectById(int.Parse(reader["languageid"].ToString()));

            a.SongPic = reader["songPic"] == DBNull.Value ? "" : reader["songPic"].ToString();
            a.Songpath = reader["songPath"] == DBNull.Value ? "" : reader["songPath"].ToString();

            return a;
        }

        /// <summary>
        /// return null when song not found
        /// 
        /// </summary>
        /// <param/* name="id"*/></param>
        /// <returns></returns>
        public string SelectSongPicBySongId(int id)
        {
            SongList sList = SelectAll();
            song song = sList.Find(x => x.Id == id);

            if (song == null)
            {
                return null;
            }
            string pic = song.SongPic;
            return pic;
        }

        public override BaseEntity NewEntity()
        {
            return new song();
        }
        static private SongList list = new SongList();
        public static song SelectById(int id)
        {
            SongDB db = new SongDB();

            db.command.Parameters.Clear();
            db.command.CommandText = "SELECT * FROM SongTbl WHERE ID=@id";
            db.command.Parameters.Add(new OleDbParameter("@id", id));

            SongList result = new SongList(db.Select());

            return result.FirstOrDefault();
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            song x = entity as song;
            if (x != null)
            {
                string sqlStr = $"DELETE FROM SongTbl where id=@pid";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pid", x.Id));

            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            song p = entity as song;

            if (p != null)
            {
                string sqlStr =
                    "INSERT INTO SongTbl (songname, artistid, ganreid, difficultyid, languageid, songPic, songPath) " +
                    "VALUES (@sname, @aid, @gid, @did, @lid, @sp, @spa)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@sname", p.Name ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@aid", p.Artistid.Id));
                cmd.Parameters.Add(new OleDbParameter("@gid", p.Gaenreid.Id));
                cmd.Parameters.Add(new OleDbParameter("@did", p.Difficultyid.Id));
                cmd.Parameters.Add(new OleDbParameter("@lid", p.Languageid.Id));
                cmd.Parameters.Add(new OleDbParameter("@sp", p.SongPic ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@spa", p.Songpath ?? ""));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            song c = entity as song;

            if (c != null)
            {
                string sqlStr =
                    "UPDATE SongTbl " +
                    "SET songname=@sName, artistid=@aid, ganreid=@gid, difficultyid=@did, languageid=@lid, songPic=@sp, songPath=@spa " +
                    "WHERE ID=@id";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@sName", c.Name ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@aid", c.Artistid.Id));
                cmd.Parameters.Add(new OleDbParameter("@gid", c.Gaenreid.Id));
                cmd.Parameters.Add(new OleDbParameter("@did", c.Difficultyid.Id));
                cmd.Parameters.Add(new OleDbParameter("@lid", c.Languageid.Id));
                cmd.Parameters.Add(new OleDbParameter("@sp", c.SongPic ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@spa", c.Songpath ?? ""));
                cmd.Parameters.Add(new OleDbParameter("@id", c.Id));
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
