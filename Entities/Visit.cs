using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities;

[Table("Visits")]
public class Visit
{
    public int VisitID { get; set; }

    public required string VisitType { get; set; }

    public DateTime ScheduledDate { get; set; }
    
    public DateTime? ActualDate { get; set; }

    public required string Notes { get; set; }

    [ForeignKey("SubjectID")]
    public virtual required Subject Subject { get; set; }
}
