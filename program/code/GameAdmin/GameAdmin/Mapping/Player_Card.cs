using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameAdmin
{
    public class Player_Card
    {
        public virtual int PLAYER_CARD_ID { get; set; }
        public virtual Card Card { get; set; }
        public virtual Player Player { get; set; }
        public virtual bool PLAYER_CARD_ACTIVE { get; set; }
    }
}
