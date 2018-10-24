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
            ViewBag.lstCompanies = new List<Company>();
            ViewBag.lstCompanies = DB.GetCompanies(zipCode, city);
            
            //ViewBag.lstCompanies = new MultiSelectList(result, "CompanyName", "Address", "ZipCode");
            /*foreach (var item in result)
            {
                ViewBag.lstCompanies += $"Firma: {item.CompanyName}, {item.Address}, {item.ZipCode}";
            }*/
            //ViewBag.lstCompanies = result;
            return View();
        }

        public IActionResult CreateHairdresser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHairdresser(string companyName, string address, int zipCode, string city)
        {
            DB.PostCompany(companyName, address, zipCode, city);
            
            return View();
        }
    }
}