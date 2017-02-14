using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models.ViewModel
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext():base("name=StudentsDB")
        {

        }
        public Dbset<Students>Students { get; set; }
        public DbSet<Students> Courses { get; set; }

    }
}