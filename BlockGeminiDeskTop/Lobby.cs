using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockGeminiDeskTop
{
    public partial class LobbyForm : Form
    {

        public LobbyForm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
                string userName = loginForm.UserName;
                if (!string.IsNullOrEmpty(userName))
                {
                    btn_Login.Text = userName;
                    btn_Login.Enabled = false;
                }
            }
        }
    }
}
