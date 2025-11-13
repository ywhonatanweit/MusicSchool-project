using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class language : BaseEntity
    {
      
        private string languagename;

     
        public string Languagename { get => languagename; set => languagename = value; }
    }
}
