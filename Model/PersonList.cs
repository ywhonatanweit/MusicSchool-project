using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonList : List<person>
    {
        public PersonList() { }
        public PersonList(IEnumerable<person> list) : base(list) { }
        public PersonList(IEnumerable<BaseEntity> list) : base(list.Cast<person>().ToList()) { }
    
    }
}
