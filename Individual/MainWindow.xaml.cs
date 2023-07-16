using Individual.Model;
using Individual.View;
using Individual.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
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
namespace Individual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> STUDENTS { get; set; } = GetStudents();

        public MainWindow()
        {
            InitializeComponent();
            STUDENTS = GetStudents();
        }


        private void Close_App_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void open_add_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();

        }

        private void open_edit_Click(object sender, RoutedEventArgs e)
        {
            EditStudent editStudent = new EditStudent();
            editStudent.Show();
        }

        private void open_delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudent deleteStudent = new DeleteStudent();
            deleteStudent.Show();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }

        public static List<Student> GetStudents()
        {
            var list = new List<Student>();
            using (var ctx = new DataContext())
            {
                foreach (var p in ctx.Students)
                {
                    list.Add(p);
                }
            }
            return list;
        }
    }
}
