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
    public class GenResultsController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public async static Task<string> GetGenResults()
        {
            var guid = "ALMNH:ES";
            var catNum = 4;
            var url = Constants.baseApi + "?guid_prefix=" + guid + "&catnum=" + catNum;
            var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            return json;
        }
    }
}