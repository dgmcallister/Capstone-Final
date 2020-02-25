using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Museum.Models
{
    public class GenResults
    {
        public int objectId { get; set; }
        public string GUID { get; set; }
        public string sciName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Locality { get; set; }
        public string Date { get; set; }
        public int Lat { get; set; }
        public int Long { get; set; }
        public int uncertaintyMeters { get; set; }
    }
}
