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
using System.IO;
using System.Text;
using CsvHelper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone_Museum.Controllers
{
    public class SearchResultsController : Controller
    {
        //Sends the API results to be formmated for results
        public IActionResult Index(SearchModel searchModel)
        {
            var json = GetGenResults().Result; //results of the search
            List<GenResults.ResultObject> objList = new List<GenResults.ResultObject>();
            foreach (var item in json.DATA) //Creating a new object and passing the data from the json object for each item in the results list.
            {
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
                obj.csvURL = json.COLUMNS.Last();
                objList.Add(obj);
            }
            return View(objList);
        }
        //Pulls data from the arctos SpecimenResults APIs and feeds the class of lists
        public async static Task<GenResults.RootObject> GetGenResults()
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://arctos.database.museum/SpecimenResultsJSON.cfm?guid_prefix=ALMNH:ES&catnum=1-75"; //URL for the API
                var response = await client.GetStringAsync(url); //return object
                var json = JObject.Parse(response); //seperating the object
                GenResults.RootObject retObj = new GenResults.RootObject();
                var columns = json.SelectToken("COLUMNS");
                List<string> cList = new List<string>();
                foreach (var c in columns) //creating a list of the column names
                {
                    var cString = c.ToString();
                    cList.Add(cString);
                    cList.Add(url);
                }
                retObj.COLUMNS = cList;
                var data = json.SelectToken("DATA");
                List<List<string>> dList = new List<List<string>>();
                foreach (var item in data)//creating a list of list of object data
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

        //Exports the result list to a csv file
        public IActionResult ExportResults()
        {
            var json = GetGenResults().Result; //results of the search
            List<GenResults.ResultObject> objList = new List<GenResults.ResultObject>();
            foreach (var item in json.DATA) //Creating a new object and passing the data from the json object for each item in the results list.
            {
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
                obj.csvURL = json.COLUMNS.Last();
                objList.Add(obj);
            }
            var sb = new StringBuilder();
            foreach (var item in objList)
            {
                sb.AppendLine(item.objectId + "," + item.GUID + "," + item.sciName + "," + item.Country + "," + item.State + "," + item.Locality + "," +
                    item.Date + "," + item.Lat + "," + item.Long + "," + item.uncertaintyMeters + "," + item.Kingdom + "," + item.Kingdom + "," + item.Phylum
                     + "," + item.Class + "," + item.Order + "," + item.Family + "," + item.subfamily + "," + item.Genus + "," + item.commonName + "," +
                     item.idBy + "," + item.natureOfId + "," + item.Remarks);
            }
            return File(new UTF8Encoding().GetBytes(sb.ToString()), "text/csv", "ExportResults.csv");
            
        }
    }
}
