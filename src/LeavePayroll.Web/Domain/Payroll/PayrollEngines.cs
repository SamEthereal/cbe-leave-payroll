namespace LeavePayroll.Domain.Payroll;

public interface ITaxCalculator
{
    decimal CalculateIncomeTax(decimal taxableSalary);
}

public class SouthSudanTaxCalculator : ITaxCalculator
{
    public decimal CalculateIncomeTax(decimal taxableSalary)
    {
        if (taxableSalary <= 0) return 0m;

        decimal tax = 0m;

        if (taxableSalary > 15000m)
        {
            tax += (taxableSalary - 15000m) * 0.20m;
            taxableSalary = 15000m;
        }
        if (taxableSalary > 10000m)
        {
            tax += (taxableSalary - 10000m) * 0.15m;
            taxableSalary = 10000m;
        }
        if (taxableSalary > 5000m)
        {
            tax += (taxableSalary - 5000m) * 0.10m;
            taxableSalary = 5000m;
        }
        if (taxableSalary > 2000m)
        {
            tax += (taxableSalary - 2000m) * 0.05m;
        }

        return Math.Round(tax, 2);
    }
}

public class DjiboutiTaxCalculator : ITaxCalculator
{
    public decimal CalculateIncomeTax(decimal taxableSalary)
    {
        if (taxableSalary <= 0) return 0m;

        decimal tax = 0m;

        if (taxableSalary > 150000m)
        {
            tax += (taxableSalary - 150000m) * 0.30m;
            taxableSalary = 150000m;
        }
        if (taxableSalary > 50000m)
        {
            tax += (taxableSalary - 50000m) * 0.20m;
            taxableSalary = 50000m;
        }
        if (taxableSalary > 30000m)
        {
            tax += (taxableSalary - 30000m) * 0.15m;
        }

        return Math.Round(tax, 2);
    }
}

public class OvertimeCalculator
{
    public static decimal CalculateOvertimePay(decimal basicSalary, decimal standardMonthlyHours, decimal normalOvertimeHours, decimal holidayOvertimeHours, decimal normalMultiplier = 1.5m, decimal holidayMultiplier = 2.0m)
    {
        if (standardMonthlyHours <= 0) return 0m;

        decimal hourlyRate = basicSalary / standardMonthlyHours;
        decimal normalPay = normalOvertimeHours * hourlyRate * normalMultiplier;
        decimal holidayPay = holidayOvertimeHours * hourlyRate * holidayMultiplier;

        return Math.Round(normalPay + holidayPay, 2);
    }
}
