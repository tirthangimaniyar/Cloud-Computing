using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        
        public int? ProposalId { get; set; }
        
        [Required]
        public string ProjectName { get; set; } = string.Empty;
        
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        
        [Required]
        public string Status { get; set; } = "Pending"; // Pending, In Progress, Completed
        
        [Required]
        public int CreatedUserId { get; set; }
        
        [ForeignKey("CreatedUserId")]
        public virtual User? CreatedBy { get; set; }

        [ForeignKey("ProposalId")]
        public virtual Proposal? Proposal { get; set; }
    }
}
