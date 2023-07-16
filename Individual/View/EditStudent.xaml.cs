using Individual;
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
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {

        public static EditStudent instance;
        public TextBox tb;
        public EditStudent()
        {
            InitializeComponent();
            instance = this;
            tb = ID;
        }
        private void Close_App_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void goto_editTheStudent_Click(object sender, RoutedEventArgs e)
        {
            using (ViewModel.DataContext context = new ViewModel.DataContext())
            {

                var students = context.Students.ToList(); //adding the students into a list to search for the registration number
                var regNumToRemove = int.Parse(ID.Text);     //getting the registration number from the textbox
                var toremove = students.Find(x => x.Id == regNumToRemove);//finding and adding the student to remove, to the variable "toremove"
                
                if (toremove != null)
                {

                    EditTheStudent editTheStudent = new EditTheStudent();
                    editTheStudent.Show();
                    Close();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Registration Number ");
                }


            }

           


        }
        

    }
}