
namespace Shop_back.Core.Models.Items.Smart
{

    public class Smart
    {
        public Smart(string title, string description, SmartVariantOptions[] options, Guid id = default)
        {
            Id = id == default ? Guid.NewGuid() : id;
            Title = title;
            Description = description;
            foreach (var option in options)
            {
                var newVariant = new SmartVariant(Id, option);
                Variants.Add(newVariant);
            }
        }
        public Smart (Guid id, string title, string description, List<SmartVariant> variants)
        {
            Id = id;
            Title = title;
            Description = description;
            Variants= variants;
        }
        public const int MinStrLength = 3;
        public const int MaxStrLength = 500;
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public List<SmartVariant> Variants { get; } = new List<SmartVariant>();
        public static Smart Load(Guid id, string title, string description, List<SmartVariant> variants)
        {
            return new Smart(id ,title, description, variants);
        }
        public static Smart Create(string title, string description, SmartVariantOptions[] options)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty");

            if (options == null || options.Length == 0)
                throw new ArgumentException("Options cannot be empty");

            return new Smart(title, description, options);
        }
    }

}
