using PCStore.Infrastrucure.Data;

namespace PCStore.Core.Models.Device
{
    public interface IDeviceViewModel
    {
        Guid Id { get; set; }

        decimal Price { get; set; }

        string SellerPhone { get; set; }

        User Seller { get; set; }

        string Description { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime PostedOn { get; set; }
    }
}
