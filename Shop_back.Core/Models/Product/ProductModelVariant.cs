namespace Shop_back.Core.Models.Product
{
    public class ProductModelVariant
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Stock { get; set; }
        public string Memory { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public int Price { get; set; }
        public ProductModelVariant(Guid productId, int stock, string memory, string storage, int price)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Stock = stock;
            Memory = memory;
            Storage = storage;
            Price = price;
        }
    }
}
