using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpPatientclinicalnotesdtl
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string DocumentBy { get; set; } = null!;
        public string? DocumentCategory { get; set; }
        public string DocumentCreatedAt { get; set; } = null!;
        public DateTime DocumentCreatedDt { get; set; }
        public string DocumentSource { get; set; } = null!;
        public string? DocumentStatus { get; set; }
        public string? Allergy { get; set; }
        public string? Diagnosis { get; set; }
        public DateTime? FollowUpDt { get; set; }
        public string? History { get; set; }
        public string? Prescription { get; set; }
        public string? Symptoms { get; set; }
        public string? TreatmentPlan { get; set; }
        public string? Vitals { get; set; }
        public string? AttachPath { get; set; }
        public string? Notes { get; set; }
        public string? ReportType { get; set; }
        public long VisitId { get; set; }

        public virtual HrpPatientvisitdtl Visit { get; set; } = null!;
    }
}
