using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCB.Library;
using NHibernate.Linq;
using NHibernate;

namespace NCB.Model
{
    class ModelPlayer_Card : DbConnection
    {
        private ISessionFactory factory = null;
        public ModelPlayer_Card()
        {
            if(this.factory == null)
                this.factory = this.CreateSessionFactory("Player_CardMap");
        }

        /* load player's card */
        public List<Player_Card> LoadPlayerCard(int playerId)
        {
            List<Player_Card> listCard = new List<Player_Card>();
            using (var session = this.factory.OpenSession())
            {
                listCard = session.Query<Player_Card>()
                    .Where(u => u.Player.PLAYER_ID == playerId)
                    .ToList();
            }
            return listCard;
        }

        public bool Process(String process, Player_Card current)
        {
            using (var session = this.factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    switch (process)
                    {
                        case "save" :
                            session.Save(current);
                            break;
                        case "update" :
                            session.Update(current);
                            break;
                        case "delete" :
                            session.Delete(current);
                            session.Flush();
                            break;
                    }
                    transaction.Commit();
                }
            }
            return true;
        }
    }
}
