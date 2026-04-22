using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Models
{
    public class Proposal
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public int CreatedUserId { get; set; }
        
        public DateTime Timestamp { get; set; } = DateTime.Now;
        
        public int ChanceToClose { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal EstimatedBudget { get; set; }
        
        public int Duration { get; set; }
        
        public string? ContactName { get; set; }
        
        public string? ContactMobile { get; set; }
        
        public string? Description { get; set; }
        
        public string? Notes { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Revenue { get; set; }
        
        public bool IsAccepted { get; set; }
        
        public string? RejectionReason { get; set; }

        [ForeignKey("CreatedUserId")]
        public virtual User? CreatedBy { get; set; }
    }
}
