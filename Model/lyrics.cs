using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class lyrics:BaseEntity
    {
        private song songid;
        private int placment;
        private chord chordid;
        private string lyricsname;

        public song Songid { get => songid; set => songid = value; }
        public int Placment { get => placment; set => placment = value; }
        public chord Chordid { get => chordid; set => chordid = value; }
        public string Lyricsname { get => lyricsname; set => lyricsname = value; }
    }
}
