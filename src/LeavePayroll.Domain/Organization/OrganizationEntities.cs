using LeavePayroll.Domain.Common;

namespace LeavePayroll.Domain.Organization;

public class OrganizationalUnit : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string UnitType { get; set; } = "Department";
    public Guid? ParentUnitId { get; set; }
    public Guid? ManagerId { get; set; }
    public bool IsActive { get; set; } = true;
}

public class JobGrade : BaseEntity
{
    public int GradeNumber { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class Position : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public Guid DepartmentId { get; set; }
    public bool IsActive { get; set; } = true;
}
