

using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.Core.Models.Items.Smart;
namespace Shop_back.Services.Items
{
    public class SmartServices : ISmartsService
    {
        private readonly ISmartsRepository _smartsReposiroty;
        public SmartServices(ISmartsRepository smartsReposiroty)
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
        public async Task<Guid> UpdateSmart(Guid id, string title, string description)
        {
            return await _smartsReposiroty.Update(id, title, description);
        }
        public async Task<Guid> DeleteSmart(Guid id)
        {
            return await _smartsReposiroty.Delete(id);
        }
        public async Task<Smart?> GetSmartById(Guid id)
        {
            var smarts = await _smartsReposiroty.Get();
            return smarts.FirstOrDefault(s => s.Id == id);
        }
    }
}
