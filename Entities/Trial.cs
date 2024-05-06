namespace Api.Entities;

using System.ComponentModel.DataAnnotations.Schema;

[Table("Trials")]
public class Trial
{
    public int TrialID { get; set; }
    
    public required string Title { get; set; }
    
    public required string Description { get; set; }

    public required DateTime StartDate { get; set; }
    
    public required DateTime EndDate { get; set; }
    
    public required string Status { get; set; }
    
    [ForeignKey("PrincipalInvestigator")]
    public int? PrincipalInvestigatorID { get; set; }
    
    public virtual User? PrincipalInvestigator { get; set; }

    public required decimal? Budget { get; set; }
}
