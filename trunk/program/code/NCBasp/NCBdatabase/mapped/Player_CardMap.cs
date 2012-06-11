using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NCBdatabase
{
    public sealed class Player_CardMap : ClassMap<Player_Card>
    {
        public Player_CardMap()
        {
            Table("`player_card`");
            References<Card>(x => x.Card, "`CARD_ID`").Cascade.All();
            References<Player>(x => x.Player, "`PLAYER_ID`").Cascade.All();
            Id(x => x.PLAYER_CARD_ID);
            Map(x => x.PLAYER_CARD_ACTIVE);
        }
    }
}
