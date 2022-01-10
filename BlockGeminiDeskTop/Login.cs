using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestBusinessLayer.ViewModels;

namespace BlockGeminiDeskTop
{
    public partial class LoginForm : Form
    {
         UserViewModel userViewModel;
        
        public string UserName { get; set; } // set after login

        public LoginForm()
        {
            InitializeComponent();
            userViewModel = new UserViewModel();
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            string email = txt_Email.Text;
            string password = txt_Password.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("You should enter your email");
                return;
            }


            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("You should enter your password");
                return;
            }

            var ret = await userViewModel.login(email, password);
            if (!ret)
            {
                MessageBox.Show("Incorrect credintials!");
                return;
            }

            DialogResult res = MessageBox.Show("You have logged in successfuly");
            if (res == DialogResult.OK)
            {
                UserName = email;
               
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
