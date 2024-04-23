using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Data;
using SchoolApplication.Models;

namespace SchoolApplication.Controllers
{
    public class StudentInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentInfoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var studentInfo = _context.Students.ToList();
            return View(studentInfo);
        }

        /*[HttpGet]*/
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(AddStudent), student);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var studentInfo = _context.Students.FirstOrDefault(x => x.Id == id);
            return View(studentInfo);
        }
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            var studentInfo = _context.Students.FirstOrDefault(x => x.Id == student.Id);
            studentInfo.rollNumber = student.rollNumber;
            studentInfo.className = student.className;
            studentInfo.email = student.email;
            studentInfo.phone = student.phone;
            _context.Update(studentInfo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveStudent(int id)
        {
            var studentInfo = _context.Students.FirstOrDefault(x => x.Id == id);
            _context.Remove(studentInfo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddAndEditStudent(int id)
        {
            Student student = new Student();
            if(id > 0)
            {
                student = _context.Students.FirstOrDefault(x => x.Id == id);
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult AddAndEditStudent(Student student)
        {
            /*Student student = new Student();*/
            if (student.Id == 0)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(AddStudent), student);
            }
            else
            {
                var studentInfo = _context.Students.FirstOrDefault(x => x.Id == student.Id);
                studentInfo.rollNumber = student.rollNumber;
                studentInfo.className = student.className;
                studentInfo.email = student.email;
                studentInfo.phone = student.phone;
                _context.Update(studentInfo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }

    }
}
