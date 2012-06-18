using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NCBdatabase
{
    public sealed class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Id(x => x.PLAYER_ID);
            Map(x => x.PLAYER_NAME);
            Map(x => x.PLAYER_PASSWORD);
            Map(x => x.PLAYER_WIN);
            Map(x => x.PLAYER_LOSE);
            Map(x => x.PLAYER_MONEY);
        }
    }
}
