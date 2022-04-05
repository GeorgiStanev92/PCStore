using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore.Infrastrucure.Data
{
    public class Computer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(30)]
        public string Barcode { get; set; }

        [Required]
        [StringLength(30)]
        public string CPU { get; set; }

        [Required]
        [Range(1d, 5d)]
        public double CPUSpeed { get; set; }

        [Required]
        [Range(1, 128)]
        public int RAM { get; set; }

        [Required]
        [StringLength(10)]
        public string RAMType { get; set; }

        [Required]
        [StringLength(20)]
        public string GPU { get; set; }

        [Required]
        [Range(1, 12)]
        public int GPUMemory { get; set; }

        [Required]
        [Range(1, 2000)]
        public int HDD { get; set; }

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

        [StringLength(200)]
        public string? Description { get; set; }

        public virtual User Seller { get; set; }
    }
}
