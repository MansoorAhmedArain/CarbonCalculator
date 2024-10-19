using System.ComponentModel.DataAnnotations;

namespace WTechAuth.Models
{
    public class MobileCombustion
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string VehicleType { get; set; }  // e.g., Cars, Motorbikes, etc.

        [Required]
        [MaxLength(50)]
        public string FuelType { get; set; }     // e.g., Gasoline, Diesel, etc.

        [Required]
        public float EmissionFactor { get; set; }
    }
}