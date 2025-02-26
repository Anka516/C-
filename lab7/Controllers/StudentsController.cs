using Microsoft.AspNetCore.Mvc;
using SchoolGradesAPI.Models;

namespace SchoolGradesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Иван", Grades = new List<Grade> { new Grade { Subject = "Математика", Score = 5 } } },
            new Student { Id = 2, Name = "Мария", Grades = new List<Grade> { new Grade { Subject = "Физика", Score = 4 } } },
            new Student { Id = 3, Name = "Алексей", Grades = new List<Grade> { new Grade { Subject = "Химия", Score = 3 } } }
        };

        [HttpGet]
        public ActionResult<List<Student>> Get() => students;

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student == null)
                return NotFound();
            return student;
        }

        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var existingStudent = students.Find(s => s.Id == id);
            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.Name;
            existingStudent.Grades = student.Grades;
            return NoContent();
        }
    }
}
