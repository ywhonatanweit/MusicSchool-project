using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
        public class LyricsList : List<lyrics>
        {
            public LyricsList() { }
            public LyricsList(IEnumerable<lyrics> list) : base(list) { }
        public LyricsList(IEnumerable<BaseEntity> list) : base(list.Cast <lyrics>().ToList()) { }

        }
}

