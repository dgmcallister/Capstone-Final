using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone_Museum.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Capstone_Museum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenResultsController : Controller
    {
        public IActionResult Index()
        {
            var json = GetGenResults().Result;
            //List<GenResults.ResultObject> objList = new List<GenResults.ResultObject>();
            //foreach (var item in json.DATA)
            //{
            //    GenResults.ResultObject obj = new GenResults.ResultObject();
            //    obj.objectId = item[0].ToString();
            //    obj.GUID = item[1].ToString();
            //    obj.sciName = item[2].ToString();
            //    obj.Country = item[3].ToString();
            //    obj.State = item[4].ToString();
            //    obj.Locality = item[5].ToString();
            //    obj.Date = item[6].ToString();
            //    obj.Lat = item[7].ToString();
            //    obj.Long = item[8].ToString();
            //    obj.uncertaintyMeters = item[9].ToString();
            //    objList.Add(obj);

            //}
            return View(json);
        }
        public async static Task<String> GetGenResults()
        {
            var guid = "ALMNH:ES";
            var catNum = 12;
            var url = Constants.baseApi + "?guid_prefix=" + guid + "&catnum=" + catNum;
            using (HttpClient client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                var j2 = JObject.Parse(json);
                return j2;
            }

        }
    }
}