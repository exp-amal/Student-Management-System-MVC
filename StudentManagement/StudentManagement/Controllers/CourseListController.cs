using StudentManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class CourseListController : Controller
    {
        //Listing Courses to view
        private StudentsDbContext db = new StudentsDbContext();
        // GET: CourseList
        public ActionResult CourseList()
        {
            return View(db.Courses.ToList());
        }
        //Edit course view controller
        public ActionResult EditCourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        //Edit list details displaying
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(Course course)
        {

            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("./CourseList/CourseList");

        }
        //HttpDeleteAttribute course controller
        public ActionResult DeleteCourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        //delete confirmation
        [HttpPost, ActionName("DeleteCourse")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourseConfirmed(int? id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();

            return RedirectToAction("./CourseList/CourseList");

        }
    }
}