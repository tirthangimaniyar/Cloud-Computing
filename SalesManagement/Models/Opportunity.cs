using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Models
{
    public class Opportunity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string ClientName { get; set; } = string.Empty;
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExpectedRevenue { get; set; }
        
        [Required]
        public string Status { get; set; } = "Open"; // Open, Won, Lost
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        [Required]
        public int CreatedUserId { get; set; }
        
        [ForeignKey("CreatedUserId")]
        public virtual User? CreatedBy { get; set; }
    }
}
