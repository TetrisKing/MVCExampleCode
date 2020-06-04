using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestNetFrameworkMVC.Models
{
    public class ApiStudent
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Secret { get; set; }
    }
}