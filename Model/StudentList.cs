using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentList : List<student>
    {
        public StudentList() { }
        public StudentList(IEnumerable<student> list) : base(list) { }
        public StudentList(IEnumerable<BaseEntity> list) : base(list.Cast<student>().ToList()) { }
    
    }
}
