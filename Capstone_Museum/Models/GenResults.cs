using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Museum.Models
{
    public class GenResults
    {
        public class ResultObject
        {
            public string objectId { get; set; }
            public string GUID { get; set; }
            public string accession { get; set; }
            public string guidStart { get; set; }
            public string guidEnd { get; set; }
            public string sciName { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string County { get; set; }
            public string Locality { get; set; }
            public string Date { get; set; }
            public string Lat { get; set; }
            public string Long { get; set; }
            public string uncertaintyMeters { get; set; }
            public string Kingdom { get; set; }
            public string Phylum { get; set; }
            public string Class { get; set; }
            public string Order { get; set; }
            public string Family { get; set; }
            public string subfamily { get; set; }
            public string Genus { get; set; }
            public string Species { get; set; }
            public string Subspecies { get; set; }
            public string commonName { get; set; }
            public string idBy { get; set; }
            public string natureOfId { get; set; }
            public string Remarks { get; set; }
            public double mapLat { get; set; }
            public double mapLong { get; set; }

            public string begin_month { get; set; }
            public string begin_day { get; set; }
            public string begin_year { get; set; }
            public string end_month { get; set; }
            public string end_day { get; set; }
            public string end_year { get; set; }
            public string collector { get; set; }
            public string eventDate { get; set; }
            public string eventType { get; set; }
            public string searchName { get; set; }
            public string[] imageURL { get; set; }
            public string[] linkedItem { get; set; }
            public string csvURL { get; set; }
            public string Continent_Ocean { get; set; }
            public string eventRemarks { get; set; }
            public string verbatimLocality { get; set; }
            public string verificationStatus { get; set; }
            public string collectingSource { get; set; }
            public string sci_name_with_auth { get; set; }
            public string image { get; set; }
            public string[] parts { get; set; }
            public string[] conditions { get; set; }
            public string[] dispositions { get; set; }
            public string[] quantities { get; set; }
            public string[] partRemarks { get; set; }
            public string[] localityAttributes { get; set; }
            public string[] attributeValues { get; set; }
            public string[] attributeDeterminers { get; set; }
            public string[] attributeDates { get; set; }
            public string[] attributeRemarks { get; set; }
            public string author { get; set; }
            public string age { get; set; }
            public string ageClass { get; set; }
            public string reproductiveStatus { get; set; }
            public string sex { get; set; }
            public string totalLength { get; set; }
            public string totalWeight { get; set; }
            public bool invertebrates { get; set; }
            public bool bird { get; set; }
            public bool mammal { get; set; }
            public bool herp { get; set; }
            public bool ento { get; set; }

            public bool csv { get; set; }
        }


        public class RootObject
        {
            public List<string> COLUMNS { get; set; }
            public List<List<string>> DATA { get; set; }

        }

    }


}
