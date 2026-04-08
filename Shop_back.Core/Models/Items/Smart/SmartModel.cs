
namespace Shop_back.Core.Models.Items.Smart
{
    public class SmartModel
    {
        public SmartModel(string title, string description, SmartVariantOptions[] options, Dictionary<string, string[]> images)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            foreach (var option in options)
            {
                var newVariant = new SmartVariant(Id, option);
                Variants.Add(newVariant);
            }
            SmartImages = images;
        }
        public SmartModel (Guid id, string title, string description, List<SmartVariant> variants, Dictionary<string, string[]> images)
        {
            Id = id;
            Title = title;
            Description = description;
            Variants= variants;
            SmartImages = images;
        }
        public const int MinStrLength = 3;
        public const int MaxStrLength = 500;
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public List<SmartVariant> Variants { get; } = new List<SmartVariant>();
        public Dictionary<string, string[]> SmartImages { get; } = new Dictionary<string, string[]>();
        public static SmartModel Load(Guid id, string title, string description, List<SmartVariant> variants, Dictionary<string, string[]> images)
        {
            return new SmartModel(id, title, description, variants, images);
        }
    }

}
