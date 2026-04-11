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
        public ProductModel(string title, string description, Dictionary<string, string[]> images, List<ProductModelVariant> variants,string type)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Images = images;
            Variants = variants;
            Type = type;
        }
        public ProductModel(Guid id,string title, string description, Dictionary<string, string[]> images, List<ProductModelVariant> variants ,string type)
        {
            Id = id;
            Title = title;
            Description = description;
            Images = images;
            Variants = variants;
            Type = type;
        }
    }
}
