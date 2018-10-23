using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Super_Service.Pages
{
    public class startPageModel : PageModel
    {
        public string Message { get; private set; } = "PageModel";
        public void OnGet()
        {
            Message = "";
        }
    }
}