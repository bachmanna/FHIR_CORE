using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpConsentrequest
    {
        public string ConsentRequestId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ConsentCreatedDt { get; set; } = null!;
        public string ConsentExpiryDt { get; set; } = null!;
        public string ConsentGrantDt { get; set; } = null!;
        public string ConsentId { get; set; } = null!;
        public string DischargeYn { get; set; } = null!;
        public string DoctorId { get; set; } = null!;
        public string FacilityId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string HealthExpiryFromDt { get; set; } = null!;
        public string HealthExpiryToDt { get; set; } = null!;
        public string HealthInfoFromDt { get; set; } = null!;
        public string HealthInfoToDt { get; set; } = null!;
        public string ImageYn { get; set; } = null!;
        public string LabYn { get; set; } = null!;
        public string OpYn { get; set; } = null!;
        public string PrescriptionYn { get; set; } = null!;
        public string Purpose { get; set; } = null!;
        public string SwasthyaId { get; set; } = null!;
        public string VisitId { get; set; } = null!;
    }
}
