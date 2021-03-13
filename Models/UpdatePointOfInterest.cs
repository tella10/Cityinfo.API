using System.ComponentModel.DataAnnotations;

namespace Cityinfo.API.Models
{
    public class UpdatePointOfInterest
    {
        [Required(ErrorMessage = "You should provide a name to post")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
