

using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.Core.Models.ShopItems;
namespace Shop_back.Services.Items
{
    public class SmartsService : ISmartsService
    {
        private readonly ISmartsRepository _smartsReposiroty;
        public SmartsService(ISmartsRepository smartsReposiroty)
        {
            _smartsReposiroty = smartsReposiroty;
        }
        public async Task<List<Smart>> GetAllSmarts()
        {
            return await _smartsReposiroty.Get();
        }
        public async Task<Guid> CreateSmart(Smart smart)
        {
            return await _smartsReposiroty.Create(smart);
        }
        public async Task<Guid> UpdateSmart(Guid id, string title, string description, int price)
        {
            return await _smartsReposiroty.Update(id, title, description, price);
        }
        public async Task<Guid> DeleteSmart(Guid id)
        {
            return await _smartsReposiroty.Delete(id);
        }
    }
}
