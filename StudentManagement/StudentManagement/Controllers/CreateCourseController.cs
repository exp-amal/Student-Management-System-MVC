using StudentManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class CreateCourseController : Controller
    {
        //Course create controller
        private StudentsDbContext db = new StudentsDbContext();
        // GET: CreateCourse
        public ActionResult CreateCourse()
        {


            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View();
        }

        //updating database with new course details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("../CourseList/CourseList");
        }
    }
    
}