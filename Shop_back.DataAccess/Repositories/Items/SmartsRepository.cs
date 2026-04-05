
using Microsoft.EntityFrameworkCore;
using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.Core.Models.ShopItems;
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
            var smartEntities = await _context.Smarts.AsNoTracking().ToListAsync();
            var smarts = smartEntities.Select(e => Smart.Create(e.Id, e.Title, e.Description, e.Price).Smart).ToList();
            return smarts;
        }
        public async Task<Guid> Create(Smart smart)
        {
            var bookEntity = new SmartEntity
            {
                Id = smart.Id,
                Title = smart.Title,
                Description = smart.Description,
                Price = smart.Price
            };

            await _context.Smarts.AddAsync(bookEntity);
            await _context.SaveChangesAsync();
            return smart.Id;
        }
        public async Task<Guid> Update(Guid id, string title, string description, int price)
        {
            await _context.Smarts.Where(s => s.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, title)
                .SetProperty(b => b.Description, description)
                .SetProperty(b => b.Price, price));
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Smarts.Where(s => s.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }
}
