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
    /// Interaction logic for EditTheStudent.xaml
    /// </summary>
    public partial class EditTheStudent : Window
    {
        
        public EditTheStudent()
        {

            InitializeComponent();

            

           // using (ViewModel.DataContext context = new ViewModel.DataContext())
           // {

                //var students = context.Student.ToList(); //adding the students into a list to search for the registration number
                //var regNumToRemove = int.Parse(ID.Text);     //getting the registration number from the textbox
                //var toremove = students.Find(x => x.Id == regNumToRemove);//finding and adding the student to remove, to the variable "toremove"

                //SFirstName.Text = toremove.SFirstName;
                //SSecondName.Text = toremove.SSecondName;
                ////SGPA.Text = toremove.SGPA;
                //SDateOfBirth.Text = toremove.SDateOfBirth;


           // }
        }
        private void editTheStudent_Click(object sender, RoutedEventArgs e)
        {
            var id = int.Parse(EditStudent.instance.tb.Text);

            using (ViewModel.DataContext context = new ViewModel.DataContext())
            {
                var students = context.Students.ToList(); //adding the students into a list to search for the registration number
                                                          //getting the registration number from the textbox
                var toremove = students.Find(x => x.Id == id);//finding and adding the student to remove, to the variable "toremove"


                context.Remove(toremove);
                context.SaveChanges();

            }


            using (ViewModel.DataContext context = new ViewModel.DataContext())
            {
                //craete the model properties
                
                var SFname = SFirstName.Text;
                var SSName = SSecondName.Text;
                var Sgpa = SGPA.Text;
                var SDoB = SDateOfBirth.Text;
                

                //checck

                if (SFname != null && SSName != null && Sgpa != null && SDoB != null)
                {
                    context.Students.Add(new Model.Student()

                    {
                        Id = id,
                        SFirstName = SFname,
                        SSecondName = SSName,
                        SGPA = Sgpa,
                        SDateOfBirth = SDoB
                    });

                    context.SaveChanges();

                    SFirstName.Text = null;
                    SSecondName.Text = null;
                    SGPA.Text = null;
                    SDateOfBirth.Text = null;

                    MessageBox.Show("Added the details sucessfull!");
                }

                else
                {
                    MessageBox.Show("Fill All the feilds");
                }

            }
        }

        private void Close_App_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
