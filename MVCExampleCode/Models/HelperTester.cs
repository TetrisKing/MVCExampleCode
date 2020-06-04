using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExampleCode.Models
{
    public enum Food {
        Chicken,
        Beef,
        Pork
    }
    public class HTMLHelperExampleData
    {
        public int ID { get; set; }
        public bool checkbox { get; set; }
        public Food enumDropDown { get; set; }

        public IEnumerable<string> arrayDances { get; set; }
        public string selectedDance { get; set; }

        public string stringInput { get; set; }
        public DateTime dateInput { get; set; }
    }
}