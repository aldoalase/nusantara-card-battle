using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCB.Object
{
    class Data
    {
        private string source;
        private string dest;
        private string protocol;

        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }

        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }
    }
}
