using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore.Infrastrucure.Data
{
    public class DealSubject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(DealId))]
        public Guid DealId { get; set; }

        [ForeignKey(nameof(ComputerId))]
        public Guid ComputerId { get; set; }

        [ForeignKey(nameof(LaptopId))]
        public Guid LaptopId { get; set; }

        [ForeignKey(nameof(DisplayId))]
        public Guid DisplayId { get; set; }

        public int ItemCount { get; set; }

        public Deal Deal { get; set; }

        public Computer Computer { get; set; }

        public Laptop Laptop { get; set; }

        public Display Display { get; set; }
    }
}
