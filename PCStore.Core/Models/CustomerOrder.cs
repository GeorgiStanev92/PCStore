namespace PCStore.Core.Models
{
    public class CustomerOrder
    {
        public string CustomerNumber { get; set; }

        public List<ComputerOrder> Computers { get; set; } = new List<ComputerOrder>();

        public List<LaptopOrder> Laptops { get; set; } = new List<LaptopOrder>();

        public List<DisplayOrder> Displays { get; set; } = new List<DisplayOrder>();
    }
}
