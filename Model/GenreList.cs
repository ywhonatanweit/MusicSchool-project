using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenreList : List<genre>
    {

        public GenreList() { }
        public GenreList(IEnumerable<genre> list) : base(list) { }
        public GenreList(IEnumerable<BaseEntity> list) : base(list.Cast<genre>().ToList()) { }
    }
    
    }

