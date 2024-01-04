using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpPatientvisitdtl
    {
        public HrpPatientvisitdtl()
        {
            HrpPatientclinicalnotesdtls = new HashSet<HrpPatientclinicalnotesdtl>();
            HrpPatientdiagnosticreportdtls = new HashSet<HrpPatientdiagnosticreportdtl>();
            HrpPatientprescriptiondtls = new HashSet<HrpPatientprescriptiondtl>();
        }

        public long VisitId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime VisitDt { get; set; }
        public string ClinicalNotesYn { get; set; } = null!;
        public string DiagnosticReportYn { get; set; } = null!;
        public string DischargeSummaryYn { get; set; } = null!;
        public string? FacilityCd { get; set; }
        public string? FacilityName { get; set; }
        public string? PractitionerCd { get; set; }
        public string? PractitionerName { get; set; }
        public string PrescriptionYn { get; set; } = null!;
        public string? VisitType { get; set; }
        public string? FhirObject { get; set; }
        public string? FhirPractitionerObject { get; set; }
        public string? LinkYn { get; set; }
        public long PatientId { get; set; }

        public virtual HrpPatient Patient { get; set; } = null!;
        public virtual HrpPatientdischargenotesdtl? HrpPatientdischargenotesdtl { get; set; }
        public virtual ICollection<HrpPatientclinicalnotesdtl> HrpPatientclinicalnotesdtls { get; set; }
        public virtual ICollection<HrpPatientdiagnosticreportdtl> HrpPatientdiagnosticreportdtls { get; set; }
        public virtual ICollection<HrpPatientprescriptiondtl> HrpPatientprescriptiondtls { get; set; }
    }
}
