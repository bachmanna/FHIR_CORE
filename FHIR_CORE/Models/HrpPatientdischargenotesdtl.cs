using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpPatientdischargenotesdtl
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
        public DateTime? AdmissionDt { get; set; }
        public string? AdviceDischarge { get; set; }
        public string? Complaints { get; set; }
        public string? Diagnosis { get; set; }
        public DateTime? DischargeDt { get; set; }
        public string? FollowUp { get; set; }
        public string? ProcedureDone { get; set; }
        public string? StatusDischarge { get; set; }
        public string? TreatmentGiven { get; set; }
        public string? AttachPath { get; set; }
        public string? Notes { get; set; }
        public string? ReportType { get; set; }
        public long VisitId { get; set; }

        public virtual HrpPatientvisitdtl Visit { get; set; } = null!;
    }
}
