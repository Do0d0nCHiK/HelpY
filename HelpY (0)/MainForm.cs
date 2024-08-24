using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelpY__0_
{
    internal class MainForm:Form
    {
        LoginForm loginForm;
        public MainForm():base()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.Text = "HelpY";
            loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
