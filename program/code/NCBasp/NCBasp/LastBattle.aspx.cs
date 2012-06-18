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
    public partial class LastBattle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Player> players = new List<Player>();
            players = (List<Player>)Session["player"];

            if (players == null)
                Response.Redirect("Default.aspx");

            UserName.Text = players[0].PLAYER_NAME;

            GetBattle getBattle = new GetBattle();
            List<Battle> battles = getBattle.GetBattles(players[0]);

            GridView1.DataSource = battles;
            GridView1.DataBind();
        }
    }
}