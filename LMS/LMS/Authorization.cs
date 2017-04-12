using System;
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
    public partial class Authorization : Form
    {
        TextBox Login;
        TextBox Password;
        Button SignIn;
        Button Register;
        public Authorization()
        {
            InitializeComponent();
            this.FormBorderStyle = (FormBorderStyle)1;
            this.Height = 220;
            Login = new TextBox
            {
                Location = new Point(13, 25),
                Size = new Size(ClientSize.Width - 26, 30),
                //Text = "Введите логин"
                Text = "student2016"
            };
            Password = new TextBox
            {
                Location = new Point(13, Login.Bottom + 25),
                Size = Login.Size,
                //Text = "Введите пароль"
                PasswordChar = '*',
                Text = "123"
            };

            SignIn = new Button
            {
                Location = new Point(13, Password.Bottom + 20),
                Size = Login.Size,
                Height = 25,
                Text = "Войти"
            };

            Register = new Button
            {
                Location = new Point(13, SignIn.Bottom + 10),
                Size = Login.Size,
                Height = 25,
                Text = "Регистрация"
            };

            Controls.Add(Login);
            Controls.Add(Password);
            Controls.Add(SignIn);
            Controls.Add(Register);


            SignIn.Click += (sender, args) =>
            {
                var login = Login.Text;
                var password = Password.Text;
                User.CheckDataIn("dataIn.txt", login, password);
                var userPersonalInfo = User.GetPersonalInfo("usersInfo.txt", login);
                var user = new User(login, password, userPersonalInfo[0], userPersonalInfo[1], userPersonalInfo[2], userPersonalInfo[3]);
                var main = new Main(user);
                main.Show();
                Hide();
            };


            Register.Click += (sender, args) =>
             {
                 Hide();
                 var registration = new Registration(this);
                 registration.ShowDialog();
             };
        }

    }
}