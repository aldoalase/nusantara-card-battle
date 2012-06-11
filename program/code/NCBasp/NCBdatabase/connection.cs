using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;

using NCBdatabase;

namespace NCBdatabase
{
    public class connection
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
    }
}

