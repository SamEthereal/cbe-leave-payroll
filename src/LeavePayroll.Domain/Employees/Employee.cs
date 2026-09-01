using LeavePayroll.Domain.Common;

namespace LeavePayroll.Domain.Employees;

public class Employee : BaseEntity, IAuditableEntity
{
    public string StaffId { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string? OtherMaidenName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PlaceOfBirth { get; set; } = string.Empty;
    public Sex Sex { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public string? EthnicGroup { get; set; }
    public string StateCountyOfOrigin { get; set; } = string.Empty;
    public string NationalIdNumber { get; set; } = string.Empty;
    public string? PassportNumber { get; set; }
    public string? PhotoPath { get; set; }
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;

    public EmployeeContact? ContactDetails { get; set; }
    public EmployeeFamily? FamilyStatus { get; set; }
    public EmployeeParent? ParentsInfo { get; set; }
    public EmployeeEmployment? EmploymentInfo { get; set; }

    public List<EmployeeDependent> Dependents { get; set; } = [];
    public List<EmployeeNextOfKin> NextOfKinList { get; set; } = [];
    public List<EmployeeEducation> EducationList { get; set; } = [];
    public List<EmployeeQualification> Qualifications { get; set; } = [];
    public List<EmployeeLanguage> Languages { get; set; } = [];
    public List<EmployeePreviousEmployment> PreviousEmployments { get; set; } = [];

    public string FullName => $"{FirstName} {MiddleName} {Surname}".Replace("  ", " ").Trim();
}
