﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCExampleCode.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstMidName { get; set; }
        
        public DateTime EnrollmentDate { get; set; }
        public string Secret { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}