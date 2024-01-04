using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpHiphealthinforequest
    {
        public string ConsentId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CryptoAlg { get; set; } = null!;
        public string Curve { get; set; } = null!;
        public string DataPushUrl { get; set; } = null!;
        public string DateRangeFrom { get; set; } = null!;
        public string DateRangeTo { get; set; } = null!;
        public string Nonce { get; set; } = null!;
        public string PublicKeyExpiry { get; set; } = null!;
        public string PublicKeyParam { get; set; } = null!;
        public string PublicKeyValue { get; set; } = null!;
    }
}
