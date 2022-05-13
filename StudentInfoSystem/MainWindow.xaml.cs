using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TextBox> TextBoxes = new List<TextBox>();
        public List<string> StudStatusChoices { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
            this.DataContext = this;
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
                context.SaveChanges();
            }
        }
        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0) return true;
            else return false;
        }
        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
        private void GetTextBoxList()
        {
            TextBoxes.Add(txtName);
            TextBoxes.Add(txtSurname);
            TextBoxes.Add(txtLastName);
            TextBoxes.Add(txtFaculty);
            TextBoxes.Add(txtMajor);
            TextBoxes.Add(txtDegree);
            //TextBoxes.Add(txtStatus);
            TextBoxes.Add(txtFacNum);
            TextBoxes.Add(txtYear);
            TextBoxes.Add(txtStream);
            TextBoxes.Add(txtGroup);
        }
        private void ClearText()
        {
            GetTextBoxList();
            foreach (TextBox i in TextBoxes)
            {
                i.Clear();
            }
            //txtName.Clear();
            //txtSurname.Clear();
            //txtLastName.Clear();
            //txtFaculty.Clear();
            //txtMajor.Clear();
            //txtDegree.Clear();
            //txtStatus.Clear();
            //txtFacNum.Clear();
            //txtYear.Clear();
            //txtStream.Clear();
            //txtGroup.Clear();
        }
        private void ShowStudent(Student student)
        {
            txtName.Text = student.name;
            txtSurname.Text = student.surname;
            txtLastName.Text = student.lastName;
            txtFaculty.Text = student.faculty;
            txtMajor.Text = student.major;
            txtDegree.Text = student.degree;
            //txtStatus.Text = student.status;
            txtFacNum.Text = student.facultyNumber;
            txtYear.Text = student.year;
            txtStream.Text = student.stream;
            txtGroup.Text = student.group;
        }
        private void BlockControls()
        {          
            GetTextBoxList();
            foreach (TextBox i in TextBoxes)
            {
                i.IsEnabled = false;
            }
            //txtName.IsEnabled = false;
            //txtSurname.IsEnabled = false;
            //txtLastName.IsEnabled = false;
            //txtFaculty.IsEnabled = false;
            //txtMajor.IsEnabled = false;
            //txtDegree.IsEnabled = false;
            //txtStatus.IsEnabled = false;
            //txtFacNum.IsEnabled = false;
            //txtYear.IsEnabled = false;
            //txtStream.IsEnabled = false;
            //txtGroup.IsEnabled = false;
        }
        private void EnableControls()
        {
            GetTextBoxList();
            foreach (TextBox i in TextBoxes)
            {
                i.IsEnabled = true;
            }
            //txtName.IsEnabled = true;
            //txtSurname.IsEnabled = true;
            //txtLastName.IsEnabled = true;
            //txtFaculty.IsEnabled = true;
            //txtMajor.IsEnabled = true;
            //txtDegree.IsEnabled = true;
            //txtStatus.IsEnabled = true;
            //txtFacNum.IsEnabled = true;
            //txtYear.IsEnabled = true;
            //txtStream.IsEnabled = true;
            //txtGroup.IsEnabled = true;
        }

        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            BlockControls();
        }
        private void btnEnable_Click(object sender, RoutedEventArgs e)
        {
            EnableControls();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
        }
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            if (TestStudentsIfEmpty())
                CopyTestStudents();
        }
    }
}
