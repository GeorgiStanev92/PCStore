namespace PCStore.Infrastrucure.Data
{
    public interface IDevice
    {
        decimal Price { get; set; }
        string SellerPhone { get; set; }
        User Seller { get; set; }
        string Description { get; set; }
    }
}
