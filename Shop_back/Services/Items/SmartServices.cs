

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
        public async Task<List<SmartModel>> GetAllSmarts()
        {
            return await _smartsReposiroty.Get();
        }
        public async Task<Guid> CreateSmart(SmartModel smart)
        {
            return await _smartsReposiroty.Create(smart);
        }
        public async Task<Guid> DeleteSmart(Guid id)
        {
            return await _smartsReposiroty.Delete(id);
        }
        public async Task<SmartModel?> GetSmartById(Guid id)
        {
            var smarts = await _smartsReposiroty.Get();
            return smarts.FirstOrDefault(s => s.Id == id);
        }

        public async Task<Guid> UpdateSmartImages(Guid id, Dictionary<string, string[]> SmartImages)
        {
            return await _smartsReposiroty.Update(id, SmartImages);
        }
    }
}
