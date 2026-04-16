using Microsoft.EntityFrameworkCore;
using Shop_back.Core.Abstractions.Product;
using Shop_back.Core.Models.Product;
using System.Text.Json;

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
            var productEntity = ProductRepositoryHelper.MakeProductEntity(product);
            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Products.Where(s => s.Id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<ProductModel>> Get()
        {
            return await _context.Products.Select(p => ProductRepositoryHelper.MakeProductModel(p, ProductRepositoryHelper.MakeDiscount(p.Variants, _context.Shares.FirstOrDefault(sh => sh.ProductId == p.Id))))
              .ToListAsync();
        }
        public async Task<List<ProductModel>> GetByFilter(string filter)
        {
            return await _context.Products
                .Where(p => p.Type == filter)
                .Select(p => ProductRepositoryHelper.MakeProductModel(p, ProductRepositoryHelper.MakeDiscount(p.Variants, _context.Shares.FirstOrDefault(sh => sh.ProductId == p.Id))))
                .ToListAsync();
        }

        public async Task<ProductModel?> GetById(Guid id)
        {
            return await _context.Products.Where(p => p.Id == id).Select(p => ProductRepositoryHelper.MakeProductModel(p, ProductRepositoryHelper.MakeDiscount(p.Variants, _context.Shares.FirstOrDefault(sh => sh.ProductId == p.Id)))).FirstOrDefaultAsync();
        }
        public async Task<Guid> UpdateProductMainInfo(Guid id, string title, string description)
        {
            await _context.Products.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, title)
                .SetProperty(b => b.Description, description));
            return id;
        }
        public async Task<Guid> UpdateProductImages(Guid id, Dictionary<string, string[]> smartImages)
        {
            await _context.Products.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Images, JsonSerializer.Serialize(smartImages)));
            return id;
        }
        public async Task<Guid> UpdateProductVariants(Guid id, List<ProductModelVariant> variants)
        {
            await _context.Products.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Variants, JsonSerializer.Serialize(variants)));
            return id;
        }

        public async Task<Guid> UpdateProductOptions(Guid id, Dictionary<string, string> options)
        {
            await _context.Products.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Options, JsonSerializer.Serialize(options)));
            return id;
        }
    }
}
