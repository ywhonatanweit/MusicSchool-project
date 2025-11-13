using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DifficultyList:List<difficulty>
    {
       
            public DifficultyList() { }
            public DifficultyList(IEnumerable<difficulty> list) : base(list) { }
            public DifficultyList(IEnumerable<BaseEntity> list) : base(list.Cast<difficulty>().ToList()) { }
        }
    }

