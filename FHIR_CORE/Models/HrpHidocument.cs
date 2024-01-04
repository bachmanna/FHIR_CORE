using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpHidocument
    {
        public long DocId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CareContextDisplay { get; set; } = null!;
        public string ConsentTxnNum { get; set; } = null!;
        public string FhirObject { get; set; } = null!;
    }
}
