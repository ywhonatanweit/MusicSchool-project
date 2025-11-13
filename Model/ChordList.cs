using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChordList : List<chord>
    {
        public ChordList() { }
        public ChordList(IEnumerable<chord> list) : base(list) { }
        public ChordList(IEnumerable<BaseEntity> list) : base(list.Cast<chord>().ToList()) { }
    }
}