using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore.Infrastrucure.Data
{
    public class Laptop
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(30)]
        public string Barcode { get; set; }

        [Required]
        [Range(1d, 19d)]
        public double DisplaySize { get; set; }

        [Required]      //800x600
        [StringLength(9)] //1920x1024        
        public string DisplayResolution { get; set; }

        [Required]
        [StringLength(30)]
        public string CPU { get; set; }

        [Required]
        [Range(1d, 5d)]
        public double CpuSpeed { get; set; }

        [Required]
        [Range(1, 64)]
        public int RAM { get; set; }

        [Required]
        [StringLength(10)]
        public string RamType { get; set; }

        [Required]
        [Range(1, 2000)]
        public int HDD { get; set; }

        [Required]
        [StringLength(30)]
        public string GPU { get; set; }

        [Required]
        [Range(1, 8)]
        public int GpuMemory { get; set; }

        [Required]
        [StringLength(30)]
        public string Battery { get; set; }

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

        public virtual User Seller { get; set; }
    }
}
