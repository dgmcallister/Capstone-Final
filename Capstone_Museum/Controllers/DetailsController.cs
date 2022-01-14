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

//Controller for the individual search results pages ie: What shows up when you search and then click on a reuslt

namespace Capstone_Museum.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index(string GUID)
        {
            //Parsing the database results into their respective fields.

            var json = GetResults(GUID).Result;
            GenResults.ResultObject obj = getData(json);
            return View(obj);
        }
        public IActionResult LifeScienceView(string GUID)
        {
            //Parsing the database results into their respective fields.

            var json = GetResults(GUID).Result;
            GenResults.ResultObject obj = getData(json);
            return View(obj);
        }
        public IActionResult historyEthView(string GUID)
        {
            //Parsing the database results into their respective fields.

            var json = GetResults(GUID).Result;
            GenResults.ResultObject obj = getData(json);
            return View(obj);
        }

        public String[] formatMedia(String media)
        {
            var temp = media.Split(":\\");
            int i = 0;
            int index = 0;
            String[] imageURLs = new string[100];
            String fMedia;
            if (temp.Length > 1)
            {
                while (4*i+3 < temp.Length)
                {
                    if (temp[4 * i + 1][1].Equals('i'))
                    {
                        fMedia = temp[4 * i + 3];
                        var temp2 = fMedia.Split("\\");
                        String ffMedia = temp2[0].Remove(0, 1);
                        imageURLs[index] = ffMedia;
                    }
                    else
                    {
                        fMedia = "css/pictures/pdf-available.png";
                        imageURLs[index] = fMedia;
                    }
                        i++;
                    index++;
                }
            }
            else imageURLs[0] = "css/pictures/No_image_available.png";
            return imageURLs;
        }
        public String[] formatLinkedURL(String media)
        {
            var temp = media.Split(":\\");
            int i = 0;
            int index = 0;
            String[] imageURLs = new string[100];
            String fMedia;
            if (temp.Length > 1)
            {
                while (4 * i + 3 < temp.Length)
                {
                    if (temp[4 * i + 1][1].Equals('i'))
                    {
                        fMedia = temp[4 * i + 3];
                    }
                    else fMedia = temp[3 * i + 2];
                    var temp2 = fMedia.Split("\\");
                    String ffMedia = temp2[0].Remove(0, 1);
                    i++;
                    imageURLs[index] = ffMedia;
                    index++;
                }
            }
            else imageURLs[0] = "css/pictures/No_image_available.png";
            return imageURLs;
        }

        public String[] formatPartDetail(String partDetail, String request)
        {
            String[] items = new string[10];

            if (request.Equals("disposition"))
            {
                var temp = partDetail.Split("\"dp\"");
                int j = 1;
                String tempString = "";
                String disposition;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        disposition = temp2[0].Substring(2, 4);
                    }
                    else disposition = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < disposition.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(disposition[i]);
                        }
                        else if (char.IsWhiteSpace(disposition, i - 1))
                        {
                            tempString += char.ToUpper(disposition[i]);
                        }
                        else tempString += char.ToLower(disposition[i]);
                        i++;
                    }
                    items[j - 1] = tempString;
                    j++;
                }

            }
            if (request.Equals("condition"))
            {
                var temp = partDetail.Split("\"cd\"");
                int j = 1;
                String tempString = "";
                String condition;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        condition = temp2[0].Substring(2, 4);
                    }
                    else condition = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < condition.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(condition[i]);
                        }
                        else if (char.IsWhiteSpace(condition, i - 1))
                        {
                            tempString += char.ToUpper(condition[i]);
                        }
                        else tempString += char.ToLower(condition[i]);
                        i++;
                    }
                    items[j - 1] = tempString;
                    j++;
                }


            }
            if (request.Equals("quantity"))
            {
                var temp = partDetail.Split("\"lc\"");
                int j = 1;
                String tempString = "";
                String quantity;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        quantity = temp2[0].Substring(2, 4);
                    }
                    else quantity = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < quantity.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(quantity[i]);
                        }
                        else if (char.IsWhiteSpace(quantity, i - 1))
                        {
                            tempString += char.ToUpper(quantity[i]);
                        }
                        else tempString += char.ToLower(quantity[i]);
                        i++;
                    }
                    var quant = tempString.Split(',');

                    items[j - 1] = quant[0];
                    j++;
                }


            }

            if (request.Equals("remark"))
            {
                var temp = partDetail.Split("\"rk\"");
                int j = 1;
                String tempString = "";
                String remark;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        remark = temp2[0].Substring(2, 4);
                    }
                    else remark = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < remark.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(remark[i]);
                        }
                        else if (char.IsWhiteSpace(remark, i - 1))
                        {
                            tempString += char.ToUpper(remark[i]);
                        }
                        else tempString += char.ToLower(remark[i]);
                        i++;
                    }
                    items[j - 1] = tempString;
                    j++;
                }


            }
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null) items[i] = "";
                if (items[i].Equals("Null")) items[i] = "";
            }
            return items;
        }

        public String[] formatAttributeDetail(String attributeDetail, String request)
        {
            String[] items = new string[10];

            if (request.Equals("attribute"))
            {
                var temp = attributeDetail.Split("\"ty\"");
                int j = 1;
                String tempString = "";
                String attribute;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        attribute = temp2[0].Substring(2, 4);
                    }
                    else attribute = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < attribute.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(attribute[i]);
                        }
                        else if (char.IsWhiteSpace(attribute, i - 1))
                        {
                            tempString += char.ToUpper(attribute[i]);
                        }
                        else tempString += char.ToLower(attribute[i]);
                        i++;
                    }
                    items[j - 1] = tempString;
                    j++;
                }

            }
            if (request.Equals("value"))
            {
                var temp = attributeDetail.Split("\"vu\"");
                int j = 1;
                String tempString = "";
                String value;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        value = temp2[0].Substring(2, 4);
                    }
                    else value = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < value.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(value[i]);
                        }
                        else if (char.IsWhiteSpace(value, i - 1))
                        {
                            tempString += char.ToUpper(value[i]);
                        }
                        else tempString += char.ToLower(value[i]);
                        i++;
                    }
                    items[j - 1] = tempString;
                    j++;
                }


            }
            if (request.Equals("date"))
            {
                var temp = attributeDetail.Split("\"da\"");
                int j = 1;
                String tempString = "";
                String date;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        date = temp2[0].Substring(2, 4);
                    }
                    else date = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < date.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(date[i]);
                        }
                        else if (char.IsWhiteSpace(date, i - 1))
                        {
                            tempString += char.ToUpper(date[i]);
                        }
                        else tempString += char.ToLower(date[i]);
                        i++;
                    }
                    items[j - 1] = tempString;
                    j++;
                }


            }
            if (request.Equals("determiner"))
            {
                var temp = attributeDetail.Split("\"dt\"");
                int j = 1;
                String tempString = "";
                String determiner;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        determiner = temp2[0].Substring(2, 4);
                    }
                    else determiner = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < determiner.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(determiner[i]);
                        }
                        else if (char.IsWhiteSpace(determiner, i - 1))
                        {
                            tempString += char.ToUpper(determiner[i]);
                        }
                        else tempString += char.ToLower(determiner[i]);
                        i++;
                    }
                    items[j - 1] = tempString;
                    j++;
                }


            }

            if (request.Equals("remark"))
            {
                var temp = attributeDetail.Split("\"rk\"");
                int j = 1;
                String tempString = "";
                String remark;
                while (j < temp.Length)
                {
                    var temp2 = temp[j].Split("\"");
                    if (temp2[0].Length > 3)
                    {
                        remark = temp2[0].Substring(2, 4);
                    }
                    else remark = temp2[1];

                    int i = 0;
                    tempString = "";
                    while (i < remark.Length)
                    {

                        if (i == 0)
                        {
                            tempString += char.ToUpper(remark[i]);
                        }
                        else if (char.IsWhiteSpace(remark, i - 1))
                        {
                            tempString += char.ToUpper(remark[i]);
                        }
                        else tempString += char.ToLower(remark[i]);
                        i++;
                    }
                    items[j - 1] = tempString;
                    j++;
                }


            }

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null) items[i] = "";
                if (items[i].Equals("Null")) items[i] = "";
            }

            return items;
        }

        //This method reaches out to the arctos database to return results based on the search fields specified
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

        public String[] formatParts(String partString)
        {
            String[] parts = new string[10];
            var temp = partString.Split("; ");
            int i = 0;
            while (i < temp.Length)
            {
                parts[i] = temp[i];
                i++;
            }
            return parts;
        }
        public async static Task<GenResults.RootObject> GetResults(string GUID)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://arctos.database.museum/component/api/v1/catalog.cfc?method=getCatalogData&api_key=03D9E9AF-A1E7-4AA1-A9C0AE5880AE7779&guid=" + GUID + "&cols=media,kingdom,phylum,phylclass,phylorder,family,subfamily,genus,species,collectors,specimen_event_type,event_assigned_date,nature_of_id,coll_event_remarks,verbatim_locality,verificationstatus,collecting_source,sci_name_with_auth,parts,partdetail,continent_ocean,county,parts,partdetail,json_locality,accn_number,reproductive_data,age,sex,weight,total_length";
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);
                GenResults.RootObject retObj = new GenResults.RootObject();
                var columns = json.SelectToken("qrycols");
                List<string> cList = new List<string>();
                foreach (var c in columns)
                {
                    var cString = c.ToString();
                    cList.Add(cString);
                }
                retObj.COLUMNS = cList;
                var data = json.SelectToken("Records");
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
                if (Char.IsNumber(date[0]) && Char.IsNumber(date[1]) && Char.IsNumber(date[2]) && Char.IsNumber(date[3]))
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
        public GenResults.ResultObject getData(GenResults.RootObject json)
        {
            GenResults.ResultObject obj = new GenResults.ResultObject();
            foreach (var item in json.DATA) //Creating a new object and passing the data from the json object for each item in the results list.
            {

                obj.GUID = formatString(item[0].ToString());
                obj.accession = formatString(item[1].ToString());
                obj.imageURL = formatMedia(item[2].ToString());
                obj.linkedItem = formatLinkedURL(item[2].ToString());
                obj.sciName = formatString(item[3].ToString());
                obj.sci_name_with_auth = formatString(item[4].ToString());
                if (obj.sci_name_with_auth[0].Equals('<'))
                {
                    obj.sci_name_with_auth = obj.sci_name_with_auth.Substring(3);
                    obj.author = obj.sci_name_with_auth.Substring(obj.sciName.Length + 4);
                }
                else if (obj.sci_name_with_auth.Length > obj.sciName.Length) obj.author = obj.sci_name_with_auth.Substring(obj.sciName.Length);
                obj.natureOfId = formatString(item[5].ToString());
                obj.Kingdom = formatString(item[6].ToString());
                obj.Phylum = formatString(item[7].ToString());
                obj.Class = formatString(item[8].ToString());
                obj.Order = formatString(item[9].ToString());
                obj.Family = formatString(item[10].ToString());
                obj.subfamily = formatString(item[11].ToString());
                obj.Genus = formatString(item[12].ToString());
                obj.Species = formatString(item[13].ToString());
                obj.collector = formatString(item[14].ToString());
                obj.eventType = formatString(item[15].ToString());
                obj.eventDate = formatString(item[16].ToString());
                obj.collectingSource = formatString(item[17].ToString());
                obj.Continent_Ocean = formatString(item[18].ToString());
                obj.Country = formatString(item[19].ToString());
                obj.State = formatString(item[20].ToString());
                obj.County = formatString(item[21].ToString());
                obj.Locality = formatString(item[22].ToString());
                obj.verbatimLocality = formatString(item[23].ToString());
                obj.Date = formatDate(item[24].ToString());
                String parts = formatString(item[25].ToString());
                obj.parts = formatParts(parts);
                var partDetail = item[26];
                obj.quantities = formatPartDetail(partDetail, "quantity");
                obj.conditions = formatPartDetail(partDetail, "condition");
                obj.dispositions = formatPartDetail(partDetail, "disposition");
                obj.partRemarks = formatPartDetail(partDetail, "remark");
                obj.Lat = item[27].Remove(0, 11);
                if (!obj.Lat.Equals("No Data") && !(obj.Lat.Equals("")) && !(obj.Lat.Equals(" ")) && !(obj.Lat.Equals("null")))
                {

                    double latNum = Convert.ToDouble(obj.Lat);
                    latNum = Math.Round(latNum, 5);
                    obj.mapLat = latNum;
                    obj.Lat = latNum.ToString();
                    obj.Lat = "(" + obj.Lat + ",";
                }
                else obj.Lat = "";

                obj.Long = item[28].Remove(0, 12);

                if (!obj.Long.Equals("No Data") && !(obj.Lat.Equals(" ")) && !(obj.Lat.Equals("")) && !(obj.Long.Equals("null")))
                {

                    double longNum = Convert.ToDouble(obj.Long);
                    longNum = Math.Round(longNum, 5);
                    obj.mapLong = longNum;
                    obj.Long = longNum.ToString();
                    obj.Long = obj.Long + ")";
                }

                else obj.Long = "";
                obj.uncertaintyMeters = formatString(item[29].ToString());
                obj.verificationStatus = formatString(item[30].ToString());
                obj.eventRemarks = formatString(item[31].ToString());
                var localityDetail = item[32];
                obj.localityAttributes = formatAttributeDetail(localityDetail, "attribute");
                obj.attributeValues = formatAttributeDetail(localityDetail, "value");
                obj.attributeDeterminers = formatAttributeDetail(localityDetail, "determiner");
                obj.attributeDates = formatAttributeDetail(localityDetail, "date");
                obj.attributeRemarks = formatAttributeDetail(localityDetail, "remark");
                obj.age = formatString(item[33].ToString());
                obj.reproductiveStatus = formatString(item[34].ToString());
                obj.sex = formatString(item[35].ToString());
                obj.totalLength = formatString(item[36].ToString());
                obj.totalWeight = formatString(item[37].ToString());



                obj.objectId = obj.GUID;



                //obj.csvURL = json.COLUMNS.Last();
                //objList.Add(obj);
            }
            /*obj.objectId = json.DATA[0][0].ToString();
            obj.GUID = json.DATA[0][0].ToString();
            obj.sciName = json.DATA[0][1].ToString();
            obj.Country = json.DATA[0][2].ToString();
            obj.State = json.DATA[0][3].ToString();
            obj.Locality = json.DATA[0][4].ToString();
            obj.Date = json.DATA[0][5].ToString();
            obj.Lat = json.DATA[0][6].ToString();
            obj.Long = json.DATA[0][7].ToString();
            obj.uncertaintyMeters = json.DATA[0][8].ToString();
            if(!String.IsNullOrEmpty(obj.Lat))
            {
                obj.mapLat = decimal.Parse(obj.Lat);
                obj.mapLong = decimal.Parse(obj.Long);
            } */
            return obj;
        }
    }
}