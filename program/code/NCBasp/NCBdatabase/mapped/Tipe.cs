using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCBdatabase
{
    public class Tipe
    {
        public virtual int TIPE_ID { get; set; }
        public virtual string TIPE_NAME { get; set; }
        public override string ToString()
        {
            return TIPE_NAME;
        }
    }
}
