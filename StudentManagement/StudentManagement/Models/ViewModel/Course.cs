using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models.ViewModel
{
    //model for course
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        List<Student> Students { get; set; }
    }
}