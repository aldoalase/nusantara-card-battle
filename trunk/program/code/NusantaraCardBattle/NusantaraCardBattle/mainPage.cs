using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;

using MySql.Data.MySqlClient;

namespace NusantaraCardBattle
{
    public partial class MainPage : Form
    {
        private List<Player> players = new List<Player>();
        private menuPage menu;
        private createPage create;

        public MainPage()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            listPlayer.Items.Clear();
            var factory = CreateSessionFactory();
            using (var session = factory.OpenSession())
            {
                players = session.Query<Player>()
                       .OrderBy(c => c.PLAYER_NAME)
                       .ToList();
            }

            for (int i = 0; i < players.Count; i++)
            {
                listPlayer.Items.Add(players[i].PLAYER_NAME);
            }
        }

        #region database
        private Configuration NHibernateConfiguration()
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(c => c.Server("10.151.36.38")
                    .Database("tcgn")
                    .Username("tcgn")
                    .Password("tcgn")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PlayerMap>())
                .BuildConfiguration();
        }

        private ISessionFactory CreateSessionFactory()
        {
            return NHibernateConfiguration().BuildSessionFactory();
        }
        #endregion

        private void startButton_Click(object sender, EventArgs e)
        {
            if (listPlayer.SelectedItem == null)
            {
                MessageBox.Show("Chose player disik bro");
            }
            else
            {
                this.Hide();
                menu = new menuPage(this, players[listPlayer.SelectedIndex]);
                menu.ShowDialog();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            create = new createPage(this);
            create.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listPlayer.SelectedItem == null)
            {
                MessageBox.Show("Chose player disik bro");
            }
            else
            {
                var factory = CreateSessionFactory();

                using (var session = factory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        Player p = players[listPlayer.SelectedIndex];
                        session.Delete(p);
                        transaction.Commit();
                    }
                }
                MessageBox.Show("berhasil dihapus");
                init();
            }


        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

    }
}
