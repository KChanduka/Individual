using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media.Imaging;

namespace Individual.Model
{
    public class Student
    {
        [Key]
        public int Id{ get; set; }
        public string? SFirstName{ get; set; }
        public string? SSecondName{ get; set; }

        public string? SGPA{ get; set; }

        public string? SDateOfBirth{ get; set; }

        //public String ImagePath { get; set; }

    }
}