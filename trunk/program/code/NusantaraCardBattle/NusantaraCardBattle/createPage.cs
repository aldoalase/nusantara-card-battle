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
    public partial class createPage : Form
    {
        private MainPage parent;
        public createPage(MainPage _parent)
        {
            InitializeComponent();
            this.parent = _parent;
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var factory = CreateSessionFactory();

            using (var session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Player p = new Player()
                    {
                        PLAYER_NAME = textBoxName.Text
                        //Description = txtCategoryDescription.Text
                    };

                    session.Save(p);
                    transaction.Commit();
                }
            }
            MessageBox.Show("sukses bro");
            this.Close();
            parent.init();
            parent.Show();
        }

 
    }
}
