

using Microsoft.EntityFrameworkCore;
using Shop_back.Core.Abstractions.Shares;
using Shop_back.Core.Models.Shares;
using System.Text.Json;

namespace Shop_back.DataAccess.Repositories.Shares
{
    public class SharesRepository : ISharesRepository
    {
        private readonly ShopBackDbContext _context;
        public SharesRepository(ShopBackDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateShare(Share share)
        {
            var shareEntity = SharesRepositoryHelper.MakeShareEntity(share);
            await _context.Shares.AddAsync(shareEntity);
            await _context.SaveChangesAsync();
            return shareEntity.Id;
        }

        public async Task<List<SharesModel>> GetAllShares()
        {
            var shares = await _context.Shares
    .Include(s => s.Product)
    .ToListAsync();

            var result = shares
                .Select(share =>
                {
                    var variant = SharesRepositoryHelper.MakeProductVariant(
                        share.Product.Variants,
                        share.VariantId);

                    if (variant == null) return null;

                    return new SharesModel
                    {
                        Id = variant.Id,
                        ProductId = share.ProductId,
                        Title = $"{share.Product?.Title} {variant.Memory}/{variant.Storage}",
                        Type = share.Product?.Type ?? "",
                        Discount = JsonSerializer.Deserialize<Discount>(share.Discount),
                        Stock = variant.Stock,
                        Price = variant.Price,
                        Images = JsonSerializer.Deserialize<Dictionary<string, string[]>>(share.Product?.Images ?? "") ?? new Dictionary<string, string[]>()

                    };
                })
                .Where(x => x != null)
                .Select(x => x!)
                .ToList();
            return result;
        }
    }
}
