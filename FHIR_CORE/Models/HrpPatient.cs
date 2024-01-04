using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpPatient
    {
        public HrpPatient()
        {
            HrpPatientvisitdtls = new HashSet<HrpPatientvisitdtl>();
        }

        public long PatientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Age { get; set; }
        public DateTime? BirthDt { get; set; }
        public string? ContactNumber { get; set; }
        public string? DistLgdCd { get; set; }
        public string? FhirObject { get; set; }
        public string? FirstName { get; set; }
        public string? Gender { get; set; }
        public string? LastName { get; set; }
        public DateTime LastVisitDt { get; set; }
        public string? LastVisitType { get; set; }
        public string? MiddleName { get; set; }
        public string? Pincode { get; set; }
        public string? StateLgdCd { get; set; }
        public string? SwasthyaId { get; set; }
        public string? TownLgdCd { get; set; }
        public string? VillageLgdCd { get; set; }
        public string? LinkYn { get; set; }
        public string? HipCode { get; set; }
        public string? RequestId { get; set; }

        public virtual ICollection<HrpPatientvisitdtl> HrpPatientvisitdtls { get; set; }
    }
}
