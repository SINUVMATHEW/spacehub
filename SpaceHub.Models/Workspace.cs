using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpaceHub.Models

{

    public class Workspace
    {

        [Key]
        public int Id { get; set; }


        [DisplayName("Seat Number")]
        [Required(ErrorMessage = "Please enter a seat Number")]
        [Range(1, 1000, ErrorMessage = "Seat Number should be between 1-1000")]
        public int SeatNo { get; set; }


        [DisplayName("Module")]
        [Required(ErrorMessage = "Please enter a Module Number")]
        [Range(1, 100, ErrorMessage = "Module should be between 1-100")]
        public int Module { get; set; }

        [DisplayName("Building")]
        [Required(ErrorMessage = "Please enter a Building Name")]
        [MaxLength(40, ErrorMessage = "Building Name should be less than 40 Characters")]
        public string? Building { get; set; }



    }
}
