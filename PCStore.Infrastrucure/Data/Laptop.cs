using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore.Infrastrucure.Data
{
    public class Laptop
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Range(1d, 19d)]
        public double DisplaySize { get; set; }

        [Required] //800x600
        [MaxLength(9)] //1920x1024        
        public string DisplayResolution { get; set; }

        [Required]
        [MaxLength(30)]
        public string CPU { get; set; }

        [Required]
        [Range(1d, 5d)]
        public double CpuSpeed { get; set; }

        [Required]
        [Range(1, 64)]
        public int RAM { get; set; }

        [Required]
        [MaxLength(10)]
        public string RamType { get; set; }

        [Required]
        [Range(1, 2000)]
        public int HDD { get; set; }

        [Required]
        [MaxLength(30)]
        public string GPU { get; set; }

        [Required]
        [Range(1, 8)]
        public int GpuMemory { get; set; }

        [Required]
        [MaxLength(30)]
        public string Battery { get; set; }

        [Required]
        [MaxLength(30)]
        public string OpticalDevice { get; set; }

        [Required]
        [MaxLength(20)]
        public string OperatingSystem { get; set; }

        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(12)]
        public string SellerPhone { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; } = DateTime.Today;

        public int ItemsCount { get; set; } = 0;

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public virtual User Seller { get; set; }
    }
}
