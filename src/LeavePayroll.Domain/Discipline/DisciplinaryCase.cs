using LeavePayroll.Domain.Common;
using LeavePayroll.Domain.Employees;

namespace LeavePayroll.Domain.Discipline;

public class DisciplinaryCase : BaseEntity, IAuditableEntity
{
    public string CaseNumber { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public DateTime IncidentDate { get; set; }
    public DateTime ReportedDate { get; set; }
    public string LocationOrDepartment { get; set; } = string.Empty;
    public string ReportedBy { get; set; } = string.Empty;
    public string IncidentDescription { get; set; } = string.Empty;

    public MisconductCategory Category { get; set; }
    public string? OtherCategoryDetails { get; set; }

    public bool HasPriorDisciplinaryRecord { get; set; }
    public string? PriorRecordDetails { get; set; }

    public string InvestigationSummary { get; set; } = string.Empty;
    public DateTime? HearingDate { get; set; }
    public string EmployeeResponseStatement { get; set; } = string.Empty;

    public DisciplinaryActionType ActionTaken { get; set; } = DisciplinaryActionType.NoActionCaseDismissed;
    public int? SuspensionDays { get; set; }
    public bool IsSuspensionPaid { get; set; }
    public string? OtherActionDetails { get; set; }

    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDateOfWarning { get; set; }
    public string? CorrectiveImprovementPlan { get; set; }

    public bool IsAppealed { get; set; }
    public string? AppealDetails { get; set; }
    public string Status { get; set; } = "Active"; // Active, Expired, Dismissed, Appealed

    public string? SupervisorSignature { get; set; }
    public string? HrSignature { get; set; }
    public string? ApprovingAuthoritySignature { get; set; }
}
