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
            Id(x => x.PLAYER_CARD_ID);
            References<Card>(x => x.Card, "`CARD_ID`").Not.LazyLoad().Cascade.SaveUpdate();
            References<Player>(x => x.Player, "`PLAYER_ID`").Not.LazyLoad().Cascade.SaveUpdate();
            Map(x => x.PLAYER_CARD_ACTIVE);
        }
    }
}
