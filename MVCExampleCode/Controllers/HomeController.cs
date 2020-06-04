using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestNetFrameworkMVC.Models;

namespace TestNetFrameworkMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HTMLHelperExamples()
        {
            HTMLHelperExampleData model = new HTMLHelperExampleData() { 
                ID = 1, 
                checkbox = true, 
                enumDropDown = Food.Beef, 
                arrayDances = new[] { "Tango", "Bool", "Smurf" }, selectedDance = "Smurf"                
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult HTMLHelperExamples(HTMLHelperExampleData data)
        {
            return View(data);
        }
    }
}