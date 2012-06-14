using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NCB.Mapping
{
    public sealed class BattleMap : ClassMap<Battle>
    {
        public BattleMap()
        {
            Id(x => x.BATTLE_ID);
            References<Player>(x => x.BATTLE_PLAYER_1, "`PLAYER_ID`").Not.LazyLoad().Cascade.SaveUpdate();
            References<Player>(x => x.BATTLE_PLAYER_2, "`PLAYER_ID`").Not.LazyLoad().Cascade.SaveUpdate();
            Map(x => x.BATTLE_TIME);
            References<Player>(x => x.BATTLE_WINNER, "`PLAYER_ID`").Not.LazyLoad().Cascade.SaveUpdate();
        }
    }
}
