using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class difficulty:BaseEntity
    {
        private string diff;


        public string Diff { get => diff; set => diff = value; }
        public override string ToString()
        {
            return Diff;
        }
    }
}
