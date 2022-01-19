using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Museum.Models {
	public class SearchModel {
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
		public string Species { get; set; }
		public string Subspecies { get; set; }
		public string Family { get; set; }
		public string subfamily { get; set; }
		public string Genus { get; set; }
		public string commonName { get; set; }
		public string idBy { get; set; }
		public string natureOfId { get; set; }
		public string Remarks { get; set; }
		public decimal mapLat { get; set; }
		public decimal mapLong { get; set; }
		public string csvURL { get; set; }
		public string eventDate { get; set; }
		public string collector { get; set; }
		public string eventType { get; set; }

		public string Identificaiton { get; set; }
		public string tribe { get; set; }
		public string subtribe { get; set; }
		public string subspecies { get; set; }
		public string author { get; set; }
		public string determiner { get; set; }
		public DateTime year { get; set; }
		public string synonyms { get; set; }
		public string catalogNum { get; set; }
		public string accession { get; set; }
		public string otherIdtype { get; set; }
		public string Continent { get; set; }
		public string County { get; set; }
		public string localityRemarks { get; set; }
		public string naturalOrderClass { get; set; }
		public string naturalOrderSubclass { get; set; }
		public string primaryTerm { get; set; }
		public string secondaryTerm { get; set; }
		public string tertiaryTerm { get; set; }
		public string nonPreferredTerm { get; set; }
		public string Description { get; set; }
		public string maker { get; set; }
		public DateTime manuDate { get; set; }
		public string size { get; set; }
		public string condition { get; set; }
		public string conditionRemarks { get; set; }
		public string anyTax { get; set; }
		public string anyId { get; set; }
		public string otherId { get; set; }

		//Geology specific variables
		public string era { get; set; }
		public string period { get; set; }
		public string series { get; set; }
		public string stage { get; set; }
		public string group { get; set; }
		public string formation { get; set; }
		public string member { get; set; }
		public string bed { get; set; }

		//end Geology specific variables

		//Checkbox variables
		public bool amphibian { get; set; }
		public bool bird { get; set; }
		public bool annelid { get; set; }
		public bool crustacea { get; set; }
		public bool fish { get; set; }
		public bool insect { get; set; }
		public bool invertebrate { get; set; }
		public bool mammal { get; set; }
		public bool mollusc { get; set; }

		public bool syn { get; set; }
		public bool parts { get; set; }

		public bool invertebrates { get; set; }
		public bool plants { get; set; }
		public bool vertebrates { get; set; }
		public bool rocks { get; set; }

		public bool builtEnvObj { get; set; }
		public bool furnishing { get; set; }
		public bool personalObj { get; set; }
		public bool toolsMats { get; set; }
		public bool toolsSci { get; set; }
		public bool toolsCom { get; set; }
		public bool transportationObj { get; set; }
		public bool comObj { get; set; }
		public bool recObj { get; set; }
	}
}
