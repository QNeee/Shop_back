namespace Shop_back.DataAccess.Entities.Items
{
    public class SmartVariantsEntity
    {
        public Guid Id { get; set; }
        public Guid SmartId { get; set; }
        public int Stock { get; set; }
        public string Memory { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public int Price { get; set; }
        public int? Discount { get; set; }
        public SmartEntity Smart { get; set; } = null!;
    }
}