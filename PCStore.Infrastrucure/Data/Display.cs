using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore.Infrastrucure.Data
{
    public class Display
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Range(1d, 19d)]
        public double Size { get; set; }

        [Required] //800x600
        [MaxLength(9)] //1920x1024        
        public string Resolution { get; set; }

        [Required]
        [MaxLength(5)]
        public string Type { get; set; }

        [Required]
        [Range(256000d, 17000000d)]
        public double Colors { get; set; }

        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(12)]
        public string SellerPhone { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

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
