using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone_Museum.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Capstone_Museum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenResultsController : Controller
    {
        public IActionResult Index()
        {
            var json = GetGenResults();            
            return View(json);
        }
        public async static Task<GenResults.RootObject> GetGenResults()
        {
            var guid = "ALMNH:ES";
            var catNum = 4;
            var url = Constants.baseApi + "?guid_prefix=" + guid + "&catnum=" + catNum;
            var client = new HttpClient();
            string json = await client.GetStringAsync(url);
            var model = JsonConvert.DeserializeObject<GenResults.RootObject>(json);
            return model;
        }
    }
}