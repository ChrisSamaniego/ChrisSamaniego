namespace SchoolPortal.Models;

public class CourseFee
{
    public string CourseName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string BillingPeriod { get; set; } = "Monthly";
}
