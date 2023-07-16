using Individual.Model;
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
using System.Windows.Shapes;

namespace Individual.View
{
    /// <summary>
    /// Interaction logic for DeleteStudent.xaml
    /// </summary>
    public partial class DeleteStudent : Window
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void Close_App_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public List<Student>? students { get; private set; }

        private void removeTheStudent_Click(object sender, RoutedEventArgs e)
        {
            using (ViewModel.DataContext context = new ViewModel.DataContext())
            {
                students = context.Students.ToList(); //adding the students into a list to search for the registration number
                int regNumToRemove = int.Parse(ID.Text);     //getting the registration number from the textbox
                var toremove = students.Find(x => x.Id == regNumToRemove);//finding and adding the student to remove, to the variable "toremove"


                if (toremove != null)
                {

                   
                    context.Remove(toremove);
                    context.SaveChanges();
                    MessageBox.Show("removed succesfully");

                }
                else
                {
                    MessageBox.Show("Invalid Student ID ");
                }
            }

        }
    }
}
