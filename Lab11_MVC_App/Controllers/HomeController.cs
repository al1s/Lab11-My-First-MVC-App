using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11_MVC_App.Models;

namespace Lab11_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Default handler for GET-method of the /index endpoint
        /// </summary>
        /// <returns>Default view</returns>
        public ViewResult Index()
        {
            return View();
        }
        /// <summary>
        /// Handler for POST requests to the /index endpoint
        /// </summary>
        /// <param name="startYear">The first year to filter data</param>
        /// <param name="endYear">The last year to filter data</param>
        /// <returns>Redirect to result page</returns>
        [HttpPost]
        public RedirectToActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Result", new { startYear, endYear });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns>View filtered by start, end years</returns>
        public ViewResult Result(int startYear, int endYear)
        {
            List<PersonOfYear> persons = PersonOfYear.GetPersons(startYear, endYear);
            return View(persons);
        }
    }
}