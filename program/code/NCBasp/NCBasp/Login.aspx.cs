using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;

using MySql.Data.MySqlClient;
using System.Collections;

using NCBdatabase;
using NCBdatabase.model;

namespace NCBasp
{
    public partial class Login : System.Web.UI.Page
    {
        private PlayerLogin a;

        protected void Page_Load(object sender, EventArgs e)
        {

            a = new PlayerLogin();
        }

        protected void loginClick(Object sender, EventArgs e)
        {
            //List<Player> players = a.Login(UserNameLoginBox.Text);
            List<Player> players = a.Login(UserNameLoginBox.Text, PasswordLoginBox.Text);
            Session["player"] = players;
            
            if (players.Count == 1)
            {
                Response.Redirect("Profile.aspx");
            }
            else
                Response.Redirect("Default.aspx"); 
        }
    }
}