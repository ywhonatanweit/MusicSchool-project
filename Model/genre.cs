using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class genre:BaseEntity
    {
        private string genrename;

        public string Genrename { get => genrename; set => genrename = value; }
    }
}
