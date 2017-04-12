using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Materials : Form, IStyler
    {
        Button GoToCourses;
        Button GoToPersonalCabinet;
        Button GoToGradeBook;
        ComboBox labWork;
        ComboBox material;
        ComboBox test;
        Button addTest;
        Button deleteTest;
        Button addLabWork;
        Button addMaterial;
        Button deleteLabWork;
        Button deleteMaterial;
        Button overlookMaterial;
        Button overlookLabWork;
        Button overlookTest;
        Label[] labels;
        string courseName;
        User User;

        public Materials(string courseName, User user)
        {

            InitializeComponent();
            User = user;
            Width = 1250;
            Height = 500;
            var mainTable = new TableLayoutPanel();
            var tables = new TableLayoutPanel[2];


            mainTable = new TableLayoutPanel();
            mainTable.Dock = DockStyle.Fill;

            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 80));


            mainTable.Controls.Add(tables[0] = new TableLayoutPanel(), 0, 0);
            mainTable.Controls.Add(tables[1] = new TableLayoutPanel(), 0, 1);

            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            tables[0].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[0].RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tables[0].Dock = DockStyle.Fill;

            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[1].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tables[1].RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            tables[1].RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            tables[1].RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            tables[1].RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            tables[1].Dock = DockStyle.Fill;



            this.courseName = courseName;
            Name = courseName;
            FormBorderStyle = (FormBorderStyle)4;
            labWork = new ComboBox();
            material = new ComboBox();
            test = new ComboBox();




            tables[0].Controls.Add(new Panel(), 0, 0);
            tables[0].Controls.Add(GoToCourses = SetDefaultButtonStyle("Курсы"), 1, 0);
            tables[0].Controls.Add(GoToPersonalCabinet = SetDefaultButtonStyle("Личный кабинет"), 2, 0);
            tables[0].Controls.Add(GoToGradeBook = SetDefaultButtonStyle("Зачетная книжка"), 3, 0);
            tables[0].Controls.Add(new Panel(), 4, 0);


            tables[1].Controls.Add(new Panel(), 0, 0);
            tables[1].Controls.Add(test, 1, 0);
            tables[1].Controls.Add(overlookTest = SetDefaultButtonStyle("Просмотреть тест"), 2, 0);
            tables[1].Controls.Add(addTest = SetDefaultButtonStyle("Добавить тест"), 3, 0);
            tables[1].Controls.Add(deleteTest = SetDefaultButtonStyle("Удалить тест"), 4, 0);
            tables[1].Controls.Add(new Panel(), 5, 0);
            tables[1].Controls.Add(new Panel(), 0, 1);
            tables[1].Controls.Add(material, 1, 1);
            tables[1].Controls.Add(overlookMaterial = SetDefaultButtonStyle("Просмотреть материал"), 2, 1);
            tables[1].Controls.Add(addMaterial = SetDefaultButtonStyle("Добавить материал"), 3, 1);
            tables[1].Controls.Add(deleteMaterial = SetDefaultButtonStyle("Удалить материал"), 4, 1);
            tables[1].Controls.Add(new Panel(), 5, 1);
            tables[1].Controls.Add(new Panel(), 0, 2);
            tables[1].Controls.Add(labWork, 1, 2);
            tables[1].Controls.Add(overlookLabWork = SetDefaultButtonStyle("Просмотреть лабораторную"), 2, 2);
            tables[1].Controls.Add(addLabWork = SetDefaultButtonStyle("Добавить лабораторную"), 3, 2);
            tables[1].Controls.Add(deleteLabWork = SetDefaultButtonStyle("Удалить лабораторную"), 4, 2);
            tables[1].Controls.Add(new Panel(), 5, 2);

            for (int index = 0; index < tables[1].ColumnCount; index++)
                tables[1].Controls.Add(new Panel(), index, 3);




            var testFile = new OpenFileDialog()
            {
                Multiselect = false
            };
            var materialFile = new OpenFileDialog()
            {
                Multiselect = false
            };
            var labWorkFile = new OpenFileDialog()
            {
                Multiselect = false
            };


            addTest.Click += (sender, args) => testFile.ShowDialog();
            testFile.FileOk += (sender, args) =>
            {
                FileInfo fi = new FileInfo(testFile.FileName);
                File.Copy(testFile.FileName, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fi.Name));
                Parser.WriteData("test_path.txt", fi.Name.Split('.')[0] + ':' + fi.Name);
                Parser.PutData("course_test.txt", fi.Name.Split('.')[0], courseName);
                FillComboBoxes();
            };

            addMaterial.Click += (sender, args) => materialFile.ShowDialog();
            materialFile.FileOk += (sender, args) =>
            {
                FileInfo fi = new FileInfo(materialFile.FileName);
                File.Copy(materialFile.FileName, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fi.Name));
                Parser.WriteData("material_path.txt", fi.Name.Split('.')[0] + ':' + fi.Name);
                Parser.PutData("course_material.txt", fi.Name.Split('.')[0], courseName);
                FillComboBoxes();
            };

            addLabWork.Click += (sender, args) => labWorkFile.ShowDialog();
            labWorkFile.FileOk += (sender, args) =>
            {
                FileInfo fi = new FileInfo(labWorkFile.FileName);
                File.Copy(labWorkFile.FileName, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fi.Name));
                Parser.WriteData("labwork_path.txt", fi.Name.Split('.')[0] + ':' + fi.Name);
                Parser.PutData("course_labwork.txt", fi.Name.Split('.')[0], courseName);
                FillComboBoxes();
            };

            deleteTest.Click += (sender, args) =>
            {
                Parser.DeleteData("test_path.txt", (string)test.SelectedItem);
                Parser.DeleteData("course_test.txt", (string)test.SelectedItem, courseName);
                FillComboBoxes();
            };
            deleteLabWork.Click += (sender, args) =>
            {
                Parser.DeleteData("labwork_path.txt", (string)labWork.SelectedItem);
                Parser.DeleteData("course_labwork.txt", (string)labWork.SelectedItem, courseName);
                FillComboBoxes();
            };
            deleteMaterial.Click += (sender, args) =>
            {
                Parser.DeleteData("material_path.txt", (string)material.SelectedItem);
                Parser.DeleteData("course_material.txt", (string)material.SelectedItem, courseName);
                FillComboBoxes();
            };

            GoToCourses.Click += (sender, args) =>
             {
                 this.Close();
                 new Courses(User).Show();
             };
            GoToPersonalCabinet.Click += (sender, args) =>
            {
                this.Close();
                new PersonalCabinet(User).Show();
            };
            GoToGradeBook.Click += (sender, args) =>
            {
                Close();
                MessageBox.Show("К сожалению, зачетная книжка сейчас недоступна");
            };
            FillComboBoxes();

            overlookMaterial.Click += (sender, args) =>
                Process.Start(Parser.ReadDataIn("material_path.txt")[(string)material.SelectedItem]);
            overlookLabWork.Click += (sender, args) =>
                Process.Start(Parser.ReadDataIn("labwork_path.txt")[(string)labWork.SelectedItem]);
            overlookTest.Click += (sender, args) =>
                Process.Start(Parser.ReadDataIn("test_path.txt")[(string)test.SelectedItem]);

            Controls.Add(mainTable);
        }

        private void FillComboBoxes()
        {
            labWork.Items.Clear();
            material.Items.Clear();
            test.Items.Clear();
            Dictionary<string, List<string>> labWorks = Parser.Read("course_labwork.txt");
            Dictionary<string, List<string>> materials = Parser.Read("course_material.txt");
            Dictionary<string, List<string>> tests = Parser.Read("course_test.txt");
            labWork.Items.AddRange(labWorks[courseName].ToArray());
            material.Items.AddRange(materials[courseName].ToArray());
            test.Items.AddRange(tests[courseName].ToArray());
            labWork.SelectedIndex = 0;
            material.SelectedIndex = 0;
            test.SelectedIndex = 0;
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
