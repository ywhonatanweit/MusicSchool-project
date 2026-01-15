using Model;
using System;
using System.Data.OleDb;
using ViewModel;
using Service;
using ApiMusic;
using System.Net.Http.Json;


namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
    
                #region song
                SongDB sdb = new();
            SongList sList = sdb.SelectAll();
            foreach (song c in sList)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine(c.Gaenreid);
                Console.WriteLine(c.Artistid);
                Console.WriteLine(c.Difficultyid);
                Console.WriteLine(c.Languageid);
            }
            song songToUpdate = sList[0];
            songToUpdate.Name = " חדש";
            sdb.Update(songToUpdate);
            int xs = sdb.SaveChanges();
            Console.WriteLine($"{xs} rows were updated");

          

            #endregion

            #region genre
            GenreDB gdb = new();
            GenreList gList = gdb.SelectAll();
            foreach(genre c in gList)
               Console.WriteLine(c.Genrename);
            genre genreToUpdate = gList[0];
            genreToUpdate.Genrename += " חדש";


            gdb.Update(genreToUpdate);
            int xg = gdb.SaveChanges();
            Console.WriteLine($"{xg} rows were updated");

            #endregion

            #region Chord
            ChordDB chdb = new();
            ChordList chList = chdb.SelectAll();
            foreach (chord c in chList)
            {
                Console.WriteLine(c);
                
            }
            chord chordToUpdate = chList[0];
            chordToUpdate.Name += " חדש";


            chdb.Update(chordToUpdate);
            int xc = chdb.SaveChanges();
            Console.WriteLine($"{xc} rows were updated");


            #endregion

            #region difficulty
            DifficultyDB ddb = new();
            DifficultyList dList = ddb.SelectAll();
            foreach (difficulty c in dList)
                Console.WriteLine(c.Diff);
            difficulty difficultyToUpdate = dList[0];
            difficultyToUpdate.Diff =3 ;


            ddb.Update(difficultyToUpdate);
            int xd = ddb.SaveChanges();
            Console.WriteLine($"{xd} rows were updated");
            #endregion

            #region language
            LanguageDB ldb = new();
            LanguageList lList = ldb.SelectAll();
            foreach (language c in lList)
                Console.WriteLine(c.Languagename);
            language languageToUpdate = lList[0];
            languageToUpdate.Languagename += " חדש";


            ldb.Update(languageToUpdate);
            int xl = ldb.SaveChanges();
            Console.WriteLine($"{xl} rows were updated");
            #endregion

            #region lyrics 
            LyricsDB lydb = new();
            LyricsList lyList = lydb.SelectAll();
            foreach (lyrics c in lyList)
            {
                Console.WriteLine(c.Lyricsname);
                Console.WriteLine(c.Songid);
                Console.WriteLine(c.Placment);
                Console.WriteLine(c.Chordid.Id);

            }

            lyrics lyricsToUpdate = lyList[0];
            lyricsToUpdate.Lyricsname = "2 חדש";

            lydb.Update(lyricsToUpdate);
            int xly = lydb.SaveChanges();
            Console.WriteLine($"{xly} rows were updated");

            #endregion

            #region person
            PersonDB pdb = new();
            PersonList pList = pdb.SelectAll();
            foreach (person c in pList)
            {
                Console.WriteLine(c.Code);
                Console.WriteLine(c.Name);
            }
            person personToUpdate = pList[0];
            personToUpdate.Name += " חדש";


            pdb.Update(personToUpdate);
            int xp = pdb.SaveChanges();
            Console.WriteLine($"{xp} rows were updated");

            #endregion

           

            #region artist
            ArtistDB adb = new();
            ArtistList aList = adb.SelectAll();
            foreach (Artist c in aList)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine(c.Code);

            }
            Artist artistToUpdate =  aList[0];
            artistToUpdate.Name += " חדש";


            adb.Update(artistToUpdate);
            int xa = adb.SaveChanges();
            Console.WriteLine($"{xa} rows were updated");

            #endregion



            #region song

            song s = new song() { Name = "קוצים",  Difficultyid = dList[0], Artistid = aList[0],Languageid= lList[0], Gaenreid = gList[0] };
            SongDB songDB = new SongDB();
            songDB.Insert(s);
            int xx=songDB.SaveChanges();

            SongList sdelete = songDB.SelectAll();
            songDB.Delete(sdelete.Last());
            xx = songDB.SaveChanges();



            // Artist
            Artist a = new Artist() { Name= "kanye west", Code=1334,  };
            ArtistDB artistDB = new ArtistDB();
            artistDB.Insert(a);
            int xx2 = artistDB.SaveChanges();

            ArtistList adelete = artistDB.SelectAll();
            artistDB.Delete(adelete.Last());
            xx2 = artistDB.SaveChanges();


            // Chord
            chord ch = new chord() {  Name="csus7", Difficulty = dList[4] };
            ChordDB chordDB = new ChordDB();
            chordDB.Insert(ch);
            int xx3 = chordDB.SaveChanges();
            ChordList cdelete = chordDB.SelectAll();
            chordDB.Delete(cdelete.Last());
            xx3 = chordDB.SaveChanges();

            // Difficulty
            difficulty d = new difficulty() { Diff=2};
            DifficultyDB difficultyDB = new DifficultyDB();
            difficultyDB.Insert(d);
            int xx4 = difficultyDB.SaveChanges();
            DifficultyList ddelete = difficultyDB.SelectAll();
            difficultyDB.Delete(ddelete.Last());
            xx4 = difficultyDB.SaveChanges();

            // Genre
            genre g = new genre() { Genrename="sad" };
            GenreDB genreDB = new GenreDB();
            genreDB.Insert(g);
            int xx5 = genreDB.SaveChanges();
            GenreList gdelete = genreDB.SelectAll();
            genreDB.Delete(gdelete.Last());
            xx5 = genreDB.SaveChanges();

            // Language
            language l = new language() { Languagename="italian" };
            LanguageDB languageDB = new LanguageDB();
            languageDB.Insert(l);
            int xx6 = languageDB.SaveChanges();
            LanguageList ldelete = languageDB.SelectAll();
            languageDB.Delete(ldelete.Last());
             xx6 = languageDB.SaveChanges();

            // Lyrics
            lyrics ly = new lyrics() { Chordid = chList[0], Lyricsname = "i got a feeling", Placment = 1, Songid = sList[0] };
            LyricsDB lyricsDB = new LyricsDB();
            lyricsDB.Insert(ly);
            int xx7 = lyricsDB.SaveChanges();
            LyricsList lydelete = lyricsDB.SelectAll();
            lyricsDB.Delete(lydelete.Last());
            xx7 = lyricsDB.SaveChanges();

            // Person
            person p = new person() { Code=32, Name="noam" };
            PersonDB personDB = new PersonDB();
            personDB.Insert(p);
            int xx8 = personDB.SaveChanges();
            PersonList pdelete = personDB.SelectAll();
            personDB.Delete(pdelete.Last());
            xx8 = personDB.SaveChanges();

            #endregion



        }
    }
}
