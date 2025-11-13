
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class chord:BaseEntity
    {
       
        private string name;
        private difficulty difficulty;

        public string Name { get => name; set => name = value; }
        public difficulty Difficulty { get => difficulty; set => difficulty = value; }

        public override string ToString()
        {
            return Name + "  "+Difficulty;
        }
    }
}
