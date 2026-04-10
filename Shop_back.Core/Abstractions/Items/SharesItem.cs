using Shop_back.Core.Models.Items.Smart;

public class SharesItem
{
    public Guid Id { get; set; }
    public Guid SmartId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public Discount? Discount { get; set; }
    public bool InStock { get; set; }
    public int Price { get; set; }
    public Dictionary<string, string[]> Images { get; set; } = new Dictionary<string, string[]>();
}