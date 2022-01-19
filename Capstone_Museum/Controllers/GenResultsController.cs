using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone_Museum.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Capstone_Museum.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class GenResultsController : Controller {
		public IActionResult Index() {
			Console.WriteLine("in gen results controller");
			var json = GetGenResults().Result;
			List<GenResults.ResultObject> objList = new List<GenResults.ResultObject>();
			foreach (var item in json.DATA) {
				GenResults.ResultObject obj = new GenResults.ResultObject();
				obj.objectId = item[0].ToString();
				obj.GUID = item[1].ToString();
				obj.sciName = item[2].ToString();
				obj.Country = item[3].ToString();
				obj.State = item[4].ToString();
				obj.Locality = item[5].ToString();
				obj.Date = item[6].ToString();
				obj.Lat = item[7].ToString();
				obj.Long = item[8].ToString();
				obj.uncertaintyMeters = item[9].ToString();
				objList.Add(obj);
			}
			return View(objList);
		}

		//Pulls data from the arctos SpecimenResults APIs and feeds the class of lists
		public async static Task<GenResults.RootObject> GetGenResults() {
			using (HttpClient client = new HttpClient()) {
				var url = "https://arctos.database.museum/SpecimenResultsJSON.cfm?guid_prefix=ALMNH:ES&catnum=12-15";
				var response = await client.GetStringAsync(url);
				var json = JObject.Parse(response);
				GenResults.RootObject retObj = new GenResults.RootObject();
				var columns = json.SelectToken("COLUMNS");
				List<string> cList = new List<string>();
				foreach (var c in columns) {
					var cString = c.ToString();
					cList.Add(cString);
				}
				retObj.COLUMNS = cList;
				var data = json.SelectToken("DATA");
				List<List<string>> dList = new List<List<string>>();
				foreach (var item in data) {
					List<string> dVar = new List<string>();
					foreach (var xItem in item) {
						var dString = xItem.ToString();
						dVar.Add(dString);
					}
					dList.Add(dVar);
				}
				retObj.DATA = dList;
				return retObj;
			}
		}
	}
}