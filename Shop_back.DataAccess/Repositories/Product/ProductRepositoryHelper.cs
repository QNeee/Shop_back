
using Shop_back.Core.Models.Product;
using Shop_back.Core.Models.Shares;
using Shop_back.DataAccess.Entities.Product;
using Shop_back.DataAccess.Entities.Shares;
using System.Text.Json;

namespace Shop_back.DataAccess.Repositories.Product
{
    public class DiscountAndPriceAndAvailable
    {
        public Discount? Discount {  get; set; }
        public int Price { get; set; }
        public int Stock  { get; set; }    
    }
    public class ProductRepositoryHelper
    {
        public static readonly int Min_Length_STR = 5;
        public static readonly int Max_Length_STR = 500;
        private static Dictionary<string, string[]> MakeProductImages(string images)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string[]>>(string.IsNullOrWhiteSpace(images) ? "{}" : images) ?? new Dictionary<string, string[]>();
        }
        private static List<ProductModelVariant> MakeProductVariants(string variants)
        {
            return JsonSerializer.Deserialize<List<ProductModelVariant>>(string.IsNullOrWhiteSpace(variants) ? "[]" : variants) ?? new List<ProductModelVariant>();
        }
  
        public static ProductModel MakeProductModel(ProductEntity p, DiscountAndPriceAndAvailable dapa)
        {
            return new ProductModel(p.Id, p.Title, p.Description, MakeProductImages(p.Images), MakeProductVariants(p.Variants), p.Type, MakeProductOptions(p.Options), dapa.Discount, dapa.Price, dapa.Stock);
        }
        public static Dictionary<string, string> MakeProductOptions(string options)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(string.IsNullOrWhiteSpace(options) ? "{}" : options) ?? new Dictionary<string, string>();
        }
        public static DiscountAndPriceAndAvailable MakeDiscount(string productVariants, SharesEntity? e)
        {
            var variants = MakeProductVariants(productVariants);
            var result = new DiscountAndPriceAndAvailable { Discount = null, Stock = 0 };
            if (e != null) 
            {
                result.Discount = JsonSerializer.Deserialize<Discount>(string.IsNullOrWhiteSpace(e.Discount) ? "{}" : e.Discount);
                var variant = variants.FirstOrDefault(v => v.Id == e.VariantId);
                if (variant != null)
                {
                    result.Price = variant.Price;
                    result.Stock = variant.Stock;
                }
            }
            else
            {
                result.Price = variants[0].Price;
                result.Stock = variants[0].Stock;
            }

            return result;
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
                Type = model.Type,

            };
        }

    }
}
