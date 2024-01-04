using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpHipinitrequest
    {
        public string RequestId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AuthType { get; set; } = null!;
        public string Authorisation { get; set; } = null!;
        public string Dob { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string HealhId { get; set; } = null!;
        public string HospRegId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ReferenceConfirm { get; set; } = null!;
        public string ReferenceInit { get; set; } = null!;
        public string RequestTimestamp { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
    }
}
