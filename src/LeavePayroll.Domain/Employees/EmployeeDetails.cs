using LeavePayroll.Domain.Common;

namespace LeavePayroll.Domain.Employees;

public class EmployeeEducation : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string Level { get; set; } = string.Empty; // Elementary, Secondary, College, University
    public string SchoolName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int YearCompleted { get; set; }
    public string FieldOfStudy { get; set; } = string.Empty;
    public string Credential { get; set; } = string.Empty;
}

public class EmployeeQualification : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string AwardingInstitution { get; set; } = string.Empty;
    public string QualificationLevel { get; set; } = string.Empty;
    public string CertificateNumber { get; set; } = string.Empty;
    public int YearObtained { get; set; }
}

public class EmployeeLanguage : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string LanguageName { get; set; } = string.Empty;
    public string ReadingRating { get; set; } = "Good"; // Fair, Good, Very Good
    public string WritingRating { get; set; } = "Good";
    public string SpeakingRating { get; set; } = "Good";
}

public class EmployeePreviousEmployment : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string EmployerName { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public decimal LastBasicPay { get; set; }
    public string ReasonForLeaving { get; set; } = string.Empty;
}

public class EmployeeEmployment : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid PositionId { get; set; }
    public int GradeLevel { get; set; } // Grade 1 to 9
    public EmploymentType EmploymentType { get; set; }
    public DateTime DateOfEmployment { get; set; }
    public decimal BasicSalary { get; set; }
    public string Currency { get; set; } = "SSP"; // or DJF
    public string SalaryBankAccount { get; set; } = string.Empty;
    public string NraTin { get; set; } = string.Empty;
    public string NsifNumber { get; set; } = string.Empty;
    public Guid? ReportingManagerId { get; set; }
}
