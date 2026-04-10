using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Core.Abstractions.Items.Smarts
{
    public interface ISmartsService
    {
        Task<Guid> CreateSmart(string title, string description, SmartVariantOptions[] options, Dictionary<string, string[]> SmartImages);
        Task<Guid> DeleteSmart(Guid id);
        Task<SmartModel?> GetSmartById(Guid id);
        Task<List<SmartModel>> GetAllSmarts();
        Task<Guid> UpdateSmartImages(Guid id, Dictionary<string, string[]> SmartImages);
        Task<Guid> UpdateSmartMainInfo(Guid id, string title, string desc);
        Task<Guid> UpdateSmartVariants(Guid id, List<SmartVariant> variants);
    }
}