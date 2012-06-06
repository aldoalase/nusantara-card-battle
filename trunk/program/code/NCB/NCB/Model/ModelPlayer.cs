using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCB.Library;
using NHibernate.Linq;
namespace NCB.Model
{
    class ModelPlayer : DbConnection
    {
        public List<Player> login(string _playerName, string _playerPassword)
        {
            List<Player> listPlayer = new List<Player>();
            var factory = this.CreateSessionFactory("Player_CardMap");
            using (var session = factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    listPlayer = session.Query<Player>()
                        .Where(u => u.PLAYER_NAME.Equals(_playerName))
                        .Where(p => p.PLAYER_PASSWORD.Equals(_playerPassword))
                        .ToList();
                    tx.Commit();
                }
                    /*
                #simpe query
                players = session.Query<Player>().ToList();
                
                #using HQl
                IQuery query = session.CreateQuery("FROM Player p WHERE p.PLAYER_NAME = :Name");
                query.SetParameter("Name", TextBoxUsername.Text);
                players = query.List<Player>();
                */
            }
            return listPlayer;
        }

        public void UpdatePass(Player p, string _password)
        {
            var factory = this.CreateSessionFactory("PlayerMap");
            using (var session = factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    p = session.Get<Player>(p.PLAYER_ID);
                    p.PLAYER_PASSWORD = _password;
                    tx.Commit();
                }
            }
        }
    }
}
