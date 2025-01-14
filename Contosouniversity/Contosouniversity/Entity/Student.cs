﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contosouniversity.Entity
{
    public class Student
    {
        public int Id { get; set; }
        //[Required]
        [StringLength(50)]
        //[Display(Name ="Last Name")]
        public string LastName { get; set; }
        [StringLength(50)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        //[Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] //Displayformat istediğimiz şeyi açıkça ifade etmemize yarar
        //[Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        //[Display(Name = "Full Name")]
        //public string FullName
        //{
        //    get
        //    {
        //        return LastName + ", " + FirstMidName;
        //    }
        //}

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
