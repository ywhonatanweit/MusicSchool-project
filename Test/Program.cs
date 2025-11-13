using Model;
using ViewModel;
using System.Data.OleDb;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenreDB gdb = new();
            GenreList cList = gdb.SelectAll();
            foreach(genre c in cList)
               Console.WriteLine(c.Genrename);



            ChordDB chdb = new();
            ChordList chList = chdb.SelectAll();
            foreach (chord c in chList)
            {
                Console.WriteLine(c);
                
            }



            DifficultyDB ddb = new();
            DifficultyList dList = ddb.SelectAll();
            foreach (difficulty c in dList)
                Console.WriteLine(c.Diff);



            LanguageDB ldb = new();
            LanguageList lList = ldb.SelectAll();
            foreach (language c in lList)
                Console.WriteLine(c.Languagename);



            LyricsDB lydb = new();
            LyricsList lyList = lydb.SelectAll();
            foreach (lyrics c in lyList)
            {
                Console.WriteLine(c.Lyricsname);
                Console.WriteLine(c.Songid);
                Console.WriteLine(c.Placment);
                Console.WriteLine(c.Chordid);

            }

            lyrics lyricsToUpdate = lyList[0];
            lyricsToUpdate.Lyricsname += " חדש";

            ldb.Update(lyricsToUpdate);
            int xly = ldb.SaveChanges();
            Console.WriteLine($"{xly} rows were updated");




            PersonDB pdb = new();
            PersonList pList = pdb.SelectAll();
            foreach (person c in pList)
            {
                Console.WriteLine(c.Code);
                Console.WriteLine(c.Name);
            }



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
            songToUpdate.Name += " חדש";
        

            sdb.Update(songToUpdate);
            int xs = sdb.SaveChanges();
            Console.WriteLine($"{xs} rows were updated");



            ArtistDB adb = new();
            ArtistList aList = adb.SelectAll();
            foreach (Artist c in aList)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine(c.Code);

            }


        }
    }
}
