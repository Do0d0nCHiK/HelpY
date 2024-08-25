using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HelpY__0_
{
    internal class MainForm:Form
    {
        enum Mouth:byte
        {
            Январь = 1,
            Февраль = 2,
            Март = 3,
            Апрель = 4,
            Май = 5,
            Июнь = 6,
            Июль = 7,
            Август = 8,
            Сентябрь = 9,
            Октябрь = 10,
            Ноябрь = 11,
            Декабрь = 12
        }
        LoginForm loginForm;
        DateTime date;
        Label Time;
        public MainForm():base()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.Width = 1940;
            this.Height = 1080;
            this.Text = "HelpY";
            loginForm = new LoginForm();
            loginForm.ShowDialog();
            date = DateTime.Now;
            Label Date = new Label
            {
                Top = this.Top,
                Left = this.Right + 70,

                Text = $"    {date.Day}\n{What_The_Mouth(date.Month)}",
                Font = new Font("Times New Roman", 15, FontStyle.Bold),
                Size = new Size(100, 60),
                Location = new Point(this.Right - 100, this.Left),
                BackColor = Color.Red,
            };
            this.Controls.Add(Date);
            Time = new Label
            {
                Left = Date.Left,
                Top = Date.Bottom,
                BackColor = Color.Red,
                Size = Date.Size,
                Font = Date.Font,
            };
            this.Controls.Add(Time);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }
        private string What_The_Mouth(int dt)
        {
            for (byte i = 1; i <= 12; i++)
            {
                if (i == (byte)dt) 
                {
                    Mouth mt = (Mouth)i;
                    return mt.ToString();
                }
            }
            return "";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
