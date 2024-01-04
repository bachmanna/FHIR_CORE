using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpPatientdiagnosticreportdtl
    {
        public HrpPatientdiagnosticreportdtl()
        {
            HrpDiagnosticreportattachments = new HashSet<HrpDiagnosticreportattachment>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PerformingOrg { get; set; } = null!;
        public string? ReportConclusion { get; set; }
        public DateTime ReportDt { get; set; }
        public string? ReportFilePath { get; set; }
        public string? ReportFileType { get; set; }
        public string? ReportedBy { get; set; }
        public string? ServiceCategory { get; set; }
        public string? Status { get; set; }
        public string? TestCode { get; set; }
        public string? AttachPath { get; set; }
        public string? Conclusion { get; set; }
        public string? PanelCode { get; set; }
        public string? PatientId { get; set; }
        public string? ReportCategory { get; set; }
        public DateTime? ReportDate { get; set; }
        public string? ReportType { get; set; }
        public string? ReportingDoctor { get; set; }
        public string? ReportCategoryValue { get; set; }
        public string? TestCodeValue { get; set; }
        public string? ActiveYn { get; set; }
        public long VisitId { get; set; }

        public virtual HrpPatientvisitdtl Visit { get; set; } = null!;
        public virtual ICollection<HrpDiagnosticreportattachment> HrpDiagnosticreportattachments { get; set; }
    }
}
