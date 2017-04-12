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
    public partial class Courses : Form, IStyler
    {
        ComboBox semesters;
        ComboBox courses;
        List<List<string>> subjects;
        Button showCourse;
        Button GoToPersonalCabinet;
        Button GoToGradeBook;

        User User;
        public Courses(User user)
        {
            InitializeComponent();
            User = user;
            Width = 750;

            var mainTable = new TableLayoutPanel();
            var tables = new TableLayoutPanel[2];


            mainTable = new TableLayoutPanel();
            mainTable.Dock = DockStyle.Fill;

            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 40));


            mainTable.Controls.Add(tables[0]=new TableLayoutPanel(),0,0);
            mainTable.Controls.Add(tables[1]=new TableLayoutPanel(),0,1);

            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[0].RowStyles.Add(new RowStyle(SizeType.Percent, 34));
            tables[0].RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            tables[0].RowStyles.Add(new RowStyle(SizeType.Percent, 58));
            tables[0].Dock = DockStyle.Fill;

            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            tables[1].RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            tables[1].RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            tables[1].Dock = DockStyle.Fill;



            subjects = new List<List<string>>();
            subjects.Add(new List<string>()
                {
                    "Базы данных",
                    "Исследование операций"
                });

            subjects.Add(new List<string>()
                {
                    "ООП",
                    "Сети"
                });
            FormBorderStyle = (FormBorderStyle)4;
            semesters = new ComboBox()
            {
                Location = new Point(25, 25),
                Items =
                {
                    "Летний семестр 2017",
                    "Зимний семестр 2016-2017"
                },
                Width = 200
            };

            courses = new ComboBox()
            {
                Location = new Point(semesters.Right + 10, 25),
                Width = 200

            };
            courses.Items.AddRange(subjects[0].ToArray());
            courses.SelectedItem = courses.Items[0];
            semesters.SelectedItem = semesters.Items[0];

            semesters.SelectedIndexChanged += (sender, args) =>
            {
                courses.Items.Clear();
                courses.Items.AddRange(subjects[semesters.SelectedIndex].ToArray());
                courses.SelectedItem = courses.Items[0];
            };

            tables[0].Controls.Add(new Panel(), 0, 0);
            tables[0].Controls.Add(GoToPersonalCabinet=SetDefaultButtonStyle("Личный кабинет"), 1, 0);
            tables[0].Controls.Add(new Panel(), 2, 0);
            tables[0].Controls.Add(GoToGradeBook=SetDefaultButtonStyle("Зачетная книжка"), 3, 0);
            tables[0].Controls.Add(new Panel(), 4, 0);

            for (int index = 0; index < tables[0].ColumnCount; index++)
                tables[0].Controls.Add(new Panel(),index,1);

            tables[0].Controls.Add(new Panel(), 0, 2);
            tables[0].Controls.Add(semesters, 1, 2);
            tables[0].Controls.Add(new Panel(), 2, 2);
            tables[0].Controls.Add(courses, 3, 2);
            tables[0].Controls.Add(new Panel(), 4, 2);

            tables[1].Controls.Add(new Panel(), 0, 0);
            tables[1].Controls.Add(showCourse = SetDefaultButtonStyle("Просмотреть"), 1, 0);
            tables[1].Controls.Add(new Panel(), 2, 0);

            for (int index = 0; index < tables[1].ColumnCount; index++)
                tables[1].Controls.Add(new Panel(), index, 1);


            Controls.Add(mainTable);

            showCourse.Click += (sender, args) =>
            {
                Close();
                var materials = new Materials(courses.SelectedItem.ToString(), User);
                materials.Show();
            };
            GoToGradeBook.Click += (sender, args) =>
              {
                  Close();
                  MessageBox.Show("К сожалению, зачетная книжка сейчас недоступна");
              };
            GoToPersonalCabinet.Click += (sender, args) =>
             {
                 Close();
                 new PersonalCabinet(User).Show();
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
