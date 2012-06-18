using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NCBdatabase;
using NCBdatabase.model;

namespace NCBasp
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Player> players = new List<Player>();
            players = (List<Player>)Session["player"];

            if(players == null)
                Response.Redirect("Default.aspx");

            UserName.Text = players[0].PLAYER_NAME;
            PlayerWin.Text = players[0].PLAYER_WIN.ToString();
            PlayerLose.Text = players[0].PLAYER_LOSE.ToString();
            PlayerMoney.Text = players[0].PLAYER_MONEY.ToString();
        }
    }
}