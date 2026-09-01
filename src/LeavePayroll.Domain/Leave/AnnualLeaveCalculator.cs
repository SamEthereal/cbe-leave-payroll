namespace LeavePayroll.Domain.Leave;

public class AnnualLeaveCalculator
{
    public const decimal MonthlyAccrualRate = 2.5m; // 2.5 days per month = 30 days/year

    public static decimal CalculateAccruedDays(int monthsWorked)
    {
        if (monthsWorked <= 0) return 0m;
        return Math.Round(monthsWorked * MonthlyAccrualRate, 1);
    }

    public static decimal CalculateRemainingBalance(decimal totalAccruedDays, decimal daysTaken)
    {
        decimal balance = totalAccruedDays - daysTaken;
        return balance < 0 ? 0m : balance;
    }
}
