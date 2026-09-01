using LeavePayroll.Domain.Common;

namespace LeavePayroll.Domain.Employees;

public class EmployeeContact : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string State { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string Payam { get; set; } = string.Empty;
    public string? HouseNumber { get; set; }
    public string MobilePrimary { get; set; } = string.Empty;
    public string? MobileAlternate { get; set; }
    public string? MobileSecondary { get; set; }
    public string? POBox { get; set; }
    public string PersonalEmail { get; set; } = string.Empty;
}

public class EmployeeFamily : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public int MaleChildrenCount { get; set; }
    public int FemaleChildrenCount { get; set; }
    public int MaleDependentsCount { get; set; }
    public int FemaleDependentsCount { get; set; }
}

public class EmployeeParent : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string FatherName { get; set; } = string.Empty;
    public DateTime? FatherDOB { get; set; }
    public string? FatherOccupation { get; set; }
    public string? FatherAddress { get; set; }
    public string? FatherPhone { get; set; }

    public string MotherName { get; set; } = string.Empty;
    public DateTime? MotherDOB { get; set; }
    public string? MotherOccupation { get; set; }
    public string? MotherAddress { get; set; }
    public string? MotherPhone { get; set; }
}

public class EmployeeDependent : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Relationship { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}

public class EmployeeNextOfKin : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Relationship { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? ResidentialAddress { get; set; }
}
