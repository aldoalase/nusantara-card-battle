using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace NCBdatabase
{
    
    
    public class PlayerCardMap : ClassMap<PlayerCard> {
        
        public PlayerCardMap() {
			Table("player_card");
			LazyLoad();
			Id(x => x.PlayerCardId).GeneratedBy.Identity().Column("PLAYER_CARD_ID");
			References(x => x.Card).Column("CARD_ID");
			References(x => x.Player).Column("PLAYER_ID");
			Map(x => x.PlayerCardActive).Column("PLAYER_CARD_ACTIVE");
        }
    }
}
