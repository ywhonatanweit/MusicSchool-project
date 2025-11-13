using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class song:BaseEntity
    {
        private string name;
        private Artist artistid;
        private genre gaenreid;
        private difficulty difficultyid;
        private language languageid;

        public string Name { get => name; set => name = value; }
        public Artist Artistid { get => artistid; set => artistid = value; }
        public genre Gaenreid { get => gaenreid; set => gaenreid = value; }
        public difficulty Difficultyid { get => difficultyid; set => difficultyid = value; }
        public language Languageid { get => languageid; set => languageid = value; }
    }
}
