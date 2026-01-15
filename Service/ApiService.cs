using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ApiService: Interface
    {
        string uri;
        public HttpClient client;

        public ApiService()
        {
            uri = "http://localhost:5008"; 
            client = new HttpClient();
        }

        #region artist
        public async Task<ArtistList> SelectAllArtists()
        {
            return await client.GetFromJsonAsync<ArtistList>(uri + "/api/Select/ArtistSelector");
        }

        public async Task<int> InsertAArtist(Artist a)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertAArtist", a)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateAArtist(Artist a)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateAArtist", a)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteAArtist(Artist a)
        {
            int id = a.Id;
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteArtist?id={id}")).IsSuccessStatusCode ? 1 : 0;
        }

        #endregion



        #region chord
        public async Task<ChordList> SelectAllChords()
        {
            return await client.GetFromJsonAsync<ChordList>(uri + "/api/Select/ChordSelector");
        }

        public async Task<int> InsertAChord(chord c)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertAChord", c)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateAChord(chord c)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateAChord", c)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteAChord(chord c)
        {   
            int id = c.Id;
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteChord/?id={id}")).IsSuccessStatusCode ? 1 : 0;
        }


        #endregion



        #region difficulty
        public async Task<DifficultyList> SelectAllDifficulties()
        {
            return await client.GetFromJsonAsync<DifficultyList>(uri + "/api/Select/DifficultySelector");
        }

        public async Task<int> InsertADifficulty(difficulty d)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertADifficulty", d)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateADifficulty(difficulty d)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateADifficulty", d)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteADifficulty(difficulty d)
        {
            int id = d.Id;
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteDifficulty/?id={id}")).IsSuccessStatusCode ? 1 : 0;
        }



        #endregion



        #region genre
        public async Task<GenreList> SelectAllGenres()
        {
            return await client.GetFromJsonAsync<GenreList>(uri + "/api/Select/GenreSelector");
        }

        public async Task<int> InsertAGenre(genre g)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertAGenre", g)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateAGenre(genre g)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateAGenre", g)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteAGenre(genre g)
        {
            int id = 0;
           // id=g.Id;
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteGenre/?id={g.Id}")).IsSuccessStatusCode ? 1 : 0;
        }


        #endregion



        #region language
        public async Task<LanguageList> SelectAllLanguages()
        {
            return await client.GetFromJsonAsync<LanguageList>(uri + "/api/Select/LanguageSelector");
        }

        public async Task<int> InsertALanguage(language l)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertALanguage", l)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateALanguage(language l)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateALanguage", l)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteALanguage(language l)

        {
            int id = l.Id;
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteLanguage/?id={id}")).IsSuccessStatusCode ? 1 : 0;
        }


        #endregion



        #region lyrics
        public async Task<LyricsList> SelectAllLyrics()
        {
            return await client.GetFromJsonAsync<LyricsList>(uri + "/api/Select/LyricsSelector");
        }

        public async Task<int> InsertALyrics(lyrics ly)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertALyrics", ly)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateALyrics(lyrics ly)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateALyrics", ly)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteALyrics(lyrics ly)
        {
            int id = ly.Id;
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteLyrics/?id={id}")).IsSuccessStatusCode ? 1 : 0;
        }


        #endregion



        #region person
        public async Task<PersonList> SelectAllPersons()
        {
            return await client.GetFromJsonAsync<PersonList>(uri + "/api/Select/PersonSelector");
        }

        public async Task<int> InsertAPerson(person p)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertAPerson", p)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateAPerson(person p)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateAPerson", p)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteAPerson(person p)
        {
            int id = p.Id;
            return (await client.DeleteAsync(uri + $"/api/Select/DeletePerson/?id={id}")).IsSuccessStatusCode ? 1 : 0;
        }


        #endregion



        #region song
        public async Task<SongList> SelectAllSongs()
        {
            return await client.GetFromJsonAsync<SongList>(uri + "/api/Select/SongSelector");
        }

        public async Task<int> InsertASong(song s)
        {
            return (await client.PostAsJsonAsync(uri + "/api/Select/InsertASong", s)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateASong(song s)
        {
            return (await client.PutAsJsonAsync(uri + "/api/Select/UpdateASong", s)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteASong(song s)
        {
            int id = s.Id;
            return (await client.DeleteAsync(uri + $"/api/Select/DeleteSong?id={id}" )).IsSuccessStatusCode ? 1 : 0;
            
        }


        #endregion



    }
}

