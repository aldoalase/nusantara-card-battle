﻿using System;
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
            IDUser.Text = players[0].PLAYER_ID.ToString();
        }
    }
}