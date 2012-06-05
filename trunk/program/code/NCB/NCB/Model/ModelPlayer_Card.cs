using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCB.Library;
using NHibernate.Linq;

namespace NCB.Model
{
    class ModelPlayer_Card : DbConnection
    {
        /* load player's card */
        public List<Player_Card> loadPlayerCard(int playerId)
        {
            List<Player_Card> listCard = new List<Player_Card>();
            var factory = this.CreateSessionFactory("Player_CardMap");
            using (var session = factory.OpenSession())
            {
                listCard = session.Query<Player_Card>()
                    .Where(u => u.Player.PLAYER_ID == playerId)
                    .ToList();
            }
            return listCard;
        }
    }
}
