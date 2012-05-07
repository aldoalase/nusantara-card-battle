using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NusantaraCardBattle
{
    public sealed class Player_CardMap : ClassMap<Player_Card>
    {
        public Player_CardMap()
        {
            References(x => x.Card).Cascade.All();
            References(x => x.Player).Cascade.All();
            Id(x => x.PLAYER_CARD_ID);
        }
    }
}
