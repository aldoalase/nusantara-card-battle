using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NCB;

using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;

namespace NCB.Library
{
    class DbConnection
    {
        private MySQLConfiguration config()
        {
            return MySQLConfiguration.Standard.ConnectionString(c => c.Server("10.151.36.38")
                    .Database("tcgn")
                    .Username("tcgn")
                    .Password("tcgn"));
        }

        public ISessionFactory CreateSessionFactory(String map)
        {
            switch (map)
            {
                case "CardMap":
                    return Fluently.Configure()
                        .Database(config())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CardMap>())
                        .BuildConfiguration().BuildSessionFactory();
                case "PlayerMap" :
                    return Fluently.Configure()
                        .Database(config())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PlayerMap>())
                        .BuildConfiguration().BuildSessionFactory();
                case "Player_CardMap":
                    return Fluently.Configure()
                        .Database(config())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Player_CardMap>())
                        .BuildConfiguration().BuildSessionFactory();
                case "BattleMap":
                    return Fluently.Configure()
                        .Database(config())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BattleMap>())
                        .BuildConfiguration().BuildSessionFactory();
                default:
                    return null;

            }
        }

        /* load player's card */
        public List<Player_Card> loadPlayerCard(int playerId)
        {
            List<Player_Card> listCard;
            var factory = CreateSessionFactory("Player_CardMap");
            using (var session = factory.OpenSession())
            {
                listCard = session.Query<Player_Card>()
                    .Where(u => u.Player.PLAYER_ID == playerId)
                    .ToList();
            }
            return listCard;
        }

        public List<Player> login(string playerName, string playerPassword)
        {
            List<Player> listPlayer;
            var factory = CreateSessionFactory("PlayerMap");
            using (var session = factory.OpenSession())
            {
                listPlayer = session.Query<Player>()
                    .Where(u => u.PLAYER_NAME.Equals(playerName))
                    .Where(p => p.PLAYER_PASSWORD.Equals(playerPassword))
                    .ToList();
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
    }
}
