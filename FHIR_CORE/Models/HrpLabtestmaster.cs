using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpLabtestmaster
    {
        public string? ParentId { get; set; }
        public string LoincId { get; set; } = null!;
        public string TestId { get; set; } = null!;
        public string TestOrderName { get; set; } = null!;
        public string Id { get; set; } = null!;
    }
}
