using LeavePayroll.Domain.Employees;
using LeavePayroll.Domain.Organization;
using Microsoft.EntityFrameworkCore;

namespace LeavePayroll.Infrastructure.Persistence;

public static class DataSeeder
{
    public static async Task SeedAsync(LeavePayrollDbContext context)
    {
        if (await context.Employees.AnyAsync()) return;

        // 1. Seed Job Grades (1 to 9)
        var grades = new List<JobGrade>
        {
            new() { GradeNumber = 9, Title = "Executive Management (Grade 9)", MinSalary = 700000, MaxSalary = 1000000, Description = "Managing Director" },
            new() { GradeNumber = 8, Title = "Senior Executive (Grade 8)", MinSalary = 500000, MaxSalary = 700000, Description = "Deputy Director, Department Heads" },
            new() { GradeNumber = 7, Title = "Middle Management (Grade 7)", MinSalary = 350000, MaxSalary = 500000, Description = "Managers (Support, Branch, HR, Finance)" },
            new() { GradeNumber = 6, Title = "Team Leaders & Supervisors (Grade 6)", MinSalary = 250000, MaxSalary = 350000, Description = "Team Leaders" },
            new() { GradeNumber = 5, Title = "Senior Officers (Grade 5)", MinSalary = 180000, MaxSalary = 250000, Description = "Senior Officers & Analysts" },
            new() { GradeNumber = 4, Title = "Officers & Specialists (Grade 4)", MinSalary = 120000, MaxSalary = 180000, Description = "Officers & Secretaries" },
            new() { GradeNumber = 3, Title = "Junior Officers & Security (Grade 3)", MinSalary = 80000, MaxSalary = 120000, Description = "Junior Officers & Security Officers" },
            new() { GradeNumber = 2, Title = "Administrative Staff (Grade 2)", MinSalary = 50000, MaxSalary = 80000, Description = "Office Administrators" },
            new() { GradeNumber = 1, Title = "Support Staff (Grade 1)", MinSalary = 35000, MaxSalary = 50000, Description = "Messengers and Cleaners" }
        };
        await context.JobGrades.AddRangeAsync(grades);

        // 2. Seed Org Units
        var board = new OrganizationalUnit { Code = "BOD", Name = "Board of Directors", UnitType = "Board" };
        var md = new OrganizationalUnit { Code = "MD", Name = "Managing Director", UnitType = "Executive", ParentUnitId = board.Id };
        var audit = new OrganizationalUnit { Code = "AUDIT", Name = "Internal Audit", UnitType = "Department", ParentUnitId = md.Id };
        var compliance = new OrganizationalUnit { Code = "COMP", Name = "Risk & Legal Compliance", UnitType = "Department", ParentUnitId = md.Id };
        var depOp = new OrganizationalUnit { Code = "DOD", Name = "Deputy Operation Director", UnitType = "Executive", ParentUnitId = md.Id };
        var support = new OrganizationalUnit { Code = "SSM", Name = "Support Services Manager", UnitType = "Executive", ParentUnitId = md.Id };

        var credit = new OrganizationalUnit { Code = "CREDIT", Name = "Credit and FCY Management", UnitType = "Department", ParentUnitId = depOp.Id };
        var branchOps = new OrganizationalUnit { Code = "BOPS", Name = "Branch Banking — Juba Main", UnitType = "Branch", ParentUnitId = depOp.Id };
        var hr = new OrganizationalUnit { Code = "HR", Name = "HR and Facility Management", UnitType = "Department", ParentUnitId = support.Id };
        var finance = new OrganizationalUnit { Code = "FIN", Name = "Finance and Business Dev't", UnitType = "Department", ParentUnitId = support.Id };

        await context.OrganizationalUnits.AddRangeAsync(board, md, audit, compliance, depOp, support, credit, branchOps, hr, finance);

        // 3. Seed Positions
        var posMd = new Position { Code = "POS-MD", Title = "Managing Director", GradeLevel = 9, DepartmentId = md.Id };
        var posDeputy = new Position { Code = "POS-DOD", Title = "Deputy Director (Operations)", GradeLevel = 8, DepartmentId = depOp.Id };
        var posFinanceManager = new Position { Code = "POS-FIN-MGR", Title = "Manager Finance & Business Development", GradeLevel = 7, DepartmentId = finance.Id };
        var posSeniorOfficer = new Position { Code = "POS-SR-OFFICER", Title = "Senior Officer", GradeLevel = 5, DepartmentId = branchOps.Id };
        var posTeller = new Position { Code = "POS-TELLER", Title = "Teller", GradeLevel = 4, DepartmentId = branchOps.Id };

        await context.Positions.AddRangeAsync(posMd, posDeputy, posFinanceManager, posSeniorOfficer, posTeller);

        // 4. Seed Anonymized Employee Master Data (sample records from client Excel)
        var emp1 = new Employee
        {
            StaffId = "CBESSL-2022-1001",
            FirstName = "Peter",
            MiddleName = "Achuil",
            Surname = "Modi",
            DateOfBirth = new DateTime(1977, 3, 24),
            Sex = Sex.Male,
            Nationality = "South Sudanese",
            StateCountyOfOrigin = "Central Equatoria",
            NationalIdNumber = "SS-1977-XXXX85",
            Status = EmployeeStatus.Active,
            ContactDetails = new EmployeeContact
            {
                State = "Central Equatoria",
                County = "Yei",
                Payam = "Yei Payam 2",
                MobilePrimary = "+211 99 716 1434",
                PersonalEmail = "peter.modi1@cbe-ssl.com"
            },
            FamilyStatus = new EmployeeFamily
            {
                MaritalStatus = MaritalStatus.Divorced,
                MaleChildrenCount = 1,
                MaleDependentsCount = 3
            },
            EmploymentInfo = new EmployeeEmployment
            {
                DepartmentId = branchOps.Id,
                PositionId = posSeniorOfficer.Id,
                GradeLevel = 5,
                EmploymentType = EmploymentType.PermanentLocal,
                DateOfEmployment = new DateTime(2002, 11, 24),
                BasicSalary = 310000m,
                Currency = "SSP",
                SalaryBankAccount = "2015XXXXXX5557",
                NraTin = "TIN-Pxxxx928",
                NsifNumber = "NSIF-XXXX1106"
            }
        };

        var emp2 = new Employee
        {
            StaffId = "CBESSL-2023-1002",
            FirstName = "Mary",
            MiddleName = "Chol",
            Surname = "Mabior",
            DateOfBirth = new DateTime(1973, 6, 28),
            Sex = Sex.Female,
            Nationality = "South Sudanese",
            StateCountyOfOrigin = "Jonglei",
            NationalIdNumber = "SS-1973-XXXX20",
            Status = EmployeeStatus.Active,
            ContactDetails = new EmployeeContact
            {
                State = "Jonglei",
                County = "Juba",
                Payam = "Juba Payam 3",
                MobilePrimary = "+211 96 691 4150",
                PersonalEmail = "mary.mabior2@cbe-ssl.com"
            },
            FamilyStatus = new EmployeeFamily
            {
                MaritalStatus = MaritalStatus.Single,
                FemaleChildrenCount = 1,
                FemaleDependentsCount = 2
            },
            EmploymentInfo = new EmployeeEmployment
            {
                DepartmentId = finance.Id,
                PositionId = posTeller.Id,
                GradeLevel = 4,
                EmploymentType = EmploymentType.Probation,
                DateOfEmployment = new DateTime(2006, 10, 9),
                BasicSalary = 220000m,
                Currency = "SSP",
                SalaryBankAccount = "2015XXXXXX4814",
                NraTin = "TIN-PXXXX987",
                NsifNumber = "NSIF-XXXX2654"
            }
        };

        await context.Employees.AddRangeAsync(emp1, emp2);
        await context.SaveChangesAsync();
    }
}
