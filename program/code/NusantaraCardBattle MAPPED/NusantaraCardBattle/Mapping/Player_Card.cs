using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NusantaraCardBattle.Mapping
{
    class Player_Card
    {
        public virtual Card Card { get; set; }
        public virtual Player Player { get; set; }
        public virtual int PLAYER_CARD_ID { get; set; }
    }
}
