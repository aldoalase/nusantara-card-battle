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
            this.factory = this.CreateSessionFactory("BattleMap");
        }

        public List<Battle> GetBattles(Player player)
        {
            this.factory = this.CreateSessionFactory("BattleMap");
            List<Battle> listBattle = new List<Battle>();
            using (var session = this.factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    listBattle = session.Query<Battle>()
                        .Where(u => u.BATTLE_PLAYER_2.PLAYER_ID.Equals(player.PLAYER_ID) || u.BATTLE_PLAYER_1.PLAYER_ID.Equals(player.PLAYER_ID))
                        .ToList();
                    tx.Commit();
                }
            }
            return listBattle;
        }
    }
}
