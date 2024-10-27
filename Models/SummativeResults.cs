using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTechAuth.Models
{
    public class SummativeResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } // Updated to match the database column name

        [Required]
        [StringLength(100)]
        public string Scope { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Result { get; set; } // Decimal type for calculated result

        [Required]
        public DateTime DateTime { get; set; }
    }

}
