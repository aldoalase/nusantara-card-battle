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
            this.factory = this.CreateSessionFactory("Player_CardMap");
            using (var session = this.factory.OpenSession())
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

            GetPlayer getPlayer = new GetPlayer();
            Player newPlayer = getPlayer.Get(newUsername, newPassword);

            for (int i=0; i<4; i++)
            {
                RandomCard randomCard = new RandomCard();
                randomCard.GiveCard(newPlayer);
            }
        }
    }
}


