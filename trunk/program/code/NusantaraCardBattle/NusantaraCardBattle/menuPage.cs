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
    public partial class menuPage : Form
    {
        private Player current;
        private MainPage parent;

        public menuPage(MainPage _parent, Player _current)
        {
            InitializeComponent();
            this.parent = _parent;
            this.current = _current;
            init();
        }

        public void init()
        {
            textBox1.Text = current.PLAYER_NAME;
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

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.init();
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            current.PLAYER_NAME = textBox1.Text;
            var factory = CreateSessionFactory();

            using (var session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Player p = current;
                    session.Update(p);
                    transaction.Commit();
                }
            }

            MessageBox.Show("sukses diupdate");
            init();
        }


    }
}
