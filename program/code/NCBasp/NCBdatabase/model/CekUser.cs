using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace NCBdatabase.model
{
    public class CekUser : connection
    {
        private ISessionFactory factory;

        public CekUser()
        {

        }

        //public List<Player> Login(string _playerName)
        public Player Get(string _playerName)
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
            List<Player> listPlayer = new List<Player>();
            using (var session = this.factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    listPlayer = session.Query<Player>()
                        .Where(u => u.PLAYER_NAME.Equals(_playerName))
                        .ToList();
                    tx.Commit();
                }
            }
            if (listPlayer.Count != 0)
                return listPlayer[0];
            else
                return null;
        }

        public bool Cek(string _playerName)
        {
            Player player = Get(_playerName);
            if (player != null)
                return true;
            else
            {
                return false;
            }
        }
    }
}
