using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cityinfo.API.Entities
{
    public class PointOfInterest
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a name to post")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)] 
        public string Description { get; set; }

        [ForeignKey("CityId")]

        public city City { get; set; }
        public int CityId { get; set; }

    }
}
