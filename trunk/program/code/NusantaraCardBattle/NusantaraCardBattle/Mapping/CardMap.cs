using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NusantaraCardBattle
{
    public sealed class CardMap : ClassMap<Card>
    {
        public CardMap()
        {
            Id(x => x.CARD_ID);
            Map(x => x.CARD_NAME);
            Map(x => x.CARD_DESCRIPTION);
            Map(x => x.CARD_STRENGTH);
            Map(x => x.CARD_DEFENSE);
            Map(x => x.CARD_HP);
            Map(x => x.CARD_LEVEL);
            Map(x => x.CARD_TIPE);
            Map(x => x.CARD_MAGIC_NUMBER);
            Map(x => x.ENCHANT_STRENGTH);
            Map(x => x.ENCHANT_DEFENSE);
            Map(x => x.ENCHANT_HP);
        }
    }
}
