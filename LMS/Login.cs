﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Login : Form
    {
        private Boolean loginSuccess = false;

        Dashboard dashboard = new Dashboard();

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = loginButton;
           //var USER = new User();
        }

        private object USER { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            //store user entered data
            var USER = new User() { password = passwordEntry.Text, username = usernameEntry.Text};
            //compare with database
            //
            //check privilege
            int privilege = 0;
            //store privilege to USER.adminPrivilege
            //testing admin privilege
            USER.adminPrivilege = true;
            //USER.superPrivilege //???
            //USER.adminPrivilege
            //USER.profPrivilege
            //USER.studPrivilege
            //...
            loginSuccess = true;
            //if login is sucessful show dashboard form and hide login form
            if (loginSuccess)
            {
                //set modifyPanel.visible = true if adminPrivilege = true
                if (USER.adminPrivilege)
                {
                    privilege = 1;
                }
                else if (USER.profPrivilege)
                {
                    privilege = 2;
                }
                else if (USER.studPrivilege)
                {
                    privilege = 3;
                }

                dashboard.setMode(privilege);
                usernameEntry.Text = "";
                passwordEntry.Text = "";
                dashboard.Show();
                this.Hide();
            } else
            {
                errorLabel.Visible = true;
                passwordEntry.Text = "";
            }
        }

        public void ClearUserInfo()
        {
            loginSuccess = false;
            //clear current user login
        }
    }
}
