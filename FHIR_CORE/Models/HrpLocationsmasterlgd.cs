using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpLocationsmasterlgd
    {
        public string Sno { get; set; } = null!;
        public string ActiveYn { get; set; } = null!;
        public string BlockCode { get; set; } = null!;
        public string BlockName { get; set; } = null!;
        public string DistrictCode { get; set; } = null!;
        public string DistrictName { get; set; } = null!;
        public string StateCode { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public string SubDistrictCode { get; set; } = null!;
        public string SubDistrictName { get; set; } = null!;
        public string VillageCode { get; set; } = null!;
        public string VillageName { get; set; } = null!;
    }
}
