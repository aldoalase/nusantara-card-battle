using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCBdatabase
{
    public class Battle
    {
        public virtual int BATTLE_ID { get; set; }
        public virtual int BATTLE_PLAYER_1 { get; set; }
        public virtual int BATTLE_PLAYER_2 { get; set; }
        public virtual string BATTLE_TIME { get; set; }
        public virtual int BATTLE_WINNER { get; set; }
    }
}
