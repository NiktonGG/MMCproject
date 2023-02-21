using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP
{
    public class Rootobject
    {
        public DateTime publish_date { get; set; }
        public Obj obj { get; set; }
        public string name { get; set; }
        public string id { get; set; }

        public class Obj
        {
            public Section[] sections { get; set; }
        }

        public class Section
        {
            public string content { get; set; }
            public string title { get; set; }
        }
    }
}