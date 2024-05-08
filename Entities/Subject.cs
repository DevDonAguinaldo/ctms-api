using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities;

[Table("Subjects")]
public class Subject
{
    public int SubjectID { get; set; }
    
    public int TrialID { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    [Required]
    public DateTime DOB { get; set; }

    public required string Gender { get; set; }

    public required string EnrollmentStatus { get; set; }

    [ForeignKey("TrialID")]
    public virtual Trial? Trial { get; set; }
}
