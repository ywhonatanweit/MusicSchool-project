using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SongList : List<song>
    {
        public SongList() { }
        public SongList(IEnumerable<song> list) : base(list) { }
        public SongList(IEnumerable<BaseEntity> list) : base(list.Cast<song>().ToList()) { }
    
    }
}
