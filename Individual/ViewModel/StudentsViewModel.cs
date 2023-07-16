using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Individual.Model;

#nullable disable
namespace Individual.ViewModel
{
    public partial class StudentsViewModel:ObservableObject
    {
        [ObservableProperty]
        public string sfirstName;
        [ObservableProperty]
        public string ssecondName;
        [ObservableProperty]
        public string sgpa;
        [ObservableProperty]
        public string sdateOfBirth;

        [ObservableProperty]
        ObservableCollection<Student> students;

        [RelayCommand]

        public void InsertStudent()
        {
            Student s = new Student();
            {
                SfirstName = SfirstName;  //variables defined under observable poperties, when generated after calling the constructor,the new variables start with a capital letter first
                                          //for example  "sfistName" is declared above,when generated it has the name "SfirstName" where the first letter is capital
                SsecondName = SsecondName;
                Sgpa = Sgpa;
                SdateOfBirth = SdateOfBirth;


            };
            using (var db = new DataContext())
            {
                db.Students.Add(s);
                db.SaveChanges();
            }

            LoadStudent();
        }

        public void LoadStudent()
        {
            using (var db = new DataContext())
            {
                var list = db.Students.OrderByDescending(s => SfirstName).ToList();
                Students = new ObservableCollection<Student>(list);
            }

        }

        public StudentsViewModel()
        {
            LoadStudent();
        }


    }
}
