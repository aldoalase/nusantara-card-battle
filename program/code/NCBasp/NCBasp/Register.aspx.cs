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
    public partial class Register : System.Web.UI.Page
    {
        private RegisterPlayer a;
        private CekUser _cekUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            a = new RegisterPlayer();
            _cekUser = new CekUser();
        }

        protected void registerClick(Object sender, EventArgs e)
        {
            if (UserNameRegisterBox.Text == "" || PasswordRegisterBox.Text == "" || PasswordRegisterBox2.Text == "")
            {
                StatusRegister.Text = "username dan password tidak boleh kosong";
            }

            else if (PasswordRegisterBox.Text == PasswordRegisterBox2.Text)
            {
                if (!_cekUser.Cek(UserNameRegisterBox.Text))
                    a.RegisPlayer(UserNameRegisterBox.Text, PasswordRegisterBox.Text);
                else
                    StatusRegister.Text = "user name yang anda masukkan sudah terdaftar";
            }

            else
            {
                StatusRegister.Text = "password tidak sama, ulangi lagi";
                UserNameRegisterBox.Text = null;
                PasswordRegisterBox.Text = null;
                PasswordRegisterBox2.Text = null;
            }
        }
    }
}