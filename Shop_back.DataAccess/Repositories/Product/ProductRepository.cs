using Microsoft.EntityFrameworkCore;
using Shop_back.Core.Abstractions.Product;
using Shop_back.Core.Models.Product;
using Shop_back.Core.Models.Product.ProductCatalog;
using Shop_back.Core.Models.Product.ProductShares;
using Shop_back.Core.Models.Product.ProductVariant;
using Shop_back.DataAccess.Entities.Product;
using Shop_back.DataAccess.Entities.Product.ProductVariant;

namespace Shop_back.DataAccess.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopBackDbContext _context;
        public ProductRepository(ShopBackDbContext context)
        {
            _context = context;

        }

        public async Task<Guid> Create(ProductModel product)
        {


            var productEntity = new ProductEntity
            {
                ProductId = Guid.NewGuid(),
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                ScreenResolution = product.Options.ScreenResolution,
                ScreenSize = product.Options.ScreenSize,
                Cores = product.Options.Cores,
                PowerW = product.Options.PowerW,

            };
            productEntity.Variants = product.Variants.Select(v => new ProductVariantEntity
            {
                ProductVariantId = Guid.NewGuid(),
                StorageGb = v.StorageGb,
                MemoryGb = v.MemoryGb,
                Price = v.Price,
                Stock = v.Stock,
                DiscountPercent = v.DiscountPercent,
                DiscountExpiresAt = v.DiscountExpiresAt
            }).ToList();

            productEntity.Images = product.Images.Select(im => new ProductImageEntity { Color = im.Key, Urls = im.Value }).ToList();

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.ProductId;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Products.Where(s => s.ProductId == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<ProductCatalogModel>> GetAllCatalogProducts(int? categoryId)
        {

            var query = _context.ProductVariants.AsQueryable().AsNoTracking();

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.Product.CategoryId == categoryId.Value);
            }
            return await query.Select(p => ProductReposityoryHelper.MakeProductCatalogModel(p, p.Product.ProductId, p.Product.ProductName, p.Product.CategoryId, p.Product.Images, new ProductOptions { Cores = p.Product.Cores, ScreenResolution = p.Product.ScreenResolution, ScreenSize = p.Product.ScreenSize, PowerW = p.Product.PowerW })).ToListAsync();
        }
        public async Task<Guid> UpdateProductMainInfo(Guid id, string productName, int categoryId)
        {
            await _context.Products.Where(s => s.ProductId == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.ProductName, productName)
                .SetProperty(b => b.CategoryId, categoryId));
            return id;
        }
        public async Task<Guid> UpdateProductImages(Guid id, Dictionary<string, string[]> productImages)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            await _context.ProductImages
                .Where(x => x.ProductId == id)
                .ExecuteDeleteAsync();
            var newImages = productImages
                .Select(im => new ProductImageEntity
                {
                    ProductImageId = Guid.NewGuid(),
                    ProductId = id,
                    Color = im.Key,
                    Urls = im.Value
                })
                .ToList();

            await _context.ProductImages.AddRangeAsync(newImages);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return id;
        }
        public async Task<Guid> UpdateProductVariants(Guid id, List<ProductVariantModel> variants)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            await _context.ProductVariants
                .Where(x => x.ProductId == id)
                .ExecuteDeleteAsync();
            var newVariants = variants.Select(v => new ProductVariantEntity
            {
                ProductVariantId = Guid.NewGuid(),
                ProductId = id,
                StorageGb = v.StorageGb,
                MemoryGb = v.MemoryGb,
                Stock = v.Stock,
                Price = v.Price,
                DiscountPercent = v.DiscountPercent,
                DiscountExpiresAt = v.DiscountExpiresAt
            });

            await _context.ProductVariants.AddRangeAsync(newVariants);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return id;
        }

        public async Task<Guid> UpdateProductOptions(Guid id, ProductOptions options)
        {
            await _context.Products.Where(s => s.ProductId == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Cores, options.Cores)
                .SetProperty(b => b.PowerW, options.PowerW)
                .SetProperty(b => b.ScreenSize, options.ScreenSize)
                .SetProperty(b => b.ScreenResolution, options.ScreenResolution)
                );

            return id;
        }

        public async Task<bool> GetCategoryExists(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.CategoryId == categoryId);
        }

        public async Task<Guid> UpdateProductVariant(Guid productId, ProductVariantModel variant, Guid variantId)
        {
            var existingVariant = await _context.ProductVariants
                .FirstOrDefaultAsync(x => x.ProductVariantId == variantId
                                       && x.ProductId == productId);


            existingVariant!.StorageGb = variant.StorageGb;
            existingVariant.MemoryGb = variant.MemoryGb;
            existingVariant.Stock = variant.Stock;
            existingVariant.Price = variant.Price;
            existingVariant.DiscountPercent = variant.DiscountPercent;
            existingVariant.DiscountExpiresAt = variant.DiscountExpiresAt;

            await _context.SaveChangesAsync();

            return variantId;
        }

        public async Task<bool> GetProductVariantExists(Guid productId, Guid variantId)
        {
            return await _context.ProductVariants.AnyAsync(c => c.ProductVariantId == variantId && c.ProductId == productId);
        }

        public async Task<List<ProductSharesModel>> GetAllSharesProducts(int? categoryId)
        {
            var now = DateTime.UtcNow;

            return await _context.ProductVariants
                .Where(pv =>
                    pv.DiscountPercent != null &&
                    pv.DiscountExpiresAt != null
                )
                .Select(pv => ProductReposityoryHelper.MakeProductSharesModel(
                    pv,
                    pv.Product.ProductId,
                    pv.Product.ProductName,
                    pv.Product.CategoryId,
                    pv.Product.Images
                ))
                .ToListAsync();
        }

        public async Task<List<ProductCatalogModel>> GetAllBasketProducts(List<Guid> ids)
        {

            var query = _context.ProductVariants.AsQueryable().AsNoTracking();

            return await query.Where(p => ids.Contains(p.ProductVariantId)).Select(p => ProductReposityoryHelper.MakeProductCatalogModel(p, p.Product.ProductId, p.Product.ProductName, p.Product.CategoryId, p.Product.Images, new ProductOptions { Cores = p.Product.Cores, ScreenResolution = p.Product.ScreenResolution, ScreenSize = p.Product.ScreenSize, PowerW = p.Product.PowerW })).ToListAsync();
        }
    }
}
