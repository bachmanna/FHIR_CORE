using System;
using System.Collections.Generic;

namespace FHIR_CORE.Models
{
    public partial class HrpDiagnosticreportattachment
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ReportFilePath { get; set; } = null!;
        public long VisitId { get; set; }
        public string ActiveYn { get; set; } = null!;
        public long ReportId { get; set; }

        public virtual HrpPatientdiagnosticreportdtl Report { get; set; } = null!;
    }
}
