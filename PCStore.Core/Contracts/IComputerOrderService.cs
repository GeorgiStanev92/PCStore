using PCStore.Core.Models;

namespace PCStore.Core.Contracts
{
    public interface IComputerOrderService
    {
        Task PlaceOrder(CustomerOrder order);
    }
}
