using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCStore.Infrastrucure.Data
{
    public class Deal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(ContragentId))]
        public Guid ContragentId { get; set; }

        public Contragent Contragent { get; set; }

        public IList<DealSubject> DealSubjects { get; set; }
    }
}
