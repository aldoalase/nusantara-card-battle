using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace NCBdatabase.model
{
    class RandomCard : connection
    {
        private ISessionFactory factory;

        public RandomCard()
        {
            
        }

        public void GiveCard(Player player, Card card)
        {
            Player_Card playerCard = new Player_Card()
            {
                Card = card,
                Player = player,
                PLAYER_CARD_ACTIVE = true
            };

            this.factory = CreateSessionFactory("Player_CardMap");
            using (var session = this.factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(playerCard);
                    tx.Commit();
                }
            }
        }
    }
}
