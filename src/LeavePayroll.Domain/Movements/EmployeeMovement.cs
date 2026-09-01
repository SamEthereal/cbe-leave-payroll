using LeavePayroll.Domain.Common;
using LeavePayroll.Domain.Employees;

namespace LeavePayroll.Domain.Movements;

public class EmployeeMovement : BaseEntity, IAuditableEntity
{
    public string FormNumber { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public MovementActionType ActionType { get; set; }

    // Current State
    public Guid CurrentDepartmentId { get; set; }
    public Guid CurrentPositionId { get; set; }
    public int CurrentGradeLevel { get; set; }
    public decimal CurrentBasicSalary { get; set; }
    public Guid? CurrentReportingManagerId { get; set; }
    public string CurrentWorkLocation { get; set; } = string.Empty;

    // Proposed State
    public Guid ProposedDepartmentId { get; set; }
    public Guid ProposedPositionId { get; set; }
    public int ProposedGradeLevel { get; set; }
    public decimal ProposedBasicSalary { get; set; }
    public Guid? ProposedReportingManagerId { get; set; }
    public string ProposedWorkLocation { get; set; } = string.Empty;

    public DateTime EffectiveDate { get; set; }
    public string Justification { get; set; } = string.Empty;

    // Eligibility & Budget Checklist
    public bool SatisfiesMinimumTenure { get; set; }
    public bool PerformanceAppraisalSupports { get; set; }
    public bool MeetsQualificationExperience { get; set; }
    public bool NoPendingDisciplinaryAction { get; set; }
    public bool IsPositionBudgeted { get; set; }
    public bool IsPositionVacant { get; set; }

    // Sign-off / Workflow
    public MovementStatus Status { get; set; } = MovementStatus.Draft;
    public string? RecommendingManagerComments { get; set; }
    public string? RecommendingManagerSignature { get; set; }
    public DateTime? RecommendingManagerSignedAt { get; set; }

    public string? HrVerificationComments { get; set; }
    public string? HrVerifiedBy { get; set; }
    public DateTime? HrVerifiedAt { get; set; }

    public string? ApprovingAuthoritySignature { get; set; }
    public string? ApprovingAuthorityTitle { get; set; } // Head of Dept, MD, Board
    public DateTime? ApprovedAt { get; set; }
    public string? RejectionReason { get; set; }
}
