using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

using NCBdatabase;


namespace NCBdatabase.model
{
    public class LoginPlayer : connection
    {
        private ISessionFactory factory;

        public LoginPlayer()
        {
            
        }

        private void loginUser()
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
        }

        public void RegisterPlayer(string newUsername, string _newPassword)
        {
            var factory = this.CreateSessionFactory("Player_CardMap");
            using (var session = factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var player = new Player
                    {
                        PLAYER_NAME = newUsername,
                        PLAYER_PASSWORD = _newPassword
                    };

                    session.Save(player);
                    tx.Commit();
                }
            }
        }
    }
}


