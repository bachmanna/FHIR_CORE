using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpConsentartefact
    {
        public string ConsentArtefactId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? ConsentId { get; set; }
    }
}
