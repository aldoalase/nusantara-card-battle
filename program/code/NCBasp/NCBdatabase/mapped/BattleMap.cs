using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NCB.Mapping;

namespace NCB
{
    public sealed class BattleMap : ClassMap<Battle>
    {
        public BattleMap()
        {
            Id(x => x.BATTLE_ID);
            References<Player>(x => x.BATTLE_PLAYER_1, "`BATTLE_PLAYER_1`").Not.LazyLoad().Cascade.SaveUpdate();
            References<Player>(x => x.BATTLE_PLAYER_2, "`BATTLE_PLAYER_2`").Not.LazyLoad().Cascade.SaveUpdate();
            Map(x => x.BATTLE_TIME);
            References<Player>(x => x.BATTLE_WINNER, "`BATTLE_WINNER`").Not.LazyLoad().Cascade.SaveUpdate();
        }
    }
}
