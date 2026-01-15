using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;
using ApiMusic;

namespace Service
{
    public interface Interface
    {
        // --- Artist ---
        public Task<ArtistList> SelectAllArtists();
        public Task<int> InsertAArtist(Artist artist);
        public Task<int> UpdateAArtist(Artist artist);
        public Task<int> DeleteAArtist(Artist artist);

        // --- Chord ---
        public Task<ChordList> SelectAllChords();
        public Task<int> InsertAChord(chord chord);
        public Task<int> UpdateAChord(chord chord);
        public Task<int> DeleteAChord(chord chord);

        // --- Difficulty ---
        public Task<DifficultyList> SelectAllDifficulties();
        public Task<int> InsertADifficulty(difficulty difficulty);
        public Task<int> UpdateADifficulty(difficulty difficulty);
        public Task<int> DeleteADifficulty(difficulty difficulty);

        // --- Genre ---
        public Task<GenreList> SelectAllGenres();
        public Task<int> InsertAGenre(genre genre);
        public Task<int> UpdateAGenre(genre genre);
        public Task<int> DeleteAGenre(genre genre);

        // --- Language ---
        public Task<LanguageList> SelectAllLanguages();
        public Task<int> InsertALanguage(language language);
        public Task<int> UpdateALanguage(language language);
        public Task<int> DeleteALanguage(language language);

        // --- Lyrics ---
        public Task<LyricsList> SelectAllLyrics();
        public Task<int> InsertALyrics(lyrics lyrics);
        public Task<int> UpdateALyrics(lyrics lyrics);
        public Task<int> DeleteALyrics(lyrics lyrics);

        // --- Person ---
        public Task<PersonList> SelectAllPersons();
        public Task<int> InsertAPerson(person person);
        public Task<int> UpdateAPerson(person person);
        public Task<int> DeleteAPerson(person person);

        // --- Song ---
        public Task<SongList> SelectAllSongs();
        public Task<int> InsertASong(song song);
        public Task<int> UpdateASong(song song);
        public Task<int> DeleteASong(song song);
    }
}
