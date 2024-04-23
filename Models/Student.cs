using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models
{
    public class Student
    {
       [Key]
        public int Id { get; set; }
    /*    public string name { get; set; }*/
        public int rollNumber { get; set; }
        public int className { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

    }
}
