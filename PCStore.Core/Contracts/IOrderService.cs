using PCStore.Core.Models;

namespace PCStore.Core.Contracts
{
    public interface IOrderService
    {
        Task PlaceOrder(CustomerOrder order);
    }
}
