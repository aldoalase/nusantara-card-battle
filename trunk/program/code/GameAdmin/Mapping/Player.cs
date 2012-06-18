using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCB
{
    public class Player
    {
        public virtual int PLAYER_ID { get; set; }
        public virtual string PLAYER_NAME { get; set; }
        public virtual string PLAYER_PASSWORD { get; set; }
        public virtual int PLAYER_WIN { get; set; }
        public virtual int PLAYER_LOSE { get; set; }
        public virtual double PLAYER_MONEY { get; set; }
    }
}
