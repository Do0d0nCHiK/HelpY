using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelpY__0_
{
    internal class LoginForm: Form
    {
        private TextBox Name_TB, Group_TB, Pass_TB;
        bool NotNumber = false;
        public LoginForm():base()
        {
            this.Size = new Size(400,250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "Авторизация";
            this.FormClosed += Form_Close;
            Label Name_Label = new Label();
            Name_Label.Text = "Введите имя и фамилию:";
            Name_Label.Size = new Size(200, 30);
            Name_Label.Left = this.Left + 5;
            Name_Label.Top = this.Top + 20;
            Name_Label.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            this.Controls.Add(Name_Label);
            Name_TB = new TextBox
            {
                Size = new Size(150, 20),
                Left = Name_Label.Right,
                Top = Name_Label.Top,
                Font = new Font("Times New Roman", 11),
            };
            Name_TB.KeyDown += Name_Down_Key;
            Name_TB.KeyPress += Name_Press_Key;
            this.Controls.Add(Name_TB);
            Label Name_Group = new Label
            {
                Size = new Size(210, 30),
                Left = Name_Label.Left,
                Top = Name_Label.Bottom + 25,
                Text = "Введите название группы:",
                Font = Name_Label.Font,
            };
            this.Controls.Add(Name_Group);
            Group_TB = new TextBox
            {
                Size = new Size(150, 20),
                Left = Name_Group.Right,
                Top = Name_Group.Top,
                Font = Name_TB.Font,
            };
            this.Controls.Add(Group_TB);
            Label Pass_Label = new Label
            {
                Size = new Size(130, 30),
                Left = Name_Label.Left,
                Top = Name_Group.Bottom + 25,
                Text = "Введите пароль:",
                Font = Name_Label.Font,
            };
            this.Controls.Add(Pass_Label);
            Pass_TB = new TextBox
            {
                Size = new Size(150,20),
                Left= Pass_Label.Right + 5,
                Top = Pass_Label.Top,
                Font = Name_Label.Font,
                PasswordChar = '*',
                MaxLength = 14,
            };
            this.Controls.Add(Pass_TB);
            Button OK_Button = new Button
            {
                Text = "OK",
                Left = 130,
                Top = Pass_Label.Bottom + 10,
                Size = new Size(100, 30),
            };
            OK_Button.Click += OK_Click;
            this.Controls.Add(OK_Button);
        }
        private void Name_Down_Key(object obj,  KeyEventArgs e)
        {
            NotNumber = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) NotNumber = true;
        }
        private void Name_Press_Key(object obj, KeyPressEventArgs e)
        {
            if (NotNumber != true) e.Handled = true;
        }
        private void OK_Click(object obj, EventArgs e)
        {
            //Нужно описать проверку данных в БД, если нет такого человека, то предлагается пользователю зарегистрироваться
            Visible = false;
        }
        private void Form_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
