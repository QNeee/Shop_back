
namespace Shop_back.Core.Models.Items.Smart
{
    public class SmartVariantOptions
    {
        public int Stock { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Memory { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public int? Discount { get; set; }
        public int Price { get; set; }
        public SmartVariantOptions() { }
        public SmartVariantOptions(
            int stock,
            string color,
            string memory,
            string storage,
            int price,
            int? discount = null)
        {
            Stock = stock;
            Color = color;
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

        public static string ValidateColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
                return "Color cannot be empty.";

            if (color.Length < MinColorLength || color.Length > MaxColorLength)
                return $"Color must be between {MinColorLength} and {MaxColorLength} characters.";

            return string.Empty;
        }
        public static SmartVariant Load(Guid smartId, SmartVariantOptions options, Guid id)
        {
            return new SmartVariant(smartId, options, id);
        }
        public static string ValidatePrice(int price)
        {
            if (price <= 0)
                return $"Price cannot be {price}.";

            return string.Empty;
        }

        public static string ValidateStock(int stock)
        {
            if (stock < 0)
                return "Stock cannot be negative.";

            return string.Empty;
        }
    }
}
