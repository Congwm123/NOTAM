using System.ComponentModel.DataAnnotations;

namespace NOTAMApplication.DataAccess.Entities;

public class CrawlJob
{
    [Key]
    public int JobId { get; set; }
    public string JobName { get; set; } = string.Empty;
    public DateTime RunTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public int DataCount { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateTime UpdatedAt { get; set; }
}
