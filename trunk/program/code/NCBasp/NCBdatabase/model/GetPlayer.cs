using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace NCBdatabase.model
{
    class GetPlayer : connection
    {
        private ISessionFactory factory;

        public GetPlayer()
        {
        }

        //public List<Player> Login(string _playerName)
        public Player Get(string _playerName, string _playerPassword)
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
            List<Player> listPlayer = new List<Player>();
            using (var session = this.factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    listPlayer = session.Query<Player>()
                        .Where(u => u.PLAYER_NAME.Equals(_playerName))
                        .Where(p => p.PLAYER_PASSWORD.Equals(_playerPassword))
                        .ToList();
                    tx.Commit();
                }
            }
            return listPlayer[0];
        }
    }
}
