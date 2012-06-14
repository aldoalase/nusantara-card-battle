using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;

using MySql.Data.MySqlClient;

using NCBdatabase;


namespace NCBdatabase.model  
{
    public class PlayerLogin : connection
    {
        private ISessionFactory factory;

        public PlayerLogin()
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
        }

        //public List<Player> Login(string _playerName)
        public List<Player> Login(string _playerName, string _playerPassword)
        {
            List<Player> listPlayer = new List<Player>();
            var factory = this.CreateSessionFactory("Player_CardMap");
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
            return listPlayer;
            
        }

    }
}
