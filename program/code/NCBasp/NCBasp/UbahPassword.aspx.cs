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
    public partial class UbahPassword : System.Web.UI.Page
    {
        private Password cp;
        int idPlayer;

        protected void Page_Load(object sender, EventArgs e)
        {
            cp = new Password();

            List<Player> players = new List<Player>();
            players = (List<Player>)Session["player"];
            
            if (players == null)
                Response.Redirect("Default.aspx");
            
            idPlayer = players[0].PLAYER_ID;

            
        }

        protected void loginClick(object sender, EventArgs e)
        {
            if (UbahPassBox.Text == "" || UbahPassBox2.Text == "" || UbahPassBox3.Text == "")
            {
                Status.Text = "username dan password tidak boleh kosong";
            }
            else if (UbahPassBox2.Text == UbahPassBox3.Text)
            {
                cp.UpdatePass(idPlayer, UbahPassBox2.Text);
            }
            else
            {
                Status.Text = "password tidak sama, ulangi lagi";
            }
        }
    }
}