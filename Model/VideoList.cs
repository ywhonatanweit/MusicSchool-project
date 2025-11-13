using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VideoList :List<video>
    {
        public VideoList() { }
        public VideoList(IEnumerable<video> list) : base(list) { }
        public VideoList(IEnumerable<BaseEntity> list) : base(list.Cast<video>().ToList()) { }
    }
    
    }

