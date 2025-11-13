using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    
        public class ArtistList : List<Artist>
        {
            public ArtistList() { }
            public ArtistList(IEnumerable<Artist> list) : base(list) { }
            public ArtistList(IEnumerable<BaseEntity> list) : base(list.Cast<Artist>().ToList()) { }
        }
    
}

