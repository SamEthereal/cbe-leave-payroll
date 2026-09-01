using LeavePayroll.Domain.Leave;
using LeavePayroll.Domain.Payroll;
using Xunit;

namespace LeavePayroll.Domain.Tests;

public class DomainEngineTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(2000, 0)]
    [InlineData(5000, 150)] // (5000-2000)*0.05 = 150
    [InlineData(10000, 650)] // 150 + (10000-5000)*0.10 = 150 + 500 = 650
    [InlineData(15000, 1400)] // 650 + (15000-10000)*0.15 = 650 + 750 = 1400
    [InlineData(20000, 2400)] // 1400 + (20000-15000)*0.20 = 1400 + 1000 = 2400
    public void SouthSudanTaxCalculator_ShouldCalculateCorrectTax(decimal salary, decimal expectedTax)
    {
        var calculator = new SouthSudanTaxCalculator();
        var actualTax = calculator.CalculateIncomeTax(salary);
        Assert.Equal(expectedTax, actualTax);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(30000, 0)]
    [InlineData(50000, 3000)] // (50000-30000)*0.15 = 3000
    [InlineData(150000, 23000)] // 3000 + (150000-50000)*0.20 = 3000 + 20000 = 23000
    [InlineData(200000, 38000)] // 23000 + (200000-150000)*0.30 = 23000 + 15000 = 38000
    public void DjiboutiTaxCalculator_ShouldCalculateCorrectTax(decimal salary, decimal expectedTax)
    {
        var calculator = new DjiboutiTaxCalculator();
        var actualTax = calculator.CalculateIncomeTax(salary);
        Assert.Equal(expectedTax, actualTax);
    }

    [Fact]
    public void OvertimeCalculator_ShouldCalculateCorrectOvertimePay()
    {
        decimal basicSalary = 160000m;
        decimal standardMonthlyHours = 160m; // Hourly rate = 1000
        decimal normalHours = 10m; // 10 * 1000 * 1.5 = 15000
        decimal holidayHours = 5m; // 5 * 1000 * 2.0 = 10000

        decimal overtimePay = OvertimeCalculator.CalculateOvertimePay(basicSalary, standardMonthlyHours, normalHours, holidayHours);

        Assert.Equal(25000m, overtimePay);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(6, 15.0)]
    [InlineData(12, 30.0)]
    [InlineData(24, 60.0)]
    public void AnnualLeaveCalculator_ShouldAccrue2HalfDaysPerMonth(int monthsWorked, decimal expectedDays)
    {
        decimal accruedDays = AnnualLeaveCalculator.CalculateAccruedDays(monthsWorked);
        Assert.Equal(expectedDays, accruedDays);
    }
}
