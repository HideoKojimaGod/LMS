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
    public partial class Registration : Form
    {
        Label firstName;
        Label secondName;
        Label lastName;
        Label login;
        Label password;
        Label email;

        TextBox FirstName;
        TextBox SecondName;
        TextBox LastName;
        TextBox Login;
        TextBox Password;
        TextBox Email;

        Button register;

        public Registration(Form owner)
        {
            InitializeComponent();
            Owner = owner;
            Height = 350;
            Width = 420;

            login = new Label
            {
                Location = new Point(10, 25),
                Text = "Введите ваш логин:",
                Width = 150
            };
            password = new Label
            {
                Location = new Point(10, login.Bottom + 15),
                Text = "Введите ваш пароль:",
                Width = 150
            };

            email = new Label
            {
                Location = new Point(10, password.Bottom + 15),
                Text = "Введите вашу почту:",
                Width = 150
            };

            firstName = new Label
            {
                Location = new Point(10, email.Bottom + 15),
                Text = "Введите ваше имя:",
                Width = 150
            };

            secondName = new Label
            {
                Location = new Point(10, firstName.Bottom + 15),
                Text = "Введите вашу фамилию:",
                Width = 150
            };
            lastName = new Label
            {
                Location = new Point(10, secondName.Bottom + 15),
                Text = "Введите ваше отчество:",
                Width = 150
            };


            Login = new TextBox()
            {
                Location = new Point(login.Right + 15, 25),
                Width = 200
            };

            Password = new TextBox()
            {
                Location = new Point(password.Right + 15, login.Bottom + 15),
                Width = 200
            };

            Email = new TextBox()
            {
                Location = new Point(email.Right + 15, password.Bottom + 15),
                Width = 200
            };

            FirstName = new TextBox()
            {
                Location = new Point(firstName.Right + 15, email.Bottom + 15),
                Width = 200
            };

            SecondName = new TextBox()
            {
                Location = new Point(secondName.Right + 15, firstName.Bottom + 15),
                Width = 200
            };


            LastName = new TextBox()
            {
                Location = new Point(lastName.Right + 15, secondName.Bottom + 15),
                Width = 200
            };

            register = new Button()
            {
                Location = new Point(this.Width / 4, LastName.Bottom + 25),
                Text = "Зарегистрироваться",
                Width = 150

            };

            Controls.Add(firstName);
            Controls.Add(secondName);
            Controls.Add(login);
            Controls.Add(password);
            Controls.Add(email);
            Controls.Add(lastName);

            Controls.Add(FirstName);
            Controls.Add(SecondName);
            Controls.Add(LastName);
            Controls.Add(Login);
            Controls.Add(Password);
            Controls.Add(Email);

            Controls.Add(register);


            register.Click += (sender, args) =>
            {
                CheckInfo();
                UpdateUsersInfo();
                Owner.Show();
                Hide();
            };
        }

        private void CheckInfo()
        {
            Checker.CheckEmail(Email.Text);
            Checker.CheckLogin(Login.Text);
            Checker.CheckPassword(Password.Text);
            Checker.CheckName(FirstName.Text, SecondName.Text, LastName.Text);
        }

        private void UpdateUsersInfo()
        {
            string userDataIn = Login.Text + ":" + Password.Text;
            Parser.WriteData("dataIn.txt", userDataIn);
            string userInfo = Login.Text + " " + FirstName.Text + " " + SecondName.Text + " " + LastName.Text + " " + Email.Text;
            Parser.WriteData("usersInfo.txt", userInfo);
        }
    }
}
