using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cityinfo.API.Entities
{
    public class city
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a name to post")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public ICollection<PointOfInterest> PointOfInterest { get; set; } = new List<PointOfInterest>();
    }
}
