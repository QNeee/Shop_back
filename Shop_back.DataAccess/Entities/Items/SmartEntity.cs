namespace Shop_back.DataAccess.Entities.Items
{
    public class SmartEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Images { get; set; } = "{}";
        public List<SmartVariantsEntity> Variants { get; set; } = new();
    }
}