
using Shop_back.Core.Models.Product;
using Shop_back.DataAccess.Entities.Product;
using System.Text.Json;

namespace Shop_back.DataAccess.Repositories.Product
{
    public class ProductRepositoryHelper
    {
        public static readonly int Min_Length_STR = 5;
        public static readonly int Max_Length_STR = 500;
        private static Dictionary<string, string[]> MakeProductImages(string images)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string[]>>(string.IsNullOrWhiteSpace(images) ? "{}" : images) ?? new Dictionary<string, string[]>();
        }
        private static List<ProductModelVariant> MakeProductVariants (string variants)
        {
            return JsonSerializer.Deserialize<List<ProductModelVariant>>(string.IsNullOrWhiteSpace(variants) ? "[]" : variants) ?? new List<ProductModelVariant>();
        }
        public static ProductModel MakeProductModel(ProductEntity p)
        {
            return new ProductModel(p.Id, p.Title, p.Description, MakeProductImages(p.Images), MakeProductVariants(p.Variants), p.Type);
        }
        public static ProductEntity MakeProductEntity(ProductModel model)
        {
            return new ProductEntity
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Images = JsonSerializer.Serialize(model.Images),
                Variants = JsonSerializer.Serialize(model.Variants),
                Type = model.Type
            };
        }

    }
}
