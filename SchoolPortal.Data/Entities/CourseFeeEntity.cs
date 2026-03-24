namespace SchoolPortal.Data.Entities;

public class CourseFeeEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CourseId { get; set; }
    public CourseEntity? Course { get; set; }

    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string BillingPeriod { get; set; } = string.Empty;
}
