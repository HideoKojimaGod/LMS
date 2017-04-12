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
    public partial class PersonalCabinet : Form, IStyler
    {

        Button ChangeFirstName;
        Button ChangeSecondName;
        Button ChangeLastName;
        Button ChangePassword;
        Button ChangeEmail;

        Button BackToOwner;
        Button GoToCourses;
        Button GoToGradeBook;
        Button GoToAuthorization;

        Label Email;
        Label Names;

        User User;

        public PersonalCabinet(User user)
        {
            InitializeComponent();

            User=user;

            Height = 500;
            Width = 750;

            Email = SetDefaultLabelStyle("Email: " + user.GetEmail());
            Names = SetDefaultLabelStyle("Ф.И.О.: " + user.GetSecondName() + " " + user.GetFirstName() + " " + user.GetLastName());

            ChangeFirstName = SetDefaultButtonStyle("Изменить имя");
            ChangeSecondName = SetDefaultButtonStyle("Изменить фамилию");
            ChangeLastName = SetDefaultButtonStyle("Изменить отчество");
            ChangePassword = SetDefaultButtonStyle("Изменить пароль");
            ChangeEmail = SetDefaultButtonStyle("Изменить почту");
            BackToOwner = SetDefaultButtonStyle("Вернуться");
            GoToAuthorization = SetDefaultButtonStyle("Выход");
            GoToCourses = SetDefaultButtonStyle("Курсы");
            GoToGradeBook = SetDefaultButtonStyle("Зачетная книжка");

            var mainTable = new TableLayoutPanel();
            var tables = new TableLayoutPanel[3];

            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 60));

            tables[0] = new TableLayoutPanel();
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[0].RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            tables[1] = new TableLayoutPanel();
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[1].RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            tables[1].RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            tables[2] = new TableLayoutPanel();
            tables[2].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.5f));
            tables[2].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            tables[2].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[2].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            tables[2].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.5f));
            tables[2].RowStyles.Add(new RowStyle(SizeType.Percent, 33.3f));
            tables[2].RowStyles.Add(new RowStyle(SizeType.Percent, 33.3f));
            tables[2].RowStyles.Add(new RowStyle(SizeType.Percent, 33.4f));


            tables[0].Controls.Add(new Panel(), 0, 0);
            tables[0].Controls.Add(GoToCourses, 1, 0);
            tables[0].Controls.Add(GoToGradeBook, 2, 0);
            tables[0].Controls.Add(GoToAuthorization, 3, 0);
            tables[0].Controls.Add(new Panel(), 4, 0);
            tables[0].Dock = DockStyle.Fill;


            tables[1].Controls.Add(new Panel(), 0, 0);
            tables[1].Controls.Add(Email, 1, 0);
            tables[1].Controls.Add(new Panel(), 2, 0);
            tables[1].Controls.Add(new Panel(), 0, 1);
            tables[1].Controls.Add(Names, 1, 1);
            tables[1].Controls.Add(new Panel(), 2, 1);
            tables[1].Dock = DockStyle.Fill;


            tables[2].Controls.Add(new Panel(), 0, 0);
            tables[2].Controls.Add(ChangeFirstName, 1, 0);
            tables[2].Controls.Add(new Panel(), 2, 0);
            tables[2].Controls.Add(ChangeEmail, 3, 0);
            tables[2].Controls.Add(new Panel(), 4, 0);
            tables[2].Controls.Add(new Panel(), 0, 1);
            tables[2].Controls.Add(ChangeSecondName, 1, 1);
            tables[2].Controls.Add(new Panel(), 2, 1);
            tables[2].Controls.Add(ChangePassword, 3, 1);
            tables[2].Controls.Add(new Panel(), 4, 1);
            tables[2].Controls.Add(new Panel(), 0, 2);
            tables[2].Controls.Add(ChangeLastName, 1, 2);
            tables[2].Controls.Add(new Panel(), 2, 2);
            tables[2].Controls.Add(BackToOwner, 3, 2);
            tables[2].Controls.Add(new Panel(), 4, 2);
            tables[2].Dock = DockStyle.Fill;

            for(int index=0; index< tables.Length; index++)
                mainTable.Controls.Add(tables[index], 0, index);
            mainTable.Dock = DockStyle.Fill;

            Controls.Add(mainTable);

            var userLogin = user.GetLogin();
            ChangeEmail.Click +=(sender,args) =>
            {
                var newEmail = SendRequest("Введите новую почту: ");
                if (newEmail != null)
                {
                    Checker.CheckEmail(newEmail);
                    Parser.ChangeData("usersInfo.txt", user.GetEmail(), newEmail, userLogin);
                    user.ChangeEmail(newEmail);
                }
            };
            ChangeFirstName.Click += (sender, args) =>
             {
                 var newFirstName = SendRequest("Введите новое имя: ");
                 if (newFirstName != null)
                 {
                     Checker.CheckName(newFirstName);
                     Parser.ChangeData("usersInfo.txt", user.GetFirstName(), newFirstName, userLogin);
                     user.ChangeFirstName(newFirstName);
                 }
             };
            ChangeSecondName.Click += (sender, args) =>
             {
                 var newSecondName = SendRequest("Введите новую фамилию: ");
                 if (newSecondName != null)
                 {
                     Checker.CheckName(newSecondName);
                     Parser.ChangeData("usersInfo.txt", user.GetSecondName(), newSecondName, userLogin);
                     user.ChangeSecondName(newSecondName);
                 }
             };
            ChangeLastName.Click += (sender, args) =>
             {
                 var newLastName = SendRequest("Введите новое отчество: ");
                 if (newLastName != null)
                 {
                     Checker.CheckName(newLastName);
                     Parser.ChangeData("usersInfo.txt", user.GetLastName(), newLastName, userLogin);
                     user.ChangeLastName(newLastName);
                 }
             };
            ChangePassword.Click += (sender, args) =>
             {
                 var newPassword = SendRequest("Введите новый пароль: ");
                 if (newPassword != null)
                 {
                     Checker.CheckPassword(newPassword);
                     Parser.ChangeData("usersInfo.txt", user.GetPassword(), newPassword, userLogin);
                     user.ChangePassword(newPassword);
                 }
             };

            BackToOwner.Click += (sender, args) =>
             {
                 this.Close();
                 new Main(user).Show();
             };
            GoToCourses.Click += (sender, args) =>
            {
                this.Close();
                new Courses(User).Show();
            };
            GoToAuthorization.Click += (sender, args) =>
             {
                 this.Close();
                 new Authorization().Show();
             };
            GoToGradeBook.Click += (sender, args) =>
             {
                 MessageBox.Show("К сожалению, в данный момент зачетная книжка не доступна");
             };

            user.EmailChanged += (email) =>ShowNewEmail(email);
            user.FirstNameChanged += (firstName) => ShowNewFirstName(firstName); 
            user.SecondNameChanged += (secondName) => ShowNewSecondName(secondName);
            user.LastNameChanged += (lastName) =>ShowNewLastName(lastName);
            user.PasswordChanged += (password) =>ShowNewPassword(password);
        }

        private string SendRequest(string text)
        {
            var form = new Form()
            {
                Width = 375,
                Height = 150,
                FormBorderStyle = (FormBorderStyle)1
           };

            Label label = new Label()
            {
                Location = new Point(25, 10),
                Width = 150,
                Text = text
            };

            TextBox textBox = new TextBox()
            {
                Location = new Point(label.Right+10, 10),
                Width = 150,
                Text = null
            };
            Button confirm = new Button()
            {
                Location = new Point(25, 75),
                Text = "Подтвердить",
                Width = 100
            };
            

            Button cancel = new Button()
            {
                Location = new Point(confirm.Right+40, 75),
                Text = "Отмена",
                Width = 100
            };

            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(confirm);
            form.Controls.Add(cancel);

            string result = null;

            confirm.Click += (sender, args) =>
            {
                result = textBox.Text;
                form.Close();
            };

             cancel.Click += (sender, args) =>
             {
                 result = null;
                 form.Close();
             };

            form.ShowDialog();

            return result;
        }

        private void ShowNewEmail(string email)
        {
            Email.Text = "Email: " + email;
            MessageBox.Show("Ваша почта успешно изменена");
        }

        private void ShowNewFirstName(string firstName)
        {
            var names = Names.Text.Split(new Char[] { ' ' });
            Names.Text = names[0] + " " +  names[1]+ " " + firstName + " " + names[3];
            MessageBox.Show("Ваше имя успешно изменено");
        }

        private void ShowNewSecondName(string secondName)
        {
            var names = Names.Text.Split(new Char[] { ' ' });
            Names.Text = names[0]+ " " + secondName + " " + names[2]+ " " + names[3];
            MessageBox.Show("Ваша фамилия успешно изменена");
        }

        private void ShowNewLastName(string lastName)
        {
            var names = Names.Text.Split(new Char[] { ' ' });
            Names.Text = names[0] + " " + names[1] + " " + names[2]+ " " + lastName;
            MessageBox.Show("Ваше отчество успешно изменено");
        }

        private void ShowNewPassword(string password)
        {
            MessageBox.Show("Ваш пароль успешно изменен");
        }

        public Button SetDefaultButtonStyle(string text)
        {
            return new Button()
            {
                Text = text,
                Dock = DockStyle.Fill,
                Font = new Font("Calibri", 18)
            };
        }

        public Label SetDefaultLabelStyle(string text)
        {
            return new Label()
            {
                Text = text,
                Dock = DockStyle.Fill,
                Font = new Font("Calibri", 14)
            };
        }

    }

}

