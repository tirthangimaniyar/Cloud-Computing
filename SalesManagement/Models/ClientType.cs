using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Models
{
    public class ClientType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
