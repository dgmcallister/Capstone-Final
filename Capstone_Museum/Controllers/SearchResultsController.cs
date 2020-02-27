using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_Museum.Controllers
{
    public class SearchResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}