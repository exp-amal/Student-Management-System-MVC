using StudentManagement.Models.ViewModel;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class CreateStudentController : Controller
    {
        //Student create controller
        private StudentsDbContext db = new StudentsDbContext();
        // GET: CreateStudent
        public ActionResult CreateStudent()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }
        //updating new Student details to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("../StudentsList/StudentsList");

            }

            return RedirectToAction("CreateStudent/CreateStudent");
        }
        }
}