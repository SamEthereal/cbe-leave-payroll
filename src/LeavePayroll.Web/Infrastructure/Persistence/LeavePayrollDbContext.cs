using LeavePayroll.Domain.Approval;
using LeavePayroll.Domain.Common;
using LeavePayroll.Domain.Discipline;
using LeavePayroll.Domain.Employees;
using LeavePayroll.Domain.Movements;
using LeavePayroll.Domain.Organization;
using Microsoft.EntityFrameworkCore;

namespace LeavePayroll.Infrastructure.Persistence;

public class LeavePayrollDbContext : DbContext
{
    public LeavePayrollDbContext(DbContextOptions<LeavePayrollDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeeContact> EmployeeContacts => Set<EmployeeContact>();
    public DbSet<EmployeeFamily> EmployeeFamilies => Set<EmployeeFamily>();
    public DbSet<EmployeeParent> EmployeeParents => Set<EmployeeParent>();
    public DbSet<EmployeeDependent> EmployeeDependents => Set<EmployeeDependent>();
    public DbSet<EmployeeNextOfKin> EmployeeNextOfKins => Set<EmployeeNextOfKin>();
    public DbSet<EmployeeEducation> EmployeeEducations => Set<EmployeeEducation>();
    public DbSet<EmployeeQualification> EmployeeQualifications => Set<EmployeeQualification>();
    public DbSet<EmployeeLanguage> EmployeeLanguages => Set<EmployeeLanguage>();
    public DbSet<EmployeePreviousEmployment> EmployeePreviousEmployments => Set<EmployeePreviousEmployment>();
    public DbSet<EmployeeEmployment> EmployeeEmployments => Set<EmployeeEmployment>();

    public DbSet<OrganizationalUnit> OrganizationalUnits => Set<OrganizationalUnit>();
    public DbSet<JobGrade> JobGrades => Set<JobGrade>();
    public DbSet<Position> Positions => Set<Position>();

    public DbSet<EmployeeMovement> EmployeeMovements => Set<EmployeeMovement>();
    public DbSet<DisciplinaryCase> DisciplinaryCases => Set<DisciplinaryCase>();
    public DbSet<MakerCheckerRequest> MakerCheckerRequests => Set<MakerCheckerRequest>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.StaffId)
            .IsUnique();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.ContactDetails)
            .WithOne()
            .HasForeignKey<EmployeeContact>(c => c.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.FamilyStatus)
            .WithOne()
            .HasForeignKey<EmployeeFamily>(f => f.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.ParentsInfo)
            .WithOne()
            .HasForeignKey<EmployeeParent>(p => p.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.EmploymentInfo)
            .WithOne()
            .HasForeignKey<EmployeeEmployment>(em => em.EmployeeId);
    }
}
