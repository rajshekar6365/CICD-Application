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
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //validations
            if (string.IsNullOrEmpty(txtUsername.Text))
                lblMessage.Text = "User name is mandatory";
            if (string.IsNullOrEmpty(txtPassword.Text))
                lblMessage.Text = "Password is mandatory";
            if (string.IsNullOrEmpty(txtEmail.Text))
                lblMessage.Text = "Email is mandatory";
            if (string.IsNullOrEmpty(txtConfirmPwd.Text))
                lblMessage.Text = "Reenter password is mandatory";
            if (txtPassword.Text != txtConfirmPwd.Text)
                lblMessage.Text = "Password and confirm password should match";


            dbActions dbActions = new dbActions();
            string addUser = "Insert into tblUsers Values ('" +
                txtUsername.Text + "', '" + txtPassword.Text + "', '" +
                txtEmail.Text + "')";
            dbActions.InsertUser(addUser);

            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }
    }
}
