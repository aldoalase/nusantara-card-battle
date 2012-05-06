using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NusantaraCardBattle.Mapping
{
    class Player
    {
        public virtual int PLAYER_ID { get; set; }
        public virtual string PLAYER_NAME { get; set; }
        public virtual string PLAYER_PASSWORD { get; set; }
        public virtual int PLAYER_SCORE { get; set; }
        public virtual int PLAYER_WIN { get; set; }
        public virtual int PLAYER_LOSE { get; set; }
    }
}
