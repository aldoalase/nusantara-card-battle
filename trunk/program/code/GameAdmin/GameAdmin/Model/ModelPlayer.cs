using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameAdmin.Library;
using NHibernate.Linq;
using NHibernate;

namespace GameAdmin.Model
{
    class ModelPlayer : DbConnection
    {
        private ISessionFactory factory;
        public ModelPlayer()
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
        }

        public List<Player> login(string _playerName, string _playerPassword)
        {
            List<Player> listPlayer = new List<Player>();
            //var factory = this.CreateSessionFactory("Player_CardMap");
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

        /*
        public void UpdatePass(Player p, string _password)
        {
            //var factory = this.CreateSessionFactory("Player_CardMap");
            using (var session = this.factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    p = session.Get<Player>(p.PLAYER_ID);
                    p.PLAYER_PASSWORD = _password;
                    tx.Commit();
                }
            }
        }

        public void RegisterPlayer(string _newuser, string _newPassword)
        {
            var factory = this.CreateSessionFactory("Player_CardMap");
            using (var session = factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var player = new Player { 
                        PLAYER_NAME = _newuser, 
                        PLAYER_PASSWORD = _newPassword 
                    };

                    session.Save(player);
                    tx.Commit();
                }
            }
        }
        */

        public bool Process(String process, Player current)
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
                            break;
                    }
                    transaction.Commit();
                }
            }
            return true;
        }
    }
}
