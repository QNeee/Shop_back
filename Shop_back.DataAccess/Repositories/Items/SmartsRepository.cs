
using Microsoft.EntityFrameworkCore;
using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.Core.Models.Items.Smart;
using Shop_back.DataAccess.Entities.Items;
using System.Text.Json;
namespace Shop_back.DataAccess.Repositories.Items
{
    public class SmartsRepository : ISmartsRepository
    {
        private readonly ShopBackDbContext _context;

        public SmartsRepository(ShopBackDbContext context)
        {
            _context = context;
        }
        private static List<SmartVariantsEntity> MakeSmartVariantsEntity(Guid id ,List<SmartVariant> list)
        {
            return list.Select(v => new SmartVariantsEntity
            {
                Id = v.Id,
                SmartId = id,
                Stock = v.Options.Stock,
                Memory = v.Options.Memory,
                Storage = v.Options.Storage,
                Discount = v.Options.Discount,
                Price = v.Options.Price
            }).ToList();
        }
        public async Task<List<SmartModel>> Get()
        {
            var smartEntities = await _context.Smarts
                .AsNoTracking()
                .ToListAsync();

            var smartVariantEntities = await _context.SmartVariants
                .AsNoTracking()
                .ToListAsync();

            return smartEntities.Select(e =>
                SmartModel.Load(
                    e.Id,
                    e.Title,
                    e.Description,
                    smartVariantEntities
                        .Where(sv => sv.SmartId == e.Id)
                        .Select(s => SmartVariant.Load(
                            s.SmartId,
                            new SmartVariantOptions(
                                s.Stock,
                                s.Memory,
                                s.Storage,
                                s.Price,
                                s.Discount
                            ),
                            s.Id
                        ))
                        .ToList(),

                    JsonSerializer.Deserialize<Dictionary<string, string[]>>(
    string.IsNullOrWhiteSpace(e.Images) ? "{}" : e.Images
) ?? new Dictionary<string, string[]>()
                )
            ).ToList();
        }
        public async Task<Guid> Create(SmartModel smart)
        {
            var smartVariantEntities = MakeSmartVariantsEntity(smart.Id, smart.Variants);
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
        public async Task<Guid> UpdateMainInfo(Guid id, string title, string description)
        {
            await _context.Smarts.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, title)
                .SetProperty(b => b.Description, description));
            return id;
        }
        public async Task<Guid> UpdateSmartImages(Guid id, Dictionary<string, string[]> smartImages)
        {
            await _context.Smarts.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Images, JsonSerializer.Serialize(smartImages)));
            return id;
        }
        public async Task<Guid> UpdateVariants(Guid id, List<SmartVariant> variants)
        {
            await _context.Smarts.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Variants, MakeSmartVariantsEntity(id, variants)));
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Smarts.Where(s => s.Id == id).ExecuteDeleteAsync();
            return id;
        }

    }
}
