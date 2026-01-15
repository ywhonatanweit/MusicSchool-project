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
        [HttpGet]
        [ActionName("ArtistSelector")]
        public ArtistList SelectAllCities()
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





        //[HttpPost]
        //public int InsertAArtist(Artist a)
        //{
        //    ArtistDB db = new ArtistDB();
        //    db.Insert(a);
        //    int x = art.SaveChanges();
        //    return x;
        //}

        //[HttpPost]
        //public int InsertAChord(chord c)
        //{
        //    ChordDB db = new ChordDB();
        //    db.Insert(c);
        //    int x = ChordDB.SaveChanges();
        //    return x;
        //}

        //[HttpPost]
        //public int InsertADifficulty(difficulty d)
        //{
        //    DifficultyDB db = new DifficultyDB();
        //    db.Insert(d);
        //    int x = DifficultyDB.SaveChanges();
        //    return x;
        //}

        //[HttpPost]
        //public int InsertAGenre(genre g)
        //{
        //    GenreDB db = new GenreDB();
        //    db.Insert(g);
        //    int x = GenreDB.SaveChanges();
        //    return x;
        //}

        //[HttpPost]
        //public int InsertALanguage(language l)
        //{
        //    LanguageDB db = new LanguageDB();
        //    db.Insert(l);
        //    int x = LanguageDB.SaveChanges();
        //    return x;
        //}

        //[HttpPost]
        //public int InsertALyrics(lyrics l)
        //{
        //    LyricsDB db = new LyricsDB();
        //    db.Insert(l);
        //    int x = LyricsDB.SaveChanges();
        //    return x;
        //}

        //[HttpPost]
        //public int InsertAPerson(person p)
        //{
        //    PersonDB db = new PersonDB();
        //    db.Insert(p);
        //    int x = PersonDB.SaveChanges();
        //    return x;
        //}

        //[HttpPost]
        //public int InsertASong(song s)
        //{
        //    SongDB db = new SongDB();
        //    db.Insert(s);
        //    int x = SongDB.SaveChanges();
        //    return x;
        //}

        //[HttpPost]
        

        
        //public int UpdateAArtist([FromBody] Artist a)
        //{
        //    ArtistDB db = new ArtistDB();
        //    db.Update(a);
        //}

        //[HttpPut]
        //public int UpdateAChord([FromBody] Chord c)
        //{
        //    ChordDB db = new ChordDB();
        //    db.Update(c);
        //}

        //[HttpPut]
        //public int UpdateADifficulty([FromBody] Difficulty d)
        //{
        //    DifficultyDB db = new DifficultyDB();
        //    db.Update(d);
        //}

        //[HttpPut]
        //public int UpdateAGenre([FromBody] Genre g)
        //{
        //    GenreDB db = new GenreDB();
        //    db.Update(g);
        //}

        //[HttpPut]
        //public int UpdateALanguage([FromBody] Language l)
        //{
        //    LanguageDB db = new LanguageDB();
        //    db.Update(l);
        //}

        //[HttpPut]
        //public int UpdateALyrics([FromBody] Lyrics l)
        //{
        //    LyricsDB db = new LyricsDB();
        //    db.Update(l);
        //}

        //[HttpPut]
        //public int UpdateAPerson([FromBody] Person p)
        //{
        //    PersonDB db = new PersonDB();
        //    db.Update(p);
        //}

        //[HttpPut]
        //public int UpdateASong([FromBody] Song s)
        //{
        //    SongDB db = new SongDB();
        //    db.Update(s);
        //}

        //[HttpPut]
        //public int UpdateAStudent([FromBody] Student s)
        //{
        //    StudentDB db = new StudentDB();
        //    db.Update(s);
        //}

    }
}
