

using Shop_back.Core.Models.Shares;
using Shop_back.DataAccess.Entities.Product;
using Shop_back.DataAccess.Entities.Shares;
using System.Text.Json;

namespace Shop_back.DataAccess.Repositories.Shares
{
    public class SharesRepositoryHelper
    {
        static public SharesEntity MakeShareEntity(Share share)
        {
            return new SharesEntity
            {
                Id = Guid.NewGuid(),
                ProductId = share.ProductId,
                VariantId = share.VariantId,
                Discount = JsonSerializer.Serialize(share.Discount),
            };
        }
        static public ProductVariant? MakeProductVariant(string variants,Guid varId)
        {
            var variant = JsonSerializer.Deserialize<List<ProductVariant>>(variants)?.FirstOrDefault(item => item.Id == varId);
            return variant;
        }
    }
}
