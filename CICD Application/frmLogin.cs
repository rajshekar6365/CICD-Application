using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CICD_Application
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lblMessage.Text = "Please enter credentials";
            }
            else
            {
                dbActions db = new dbActions();
                string validateQuery = "Select * from tblUsers where " +
                    "Username = '" + txtUserName.Text + "' and Password = '" +
                    txtPassword.Text + "'";
                if (db.ValidateUser(validateQuery))
                {
                    this.Hide();
                    frmHomePage homePage = new frmHomePage();
                    homePage.Show();
                }
                else
                {
                    txtUserName.Clear();
                    txtPassword.Clear();
                    lblMessage.Text = "Invalid Credentials";
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
