using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class video:BaseEntity
    {
        private song songid;
        private string songAddress;

        public song Songid { get => songid; set => songid = value; }
        public string SongAddress { get => songAddress; set => songAddress = value; }
    }
}
