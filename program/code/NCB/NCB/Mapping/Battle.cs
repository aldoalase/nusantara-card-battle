using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCB.Mapping
{
    public class Battle
    {
        public virtual int BATTLE_ID { get; set; }
        public virtual Player BATTLE_PLAYER_1 { get; set; }
        public virtual Player BATTLE_PLAYER_2 { get; set; }
        public virtual DateTime BATTLE_TIME { get; set; }
        public virtual Player BATTLE_WINNER { get; set; }
    }
}
