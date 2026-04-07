using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Core.Abstractions.Items.Smarts
{
    public interface ISmartsService
    {
        Task<Guid> CreateSmart(SmartModel smart);
        Task<Guid> DeleteSmart(Guid id);
        Task<SmartModel?> GetSmartById(Guid id);
        Task<List<SmartModel>> GetAllSmarts();
        Task<Guid> UpdateSmartImages(Guid id, Dictionary<string, string[]> SmartImages);
    }
}