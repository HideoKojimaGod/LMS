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
    public partial class Main : Form, IStyler
    {
        Button GoToCourses;
        Button GoToPersonalCabinet;
        User User;
        public Main(User user)
        {
            InitializeComponent();
            Width = 400;
            User = user;


            var table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));



            GoToCourses = SetDefaultButtonStyle("Курсы");
            GoToPersonalCabinet = SetDefaultButtonStyle("Личный кабинет");

            for(int index=0; index < 5; index++)
            {
                table.Controls.Add(new Panel(), index, 0);
                table.Controls.Add(new Panel(), index, 2);
            }

            table.Controls.Add(new Panel(), 0, 1);
            table.Controls.Add(GoToCourses, 1, 1);
            table.Controls.Add(new Panel(), 2, 1);
            table.Controls.Add(GoToPersonalCabinet, 3, 1);
            table.Controls.Add(new Panel(), 4, 1);

            Controls.Add(table);
            GoToCourses.Click += (sender, args) =>
            {
                new Courses(User).Show();
                Close();
            };
            GoToPersonalCabinet.Click += (sender, args) =>
             {
                 new PersonalCabinet(User).Show();
                 Close();
             };
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
