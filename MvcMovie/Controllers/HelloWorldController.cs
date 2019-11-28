using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
            

        public string IndexToOne()
        {
            return "this is my defalt action...";
        }


        public string WelcomeToOne()
        {
            return "this is the welcome action method...";
        }

        // Requires using System.Text.Encodings.Web;
        public string WelcomeParameters(string name, int numTimes = 1)
        {
            string str = "" + name + ":NumTimes is :" + numTimes + "";
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes},String:{str}");
        }

        public string WelcomeParametersToOne(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }







    }
}