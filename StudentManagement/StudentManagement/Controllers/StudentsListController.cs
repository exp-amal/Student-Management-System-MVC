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
    public class StudentsListController : Controller
    {

        private StudentsDbContext db = new StudentsDbContext();
        // GET: StudentsList
        //View students list controller
        public ActionResult StudentsList()
        {
            var student = db.Students.Include(s => s.course);
            return View(student.ToList());
            
        }      
        //edit student controller
        public ActionResult EditStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = db.Students.Find(id);

            

            if (student == null)
            {
                return HttpNotFound();
            }

            var age = DateTime.Now.Year - student.DateOfBirth.Year;

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", student.CourseId );
            ViewBag.Age = age;
            return View(student);
        }
        //edit details controller
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(Student student)
        {
                  
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("./StudentsList/StudentsList");
           
        }
        //delete students controller
        public ActionResult DeleteStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        //delete confirmation controller
        [HttpPost, ActionName("DeleteStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudentConfirmed(int? id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            
            return RedirectToAction("./StudentsList/StudentsList");

        }
        //metod count number of students enrolled in a course
        public int CountOfStudents(int CourseId)
        {
            var student = db.Students.Include(counts => counts.course);
            var s = student.ToList();
            int count = s.Count(c => c.CourseId == CourseId);
            return count;
        }
    }
}