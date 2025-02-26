using System.Diagnostics;

namespace SchoolGradesAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();
    }
}