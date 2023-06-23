namespace PowerUsage.Web.Models;

public class MeterReadingInputModel
{
    public DateOnly? Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public TimeOnly? Time { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
    public int? TotalKilowattHours { get; set; }
}
