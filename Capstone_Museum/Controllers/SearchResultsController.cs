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
        public IActionResult PaleoIndex(GenResults.ResultObject resultObj)
        {
            //Console.WriteLine("In the search results controller");
            //string guidPrefix = formatPrefixes(resultObj);
            resultObj.GUID = formatGUIDs(resultObj, "ALMNH:Paleo");
            var json = GetGenResult(resultObj, "ALMNH:Paleo").Result; //results of the search
            List<GenResults.ResultObject> objList = new List<GenResults.ResultObject>();
            foreach (var item in json.DATA) //Creating a new object and passing the data from the json object for each item in the results list.
            {
                GenResults.ResultObject obj = new GenResults.ResultObject();
                obj.GUID = formatString(item[0].ToString());
                obj.sciName = formatString(item[1].ToString());
                String date = formatString(item[2].ToString());
                obj.Date = formatDate(date);
                if (date.Equals("no data")) date = "No Data";
                obj.Country = formatString(item[3].ToString());
                obj.State = formatString(item[4].ToString());
                if(obj.State != null && obj.Country != null)
                {
                    obj.State = obj.State + ", ";
                }
                obj.Locality = formatString(item[5].ToString());

                obj.Lat = item[7].Remove(0, 11);
                if (!obj.Lat.Equals("No Data") && !(obj.Lat.Equals("")) && !(obj.Lat.Equals(" ")) && !(obj.Lat.Equals("null")) && !(obj.Lat.Equals(" null")))
                {

                    double latNum = Convert.ToDouble(obj.Lat);
                    latNum = Math.Round(latNum, 5);
                    obj.Lat = latNum.ToString();
                    obj.Lat = "(" + obj.Lat + ",";
                }
                else obj.Lat = "";

                obj.Long = item[8].Remove(0, 12);

                if (!obj.Long.Equals("No Data") && !(obj.Lat.Equals(" ")) && !(obj.Lat.Equals("")) && !(obj.Long.Equals("null")) && !(obj.Long.Equals(" null")))
                {

                    double longNum = Convert.ToDouble(obj.Long);
                    longNum = Math.Round(longNum, 5);
                    obj.Long = longNum.ToString();
                    obj.Long = obj.Long + ")";
                }

                else obj.Long = "";
                obj.uncertaintyMeters = formatString(item[9].ToString());
                
                //uncertaintyMeters = sciName.Remove(uncertaintyMeters.Length - 1);
                //obj.csvURL = json.COLUMNS.Last();
                objList.Add(obj);
            }
            //if (resultObj.csv) ExportResults(objList);
            return View(objList);
        }
        public IActionResult LSIndex(GenResults.ResultObject resultObj)
        {
            Console.WriteLine("In the search results controller");
            string guidPrefix = formatPrefixes(resultObj);
            resultObj.GUID = formatGUIDs(resultObj, guidPrefix);

            var json = GetGenResult(resultObj, guidPrefix).Result; //results of the search
            List<GenResults.ResultObject> objList = new List<GenResults.ResultObject>();
            foreach (var item in json.DATA) //Creating a new object and passing the data from the json object for each item in the results list.

            {
                GenResults.ResultObject obj = new GenResults.ResultObject();
                obj.GUID = formatString(item[0].ToString());
                obj.sciName = formatString(item[1].ToString());
                String date = formatString(item[2].ToString());
                obj.Date = formatDate(date);
                if (date.Equals("no data")) date = "No Data";
                obj.Country = formatString(item[3].ToString());
                obj.State = formatString(item[4].ToString());
                if(obj.State.Length >= 2)
                {
                    
                    obj.State = obj.State + ", ";
                    Console.WriteLine(obj.State);
                }
                obj.Locality = formatString(item[5].ToString());

                obj.Lat = item[7].Remove(0, 11);
                if (!obj.Lat.Equals("No Data") && !(obj.Lat.Equals("")) && !(obj.Lat.Equals(" ")) && !(obj.Lat.Equals("null")))
                {

                    double latNum = Convert.ToDouble(obj.Lat);
                    latNum = Math.Round(latNum, 5);
                    obj.Lat = latNum.ToString();
                    obj.Lat = "(" + obj.Lat + ",";
                }
                else obj.Lat = "";

                obj.Long = item[8].Remove(0, 12);

                if (!obj.Long.Equals("No Data") && !(obj.Lat.Equals(" ")) && !(obj.Lat.Equals("")) && !(obj.Long.Equals("null")))
                {

                    double longNum = Convert.ToDouble(obj.Long);
                    longNum = Math.Round(longNum, 5);
                    obj.Long = longNum.ToString();
                    obj.Long = obj.Long + ")";
                }

                else obj.Long = "";
                obj.uncertaintyMeters = formatString(item[9].ToString());

                //uncertaintyMeters = sciName.Remove(uncertaintyMeters.Length - 1);
                //obj.csvURL = json.COLUMNS.Last();
                objList.Add(obj);
            }
            return View(objList);
        }
        public IActionResult EthnologyIndex(GenResults.ResultObject resultObj)
        {
            Console.WriteLine("In the search results controller");
            string guidPrefix = formatPrefixes(resultObj);
            resultObj.GUID = formatGUIDs(resultObj, "ALMNH:EH");
            var json = GetGenResult(resultObj, "ALMNH:EH").Result; //results of the search
            List<GenResults.ResultObject> objList = new List<GenResults.ResultObject>();
            foreach (var item in json.DATA) //Creating a new object and passing the data from the json object for each item in the results list.
            {
                GenResults.ResultObject obj = new GenResults.ResultObject();
                obj.GUID = formatString(item[0].ToString());
                obj.sciName = formatString(item[1].ToString());
                String date = formatString(item[2].ToString());
                obj.Date = formatDate(date);
                if (date.Equals("no data")) date = "No Data";
                obj.Country = formatString(item[3].ToString());
                obj.State = formatString(item[4].ToString());
                if (obj.State != null && obj.Country != null && obj.State != " ")
                {
                    obj.State = obj.State + ", ";
                }
                obj.Locality = formatString(item[5].ToString());

                obj.Lat = item[7].Remove(0, 11);
                if (!obj.Lat.Equals("No Data") && !(obj.Lat.Equals("")) && !(obj.Lat.Equals(" ")) && !(obj.Lat.Equals("null")))
                {

                    double latNum = Convert.ToDouble(obj.Lat);
                    latNum = Math.Round(latNum, 5);
                    obj.Lat = latNum.ToString();
                    obj.Lat = "(" + obj.Lat + ",";
                }
                else obj.Lat = "";

                obj.Long = item[8].Remove(0, 12);

                if (!obj.Long.Equals("No Data") && !(obj.Lat.Equals(" ")) && !(obj.Lat.Equals("")) && !(obj.Long.Equals("null")))
                {

                    double longNum = Convert.ToDouble(obj.Long);
                    longNum = Math.Round(longNum, 5);
                    obj.Long = longNum.ToString();
                    obj.Long = obj.Long + ")";
                }

                else obj.Long = "";
                obj.uncertaintyMeters = formatString(item[9].ToString());

                //uncertaintyMeters = sciName.Remove(uncertaintyMeters.Length - 1);
                //obj.csvURL = json.COLUMNS.Last();
                objList.Add(obj);
            }
            return View(objList);
        }
        //Pulls data from the arctos SpecimenResults APIs and feeds the class of lists
        public async static Task<GenResults.RootObject> GetGenResult(GenResults.ResultObject resultObject, String guidPrefix)
        {
            using (HttpClient client = new HttpClient())
            {

                Console.WriteLine("In the search results controller");
                String guidPrefixes = formatPrefixes(resultObject);
                if (!(resultObject.guidStart == null) && !(resultObject.guidEnd == null))
                {
                    for (int i = Int32.Parse(resultObject.guidStart); i <= Int32.Parse(resultObject.guidEnd); i++)
                    {
                        resultObject.GUID = resultObject.GUID+ formatGUIDs(i.ToString(), guidPrefixes);
                    }
                }
                
                resultObject.begin_month = monthToNumber(resultObject.begin_month);
                resultObject.end_month = monthToNumber(resultObject.end_month);
                if (resultObject.begin_year != null) resultObject.begin_year = resultObject.begin_year + "-";
                if (resultObject.end_year != null) resultObject.end_year = resultObject.end_year + "-";

                //resultObject.GUID = resultObject.GUID.Remove(resultObject.GUID.Length - 1);
                //+"&phylum="+resultObject.Phylum+"&phylclass="+resultObject.Class+"&phylorder="+resultObject.Order+"&family="+resultObject.Family
                var url = "https://arctos.database.museum/component/api/v1/catalog.cfc?method=getCatalogData&api_key=03D9E9AF-A1E7-4AA1-A9C0AE5880AE7779&guid_prefix=" + guidPrefix + "&guid=" + resultObject.GUID+"&scientific_name="+resultObject.sciName+"&spec_locality="+resultObject.Locality+"&kingdom="+resultObject.Kingdom+"&phylum="+resultObject.Phylum+"&phylclass="+resultObject.Class+"&phylorder="+resultObject.Order+"&family="+resultObject.Family+"&genus="+resultObject.Genus+"&species="+resultObject.Species+"&subspecies="+resultObject.Subspecies+"&country="+resultObject.Country+"&state_prov="+resultObject.State+"&continent_ocean="+resultObject.Continent_Ocean+"&begin_made_date="+resultObject.begin_year+resultObject.begin_month+resultObject.begin_day+ "&end_made_date=" + resultObject.end_year + resultObject.end_month + resultObject.end_day + "&age="+resultObject.age+"&ageClass="+resultObject.ageClass+"&common_name="+resultObject.commonName+"&county="+resultObject.County+"&cols=made_date&pgsz=1000"; //URL for the API
                //Console.WriteLine("In search results controller:" + resultObject.commonName);
                var response = await client.GetStringAsync(url); //return object
                var json = JObject.Parse(response); //seperating the object
                GenResults.RootObject retObj = new GenResults.RootObject();
                var columns = json.SelectToken("qrycols");
                List<string> cList = new List<string>();
                foreach (var c in columns) //creating a list of the column names
                {
                    var cString = c.ToString();
                    cList.Add(cString);
                    cList.Add(url);
                }
                retObj.COLUMNS = cList;
                var data = json.SelectToken("Records");
                List<List<string>> dList = new List<List<string>>();
                foreach (var item in data)//creating a list of list of object data
                {
                    List<string> dVar = new List<string>();
                    foreach (var xItem in item)
                    {
                        var dString = xItem.ToString();
                        //if (dString.Length > 19 && dString.Substring(0,18).Equals("\"scientific_name\":")) dString = dString.Remove(0,18);
                        dVar.Add(dString);

                    }
                    dList.Add(dVar);
                }
                retObj.DATA = dList;
                return retObj;
            }
        }

        public static String formatPrefixes(GenResults.ResultObject resultObj)
        {
            String guidPrefixes = "";
            int comma = 0;
            if (resultObj.invertebrates) guidPrefixes = guidPrefixes + "ALMNH:Inv"; comma = 1;
            if (resultObj.mammal && comma == 1) guidPrefixes = guidPrefixes + ",ALMNH:Mamm";
            else if (resultObj.mammal) guidPrefixes = guidPrefixes + "ALMNH:Mamm"; comma = 1;
            if (resultObj.ento && comma == 1) guidPrefixes = guidPrefixes + ",ALMNH:Ento";
            else if (resultObj.ento) guidPrefixes = guidPrefixes + "ALMNH:Ento"; comma = 1;
            if (resultObj.herp && comma == 1) guidPrefixes = guidPrefixes + ",ALMNH:Herp";
            else if (resultObj.herp) guidPrefixes = guidPrefixes + "ALMNH:Herp"; comma = 1;
            if (resultObj.bird && comma == 1) guidPrefixes = guidPrefixes + ",ALMNH:Bird";
            else if (resultObj.bird) guidPrefixes = guidPrefixes + "ALMNH:Bird"; comma = 1;

            return guidPrefixes;
        }
        public static String formatGUIDs(GenResults.ResultObject resultObj, string guidPrefixes)
        {
            if (!(resultObj.GUID == null))
            {
                String fGUID = "";
                int commaCount = 0;
                for (int i = 0; i < guidPrefixes.Length; i++)
                {
                    if (guidPrefixes[i].Equals(',')) commaCount++;
                }
                var temp = guidPrefixes.Split(",");
                if (temp.Length > 1)
                {
                    for (int i = 0; i <= commaCount; i++)
                    {
                        fGUID = fGUID + temp[i] + ":" + resultObj.GUID + ",";
                    }
                }
                else fGUID = temp[0] + ":" + resultObj.GUID;
                return fGUID;
            }
            return resultObj.GUID;   
        }
        public static String formatGUIDs(string number, string guidPrefixes)
        {
            
                String fGUID = "";
                int commaCount = 0;
                for (int i = 0; i < guidPrefixes.Length; i++)
                {
                    if (guidPrefixes[i].Equals(',')) commaCount++;
                }
                var temp = guidPrefixes.Split(",");
                if (temp.Length > 1)
                {
                    for (int i = 0; i <= commaCount; i++)
                    {
                        fGUID = fGUID + temp[i] + ":" + number + ",";
                    }
                }
                else fGUID = temp[0] + ":" + number;
                return fGUID;
            
            
        }
        public static string monthToNumber(string month)
        {
            switch (month)
            {
                case "January":
                    return "01-";
                case "February":
                    return "02-";
                case "March":
                    return "03-";
                case "April":
                    return "04-";
                case "May":
                    return "05-";
                case "June":
                    return "06-";
                case "July":
                    return "07-";
                case "August":
                    return "08-";
                case "September":
                    return "09-";
                case "October":
                    return "10-";
                case "November":
                    return "11-";
                case "December":
                    return "12-";


            }
            return null;
        }
        public String formatString(String orig)
        {
            String fString;
            int len = orig.Length;
            if (orig.Substring(len - 4).Equals("null"))
            {
                return " ";
            }
            var temp = orig.Split("\":");
            fString = temp[1];
            fString = fString.Remove(fString.Length - 1);
            fString = fString.Remove(0, 2);

            return fString;
        }
        public String formatDate(String date)
        {
            String fDate = date;
            if (date.Length >= 3)
            {
                if ((!(Char.IsNumber(date[1])) || !(Char.IsNumber(date[2]))) && Char.IsNumber(date[3]))
                {

                    switch (date[0])
                    {
                        case '1':
                            fDate = "Jan" + date.Substring(1);
                            break;
                        case '2':
                            fDate = "Feb" + date.Substring(1);
                            break;
                        case '3':
                            fDate = "Mar" + date.Substring(1);
                            break;
                        case '4':
                            fDate = "Apr" + date.Substring(1);
                            break;
                        case '5':
                            fDate = "May" + date.Substring(1);
                            break;
                        case '6':
                            fDate = "Jun" + date.Substring(1);
                            break;
                        case '7':
                            fDate = "Jul" + date.Substring(1);
                            break;
                        case '8':
                            fDate = "Aug" + date.Substring(1);
                            break;
                        case '9':
                            fDate = "Sep" + date.Substring(1);
                            break;
                    }
                    switch (date.Substring(0, 2))
                    {
                        case "01":
                            fDate = "Jan" + date.Substring(2);
                            break;
                        case "02":
                            fDate = "Feb" + date.Substring(2);
                            break;
                        case "03":
                            fDate = "Mar" + date.Substring(2);
                            break;
                        case "04":
                            fDate = "Apr" + date.Substring(2);
                            break;
                        case "05":
                            fDate = "May" + date.Substring(2);
                            break;
                        case "06":
                            fDate = "Jun" + date.Substring(2);
                            break;
                        case "07":
                            fDate = "Jul" + date.Substring(2);
                            break;
                        case "08":
                            fDate = "Aug" + date.Substring(2);
                            break;
                        case "09":
                            fDate = "Sep" + date.Substring(2);
                            break;
                        case "10":
                            fDate = "Oct" + date.Substring(2);
                            break;
                        case "11":
                            fDate = "Nov" + date.Substring(2);
                            break;
                        case "12":
                            fDate = "Dec" + date.Substring(2);
                            break;
                    }
                }
                if (Char.IsNumber(date[0]) && Char.IsNumber(date[1]) && Char.IsNumber(date[2]) && Char.IsNumber(date[3]) && date.Length > 7)
                {
                    switch (date.Substring(5, 2))
                    {
                        case "01":
                            fDate = date.Substring(0, 5) + "Jan" + date.Substring(7);
                            break;
                        case "02":
                            fDate = date.Substring(0, 5) + "Feb" + date.Substring(7);
                            break;
                        case "03":
                            fDate = date.Substring(0, 5) + "Mar" + date.Substring(7);
                            break;
                        case "04":
                            fDate = date.Substring(0, 5) + "Apr" + date.Substring(7);
                            break;
                        case "05":
                            fDate = date.Substring(0, 5) + "May" + date.Substring(7);
                            break;
                        case "06":
                            fDate = date.Substring(0, 5) + "Jun" + date.Substring(7);
                            break;
                        case "07":
                            fDate = date.Substring(0, 5) + "Jul" + date.Substring(7);
                            break;
                        case "08":
                            fDate = date.Substring(0, 5) + "Aug" + date.Substring(7);
                            break;
                        case "09":
                            fDate = date.Substring(0, 5) + "Sep" + date.Substring(7);
                            break;
                        case "10":
                            fDate = date.Substring(0, 5) + "Oct" + date.Substring(7);
                            break;
                        case "11":
                            fDate = date.Substring(0, 5) + "Nov" + date.Substring(7);
                            break;
                        case "12":
                            fDate = date.Substring(0, 5) + "Dec" + date.Substring(7);
                            break;
                    }
                }
            }
            return fDate;
        }

        public String removeCommas(String commaString)
        {
            int len = commaString.Length;
            for (int i = 0; i < len; i++)
            {
                if (commaString[i].Equals(','))
                {
                    commaString = commaString.Remove(i, 1);
                    len--;
                }
            }
            return commaString;
        }

        
        //Exports the result list to a csv file
        /*public IActionResult*/
        public IActionResult ExportResults(String sb)
        {
            
            
            return File(new UTF8Encoding().GetBytes(sb), "text/csv", "ExportResults.csv");

        }

    }
}
