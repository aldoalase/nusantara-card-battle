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
    public partial class About : System.Web.UI.Page
    {
        private LoginPlayer a;

        protected void Page_Load(object sender, EventArgs e)
        {
            a = new LoginPlayer();
           // LoginButton.Click += new EventHandler(this.loginClick);
        }

        protected void loginClick(Object sender, EventArgs e)
        {            
            a.RegisterPlayer(UserNameBox.Text, PasswordBox.Text);
        }
    }
}
