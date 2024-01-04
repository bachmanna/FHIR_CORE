using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpImagingtestmaster
    {
        public string? ParentId { get; set; }
        public string TestId { get; set; } = null!;
        public string TestDescription { get; set; } = null!;
        public string Id { get; set; } = null!;
    }
}
