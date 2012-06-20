using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace NCBdatabase.model
{
    public class Password : connection
    {
        private ISessionFactory factory;

        public Password()
        {
        }

        public void UpdatePass(int _idPlayer, string _password)
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
            using (var session = this.factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var Player = session.Get<Player>(_idPlayer);
                    Player.PLAYER_PASSWORD = _password;
                    tx.Commit();
                }
            }
        }

    }
}
