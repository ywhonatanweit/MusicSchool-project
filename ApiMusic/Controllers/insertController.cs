//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Model;
//using System;
//using ViewModel;

//namespace ApiMusicInsert.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class insertController : ControllerBase
//    {
//        [HttpPost]
//        public int InsertAArtist(Artist a)
//        {
//            ArtistDB db = new ArtistDB();
//            db.Insert(a);
//            int x = ArtistDB.SaveChanges();
//            return x;
//        }

//        [HttpPost]
//        public int InsertAChord(chord c)
//        {
//            ChordDB db = new ChordDB();
//            db.Insert(c);
//            int x = ChordDB.SaveChanges();
//            return x;
//        }

//        [HttpPost]
//        public int InsertADifficulty(difficulty d)
//        {
//            DifficultyDB db = new DifficultyDB();
//            db.Insert(d);
//            int x = DifficultyDB.SaveChanges();
//            return x;
//        }

//        [HttpPost]
//        public int InsertAGenre(genre g)
//        {
//            GenreDB db = new GenreDB();
//            db.Insert(g);
//            int x = GenreDB.SaveChanges();
//            return x;
//        }

//        [HttpPost]
//        public int InsertALanguage(language l)
//        {
//            LanguageDB db = new LanguageDB();
//            db.Insert(l);
//            int x = LanguageDB.SaveChanges();
//            return x;
//        }

//        [HttpPost]
//        public int InsertALyrics(lyrics l)
//        {
//            LyricsDB db = new LyricsDB();
//            db.Insert(l);
//            int x = LyricsDB.SaveChanges();
//            return x;
//        }

//        [HttpPost]
//        public int InsertAPerson(person p)
//        {
//            PersonDB db = new PersonDB();
//            db.Insert(p);
//            int x = PersonDB.SaveChanges();
//            return x;
//        }

//        [HttpPost]
//        public int InsertASong(song s)
//        {
//            SongDB db = new SongDB();
//            db.Insert(s);
//            int x = SongDB.SaveChanges();
//            return x;
//        }


//    }
//}

