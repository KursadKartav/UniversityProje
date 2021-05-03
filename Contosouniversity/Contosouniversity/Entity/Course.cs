using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contosouniversity.Entity
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Number")]
        public int CourseId { get; set; }
        [StringLength(50, MinimumLength =3)]
        public string Title { get; set; }
        [Range (0,5)]
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Display(Name ="Kursa Katılan Öğrenci Sayısı")]
        public int StudentsCount
        {
            get { return Enrollments == null ? 0: Enrollments.Count; }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignment { get; set; }
    }
}
