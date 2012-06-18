using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace NCBdatabase.model
{
    public class GetBattle : connection
    {
        private ISessionFactory factory;

        public GetBattle()
        {
            
        }

        public List<Battle> GetBattles(Player player)
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
            List<Battle> listBattle = new List<Battle>();
            using (var session = this.factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    listBattle = session.Query<Battle>()
                        .Where(u => u.BATTLE_PLAYER_1.Equals(player.PLAYER_ID))
                        .ToList();
                    tx.Commit();
                }
            }
            return listBattle;
        }
    }
}
