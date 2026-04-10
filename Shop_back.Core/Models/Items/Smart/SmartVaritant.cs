

namespace Shop_back.Core.Models.Items.Smart
{
    public class Discount
    {
        public int Percent { get; set; }
        public DateTime ExpiresAt { get; set; }

    }
    public class SmartVariantOptions
    {
        public int Stock { get; set; }
        public string Memory { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public Discount ? Discount { get; set; } 
        public int Price { get; set; }
        public SmartVariantOptions() { }
        public SmartVariantOptions(
            int stock,
            string memory,
            string storage,
            int price,
            Discount? discount = null)
        {
            Stock = stock;
            Memory = memory;
            Storage = storage;
            Discount = discount;
            Price = price;
        }
    }
    public class SmartVariant
    {
        public SmartVariant(Guid smartId, SmartVariantOptions options, Guid id = default)
        {
            Id = id == default ? Guid.NewGuid() : id;
            SmartId = smartId;
            Options = options;
        }

        public const int MinColorLength = 2;
        public const int MaxColorLength = 50;

        public Guid Id { get; }
        public Guid SmartId { get; }
        public SmartVariantOptions Options { get; }

        public static SmartVariant Load(Guid smartId, SmartVariantOptions options, Guid id)
        {
            return new SmartVariant(smartId, options, id);
        }

    }
}
