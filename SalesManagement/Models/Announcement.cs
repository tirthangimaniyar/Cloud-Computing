using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Message { get; set; } = string.Empty;
        
        [Required]
        public string Date { get; set; } = string.Empty; // Store as string as per requirement
        
        [Required]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
