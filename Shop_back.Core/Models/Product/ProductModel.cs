using Shop_back.Core.Models.Shares;

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
        public bool IsDiscount { get; set; } = false;

        public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();
        public ProductModel(string title, string description, Dictionary<string, string[]> images, List<ProductModelVariant> variants,string type, Dictionary<string, string> options,bool isDiscount = false)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Images = images;
            Variants = variants;
            Type = type;
            IsDiscount = isDiscount;
            Options = options;
        }
        public ProductModel(Guid id,string title, string description, Dictionary<string, string[]> images, List<ProductModelVariant> variants ,string type, Dictionary<string, string> options, bool isDiscount = false)
        {
            Id = id;
            Title = title;
            Description = description;
            Images = images;
            Variants = variants;
            Type = type;
            IsDiscount = isDiscount;
            Options = options;
        }
    }
}
