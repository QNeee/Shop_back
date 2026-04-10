
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
        private static List<SmartVariantsEntity> MakeSmartVariantsEntity(Guid id, List<SmartVariant> list)
        {
            return list.Select(v => new SmartVariantsEntity
            {
                Id = v.Id,
                SmartId = id,
                Stock = v.Options.Stock,
                Memory = v.Options.Memory,
                Storage = v.Options.Storage,
                Discount = JsonSerializer.Serialize(v.Options.Discount),
                Price = v.Options.Price
            }).ToList();
        }
        private static Discount? MakeDiscount(string entityDiscount)
        {
            var optionsJson = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Discount? discount = null;
            if (!string.IsNullOrWhiteSpace(entityDiscount))
            {
                discount = JsonSerializer.Deserialize<Discount>(entityDiscount, optionsJson);
            }
            return discount;
        }
        private static SmartVariant MakeSmartVariant(SmartVariantsEntity entity)
        {

            Discount? discount = MakeDiscount(entity.Discount ?? "");

            var options = new SmartVariantOptions(
                entity.Stock,
                entity.Memory,
                entity.Storage,
                entity.Price,
                discount
            );
            return SmartVariant.Load(entity.SmartId, options, entity.Id);
        }
        private static SharesItem MakeSharesItem(string title, string images, SmartVariantsEntity e)
        {
            var sharesItem  = new SharesItem
            {
                Id = e.Id,
                Title = $"{title} {e.Memory} / {e.Storage}",
                SmartId = e.SmartId,
                Discount = MakeDiscount(e.Discount),
                InStock = e.Stock > 0,
                Price = e.Price,
                Images = MakeSmartImages(images),
                Type = "smart"
            };
            return sharesItem;
        }
        private static Dictionary<string, string[]> MakeSmartImages(string images)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string[]>>(string.IsNullOrWhiteSpace(images) ? "{}" : images) ?? new Dictionary<string, string[]>();
        }
        private static SmartModel MakeSmartModel(SmartEntity e, List<SmartVariantsEntity> sVe)
        {
            return SmartModel.Load(
                    e.Id,
                    e.Title,
                    e.Description,
                    sVe
                        .Where(sE => sE.SmartId == e.Id)
                        .Select(sE => MakeSmartVariant(sE)).ToList(),
                    MakeSmartImages(e.Images)
                    );
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
                MakeSmartModel(e, smartVariantEntities)).ToList();
        }
        public async Task<Guid> Create(SmartModel smart)
        {

            var smartVariantEntities = MakeSmartVariantsEntity(smart.Id, smart.Variants);
            var smartEntity = new SmartEntity
            {
                Id = smart.Id,
                Title = smart.Title,
                Description = smart.Description,
                Variants = smartVariantEntities,
                Images = JsonSerializer.Serialize(smart.SmartImages)
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

        public async Task<List<SharesItem>> GetSharesSmarts()
        {
            return await _context.SmartVariants.AsNoTracking()
                .Where(sv => sv.Discount != "null")
                .Select(sv => MakeSharesItem(sv.Smart.Title, sv.Smart.Images, sv)).ToListAsync();
        }
    }
}
