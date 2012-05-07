using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

using NusantaraCardBattle;

namespace NusantaraCardBattle
{
    public sealed class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Id(x => x.PLAYER_ID);
            Map(x => x.PLAYER_NAME);
            Map(x => x.PLAYER_PASSWORD);
            Map(x => x.PLAYER_SCORE);
            Map(x => x.PLAYER_WIN);
            Map(x => x.PLAYER_LOSE);
        }
    }
}
