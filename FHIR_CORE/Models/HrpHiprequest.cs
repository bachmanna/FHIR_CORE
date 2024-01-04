using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpHiprequest
    {
        public string RequestId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Authoriszation { get; set; } = null!;
        public string HospRegId { get; set; } = null!;
        public string RequestBody { get; set; } = null!;
        public string RequestServed { get; set; } = null!;
        public string RequestTimestamp { get; set; } = null!;
        public string RequestType { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
    }
}
