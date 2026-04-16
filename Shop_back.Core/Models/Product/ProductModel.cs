using Shop_back.Core.Models.Shares;
using System.Collections;

namespace Shop_back.Core.Models.Product
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Dictionary<string, string[]> Images { get; set; } = new Dictionary<string, string[]>();
        public string Type { get; set; } = string.Empty;
        public List<ProductModelVariant> Variants { get; set; } = new List<ProductModelVariant>();

        public int? Price { get; set; }
        public Discount? Discount { get; set; }
        public int Stock { get; set; }
        public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();
        public ProductModel(string title, string description, Dictionary<string, string[]> images, List<ProductModelVariant> variants, string type, Dictionary<string, string> options, Discount? discount = null, int? price = null, int stock = 0)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Images = images;
            Price = price;
            Variants = variants;
            Type = type;
            Options = options;
            Discount = discount;
            Stock = stock;
        }
        public ProductModel(Guid id, string title, string description, Dictionary<string, string[]> images, List<ProductModelVariant> variants, string type, Dictionary<string, string> options, Discount? discount = null, int? price = null, int stock = 0)
        {
            Id = id;
            Title = title;
            Description = description;
            Images = images;
            Variants = variants;
            Type = type;
            Options = options;
            Discount = discount;
            Price = price;
            Stock = stock;
        }
    }
}
