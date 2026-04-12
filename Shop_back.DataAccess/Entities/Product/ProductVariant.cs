
using Shop_back.Core.Models.Shares;

namespace Shop_back.DataAccess.Entities.Product
{
    public class ProductVariant
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Stock { get; set; }
        public string Memory { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public int Price { get; set; }
        public Discount? Discount { get; set; }
        public ProductVariant(Guid productId, int stock, string memory, string storage, int price, Discount? discount = null)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Stock = stock;
            Memory = memory;
            Storage = storage;
            Price = price;
            Discount = discount;
        }
    }
}
