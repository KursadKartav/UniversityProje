using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contosouniversity.Entity
{
    public class CourseAssignment
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
