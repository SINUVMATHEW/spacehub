
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SpaceHub.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Dateof Booking")]
        public DateOnly BookingDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int WorkspaceId { get; set; }
        [ForeignKey("UserId")]
        public User ?User { get; set; }
        [ForeignKey("WorkspaceId")]
        public Workspace ?Workspace { get; set; }
    }
}
