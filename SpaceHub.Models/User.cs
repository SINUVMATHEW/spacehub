using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpaceHub.Models
{
    public class User
    {
        [Required]
        [Key]
        [DisplayName("User ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name should be smaller than 50 charachter")]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }

    }
}
