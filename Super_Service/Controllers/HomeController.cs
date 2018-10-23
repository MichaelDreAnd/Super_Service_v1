using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Super_Service.Models;

namespace Super_Service.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(int zipCode, string city)
        {
            List<Company> result = DB.GetCompanies(zipCode, city);
            ViewBag.lstCompanies = new MultiSelectList(result, "CompanyName", "Address", "ZipCode");
            //ViewBag.Result = result;
            //ViewBag.Result = $"{zipCode} + {city} = {result}";
            return View();
        }

        public IActionResult CreateHairdresser()
        {
            return View();
        }
    }
}