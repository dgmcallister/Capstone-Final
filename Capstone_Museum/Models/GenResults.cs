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
            public string sciName { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
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
            public string commonName { get; set; }
            public string idBy { get; set; }
            public string natureOfId { get; set; }
            public string Remarks { get; set; }
            public decimal mapLat { get; set; }
            public decimal mapLong { get; set; }

        }
        public class RootObject
        {
            public List<string> COLUMNS { get; set; }
            public List<List<string>> DATA { get; set; }

        }

    }
    

}
