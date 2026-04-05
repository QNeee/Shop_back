using static System.Net.WebRequestMethods;

namespace Shop_back.Core.Models.ShopItems
{

    public class Smart
    {
        private Smart(Guid id, string title, string description, int price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public static string ValidateFeld(string str, string field)
        {
            if (string.IsNullOrWhiteSpace(str))
                return $"{field} cannot be empty.";
            if (str.Length < MinStrLength || str.Length > MaxStrLength)
                return $"{field} must be between {MinStrLength} and {MaxStrLength} characters.";
            return string.Empty;
        }
        public static string ValidatePrice(int  price)
        {
            if (price <= 0) return $"price cannot be {price}";
            return string.Empty;
        }
        public const int MinStrLength = 3;
        public const int MaxStrLength = 500;
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public int Price { get; }
        public static (Smart Smart, string Error) Create(Guid id, string title, string description, int price)
        {
            string titleError = ValidateFeld(title, "Title");
            string descError = ValidateFeld(description, "Description");
            string priceError = ValidatePrice(price);
            string error = string.Join("\n", titleError, descError, priceError);
            var smart = new Smart(id, title, description, price);
            return (smart, error);
        }
    }

}
