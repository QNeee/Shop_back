

using Shop_back.Core.Abstractions.Entity;

namespace Shop_back.Core.Models.Product
{
    public class ProductEntityBase : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ScreenSize { get; set; } = string.Empty;
        public string ScreenResolution { get; set; } = string.Empty;
        public int Cores { get; set; }
        public int PowerW { get; set; }
    }
}
