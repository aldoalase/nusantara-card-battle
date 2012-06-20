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

            if (battles.Count !=0)
            {
                LabelVS.Text = "VS";
                LabelLastBattle.Text = "Last Battle :";
                LabelWinner.Text = "Winner";
                LabelTime.Text = "Battle Time";
                LabelTitikDua.Text = ":";
                LabelTitikDuaJuga.Text = ":";
                Player1.Text = battles[battles.Count - 1].BATTLE_PLAYER_1.PLAYER_NAME;
                Player2.Text = battles[battles.Count - 1].BATTLE_PLAYER_2.PLAYER_NAME;
                Winner.Text = battles[battles.Count - 1].BATTLE_WINNER.PLAYER_NAME;
                Time.Text = battles[battles.Count - 1].BATTLE_TIME.ToString();
            }
            else
            {
                LabelNULL.Text = "Belum Pernah Bertanding";
            }
        }
    }
}