using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;

using NCBdatabase;


namespace NCBdatabase.model
{
    public class RegisterPlayer : connection
    {
        private ISessionFactory factory;

        public RegisterPlayer()
        {
            
        }

        private void RegisPlayer()
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
        }

        public void RegisPlayer(string newUsername, string newPassword)
        {
            var factory = this.CreateSessionFactory("Player_CardMap");
            using (var session = factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var player = new Player
                    {
                        PLAYER_NAME = newUsername,
                        PLAYER_PASSWORD = newPassword
                    };

                    session.Save(player);
                    tx.Commit();
                }
            }
        }
    }
}


