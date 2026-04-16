using Shop_back.Core.Abstractions.Shares;


namespace Shop_back.Core.Models.Shares
{
    public class Discount
    {
        public int Percentage { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
    public class Share
    {
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public Discount Discount { get; set; } = new Discount();
    }
    public class SharesModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Discount? Discount { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public Dictionary<string, string[]> Images { get; set; } = new Dictionary<string, string[]>();
    }
}
