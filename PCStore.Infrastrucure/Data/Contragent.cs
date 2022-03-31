using System.ComponentModel.DataAnnotations;

namespace PCStore.Infrastrucure.Data
{
    public class Contragent
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required()]
        [StringLength(20)]
        public string CustomerNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(20)]
        public string? Identifier { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public IList<Deal> Deals { get; set; } = new List<Deal>();
    }
}
