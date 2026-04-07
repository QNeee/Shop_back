
using Microsoft.EntityFrameworkCore;
using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.Core.Models.Items.Smart;
using Shop_back.DataAccess.Entities.Items;
namespace Shop_back.DataAccess.Repositories.Items
{
    public class SmartsRepository : ISmartsRepository
    {
        private readonly ShopBackDbContext _context;

        public SmartsRepository(ShopBackDbContext context)
        {
            _context = context;
        }
        public async Task<List<Smart>> Get()
        {
            var smartEntities = await _context.Smarts
                .AsNoTracking()
                .ToListAsync();

            var smartVariantEntities = await _context.SmartVariants
                .AsNoTracking()
                .ToListAsync();

            return smartEntities.Select(e =>
                Smart.Load(
                    e.Id,
                    e.Title,
                    e.Description,
                    smartVariantEntities
                        .Where(sv => sv.SmartId == e.Id)
                        .Select(s => SmartVariant.Load(
                            s.SmartId,
                            new SmartVariantOptions(
                                s.Stock,
                                s.Color,
                                s.Memory,
                                s.Storage,
                                s.Price,
                                s.Discount
                            ),
                            s.Id
                        ))
                        .ToList()
                )
            ).ToList();
        }
        public async Task<Guid> Create(Smart smart)
        {
            var smartVariantEntities = smart.Variants.Select(v => new SmartVariantsEntity
            {
                Id = v.Id,
                SmartId = smart.Id,
                Stock = v.Options.Stock,
                Color = v.Options.Color,
                Memory = v.Options.Memory,
                Storage = v.Options.Storage,
                Discount = v.Options.Discount,
                Price = v.Options.Price
            }).ToList();
            var smartEntity = new SmartEntity
            {
                Id = smart.Id,
                Title = smart.Title,
                Description = smart.Description,
                Variants = smartVariantEntities
            };

            await _context.Smarts.AddAsync(smartEntity);
            await _context.SaveChangesAsync();

            return smart.Id;
        }
        public async Task<Guid> Update(Guid id, string title, string description)
        {
            await _context.Smarts.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, title)
                .SetProperty(b => b.Description, description));
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Smarts.Where(s => s.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }
}
