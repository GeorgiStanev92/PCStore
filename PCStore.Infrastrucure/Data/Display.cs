using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore.Infrastrucure.Data
{
    public class Display
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(30)]
        public string Barcode { get; set; }

        [Required]
        [StringLength(10)]
        public string Resolution { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        [Required]
        [Range(128000d, 18000000d)]
        public double Colors { get; set; }

        [Required]
        [Range(1, 10000)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; } = DateTime.Today;

        public int ItemsCount { get; set; } = 0;

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
