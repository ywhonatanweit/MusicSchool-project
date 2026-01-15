using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using ViewModel;

namespace ApiSelect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        #region select
        [HttpGet]
        [ActionName("ArtistSelector")]
        public ArtistList SelectAllArtists()
        {
            ArtistDB db = new ArtistDB();
            ArtistList artists = db.SelectAll();
            return artists;
        }

        [HttpGet]
        [ActionName("ChordSelector")]
        public ChordList SelectAllChords()
        {
            ChordDB db = new ChordDB();
            ChordList chords = db.SelectAll();
            return chords;
        }

        [HttpGet]
        [ActionName("DifficultySelector")]
        public DifficultyList SelectAllDifficulties()
        {
            DifficultyDB db = new DifficultyDB();
            DifficultyList difficulties = db.SelectAll();
            return difficulties;
        }

        [HttpGet]
        [ActionName("GenreSelector")]
        public GenreList SelectAllGenres()
        {
            GenreDB db = new GenreDB();
            GenreList genres = db.SelectAll();
            return genres;
        }

        [HttpGet]
        [ActionName("LanguageSelector")]
        public LanguageList SelectAllLanguages()
        {
            LanguageDB db = new LanguageDB();
            LanguageList languages = db.SelectAll();
            return languages;
        }

        [HttpGet]
        [ActionName("LyricsSelector")]
        public LyricsList SelectAllLyrics()
        {
            LyricsDB db = new LyricsDB();
            LyricsList lyrics = db.SelectAll();
            return lyrics;
        }

        [HttpGet]
        [ActionName("PersonSelector")]
        public PersonList SelectAllPersons()
        {
            PersonDB db = new PersonDB();
            PersonList persons = db.SelectAll();
            return persons;
        }

        [HttpGet]
        [ActionName("SongSelector")]
        public SongList SelectAllSongs()
        {
            SongDB db = new SongDB();
            SongList songs = db.SelectAll();
            return songs;
        }

        #endregion

        #region insert

        [HttpPost]
        public int InsertAArtist(Artist a)
        {
            ArtistDB db = new ArtistDB();
            db.Insert(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        public int InsertAChord(chord a)
        {
            ChordDB db = new ChordDB();
            db.Insert(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        public int InsertADifficulty(difficulty a)
        {
            DifficultyDB db = new DifficultyDB();
            db.Insert(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        public int InsertAGenre(genre a)
        {
            GenreDB db = new GenreDB();
            db.Insert(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        public int InsertALanguage(language a)
        {
            LanguageDB db = new LanguageDB();
            db.Insert(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        public int InsertALyrics(lyrics a)
        {
            LyricsDB db = new LyricsDB();
            db.Insert(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        public int InsertAPerson(person a)
        {
            PersonDB db = new PersonDB();
            db.Insert(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        public int InsertASong(song a)
        {
            SongDB db = new SongDB();
            db.Insert(a);
            int x = db.SaveChanges();
            return x;
        }

        #endregion

        #region update

        [HttpPut]
        public int UpdateAArtist([FromBody] Artist a)
        {
            ArtistDB db = new ArtistDB();
            db.Update(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        public int UpdateAChord([FromBody] chord a)
        {
            ChordDB db = new ChordDB();
            db.Update(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        public int UpdateADifficulty([FromBody] difficulty a)
        {
            DifficultyDB db = new DifficultyDB();
            db.Update(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        public int UpdateAGenre([FromBody] genre a)
        {
            GenreDB db = new GenreDB();
            db.Update(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        public int UpdateALanguage([FromBody] language a)
        {
            LanguageDB db = new LanguageDB();
            db.Update(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        public int UpdateALyrics([FromBody] lyrics a)
        {
            LyricsDB db = new LyricsDB();
            db.Update(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        public int UpdateAPerson([FromBody] person a)
        {
            PersonDB db = new PersonDB();
            db.Update(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        public int UpdateASong([FromBody] song a)
        {
            SongDB db = new SongDB();
            db.Update(a);
            int x = db.SaveChanges();
            return x;
        }


        #endregion

        #region delete

        [HttpDelete]
        public int DeleteArtist(int id)
        {
            ArtistDB db = new ArtistDB();
            Artist a = ArtistDB.SelectById(id);
            db.Delete(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete]
        public int DeleteChord(int id)
        {
            ChordDB db = new ChordDB();
            chord a = ChordDB.SelectById(id);
            db.Delete(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete]
        public int DeleteDifficulty(int id)
        {
            DifficultyDB db = new DifficultyDB();
            difficulty a = DifficultyDB.SelectById(id);
            db.Delete(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete]
        public int DeleteGenre(int id)
        {
            GenreDB db = new GenreDB();
            genre a = GenreDB.SelectById(id);
            db.Delete(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete]
        public int DeleteLanguage(int id)
        {
            LanguageDB db = new LanguageDB();
            language a = LanguageDB.SelectById(id);
            db.Delete(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete]
        public int DeleteLyrics(int id)
        {
            LyricsDB db = new LyricsDB();
            lyrics a = LyricsDB.SelectById(id);
            db.Delete(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete]
        public int DeletePerson(int id)
        {
            PersonDB db = new PersonDB();
            person a = PersonDB.SelectById(id);
            db.Delete(a);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete]
        public int DeleteSong(int id)
        {
            SongDB db = new SongDB();
            song a = SongDB.SelectById(id);
            db.Delete(a);
            int x = db.SaveChanges();
            return x;
        }



        #endregion


    }
}
