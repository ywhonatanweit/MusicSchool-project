using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LanguageList:List<language>
    {
        public LanguageList() { }
        public LanguageList(IEnumerable<language> list) : base(list) { }
        public LanguageList(IEnumerable<BaseEntity> list) : base(list.Cast<language>().ToList()) { }
    }
    
    }

