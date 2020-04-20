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

namespace Capstone_Museum.Controllers
{
    public class DetailsController : Controller
    {
        //Same Info call as the search results but for a specific item//
        public IActionResult Index(string GUID)
        {
            var json = GetResults(GUID).Result;
            GenResults.ResultObject obj = new GenResults.ResultObject();
            obj.objectId = json.DATA[0][0].ToString();
            obj.GUID = json.DATA[0][1].ToString();
            obj.sciName = json.DATA[0][2].ToString();
            obj.Country = json.DATA[0][3].ToString();
            obj.State = json.DATA[0][4].ToString();
            obj.Locality = json.DATA[0][5].ToString();
            obj.Date = json.DATA[0][6].ToString();
            obj.Lat = json.DATA[0][7].ToString();
            obj.Long = json.DATA[0][8].ToString();
            obj.uncertaintyMeters = json.DATA[0][9].ToString();
            if(!String.IsNullOrEmpty(obj.Lat))
            {
                obj.mapLat = decimal.Parse(obj.Lat);
                obj.mapLong = decimal.Parse(obj.Long);
            }            
            return View(obj);
        }
        public async static Task<GenResults.RootObject> GetResults(string GUID)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://arctos.database.museum/SpecimenResultsJSON.cfm?guid=" + GUID;
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);
                GenResults.RootObject retObj = new GenResults.RootObject();
                var columns = json.SelectToken("COLUMNS");
                List<string> cList = new List<string>();
                foreach (var c in columns)
                {
                    var cString = c.ToString();
                    cList.Add(cString);
                }
                retObj.COLUMNS = cList;
                var data = json.SelectToken("DATA");
                List<List<string>> dList = new List<List<string>>();
                foreach (var item in data)
                {
                    List<string> dVar = new List<string>();
                    foreach (var xItem in item)
                    {
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