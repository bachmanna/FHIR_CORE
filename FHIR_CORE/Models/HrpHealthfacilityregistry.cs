using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpHealthfacilityregistry
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public bool Active { get; set; }
        public string Alias { get; set; } = null!;
    }
}
