using LeavePayroll.Domain.Common;
using LeavePayroll.Domain.Employees;

namespace LeavePayroll.Domain.Approval;

public class MakerCheckerRequest : BaseEntity
{
    public string EntityType { get; set; } = string.Empty; // Employee, EmployeeEmployment, PayrollRun
    public Guid EntityId { get; set; }
    public string ActionRequested { get; set; } = string.Empty; // UpdateSalary, UpdateBankDetails, UpdateGrade
    public string FieldName { get; set; } = string.Empty;
    public string? OldValue { get; set; }
    public string NewValue { get; set; } = string.Empty;
    public string PayloadJson { get; set; } = string.Empty;

    public string RequestedByUserId { get; set; } = string.Empty;
    public string RequestedByUserName { get; set; } = string.Empty;
    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

    public MakerCheckerStatus Status { get; set; } = MakerCheckerStatus.Pending;
    public string? ReviewedByUserId { get; set; }
    public string? ReviewedByUserName { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public string? RejectionReason { get; set; }
}
