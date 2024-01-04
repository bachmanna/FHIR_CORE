using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpPatientprescriptiondtl
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Duration { get; set; }
        public string? Instruction { get; set; }
        public string? PrescribedBy { get; set; }
        public DateTime PresciptionDt { get; set; }
        public string PresciptionNotes { get; set; } = null!;
        public string? Quantity { get; set; }
        public string? RepeatsAllowedYn { get; set; }
        public string? DrugName { get; set; }
        public string? DurationUnit { get; set; }
        public string? Condition { get; set; }
        public string? AttachPath { get; set; }
        public string? Notes { get; set; }
        public string? ReportType { get; set; }
        public long? DrugInstructionId { get; set; }
        public string? DrugId { get; set; }
        public string? ActiveYn { get; set; }
        public long VisitId { get; set; }

        public virtual HrpPatientvisitdtl Visit { get; set; } = null!;
    }
}
