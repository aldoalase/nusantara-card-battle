using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NCBdatabase
{
    public sealed class BattleMap : ClassMap<Battle>
    {
        public BattleMap()
        {
            Id(x => x.BATTLE_ID);
            Map(x => x.BATTLE_PLAYER_1);
            Map(x => x.BATTLE_PLAYER_2);
            Map(x => x.BATTLE_TIME);
            Map(x => x.BATTLE_WINNER);
        }
    }
}
