using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_Museum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_Museum.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index(SearchModel searchModel)
        {
            return View();
        }
    }
}