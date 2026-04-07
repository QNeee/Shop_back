namespace Shop_back.Contracts.Request.items.Smart
{
    public record SmartVariantOptionsRequest(
      int Stock,
      string Color,
      string Memory,
      string Storage,
      int Price,
      int? Discount
  );
    public record CreateSmartRequest(
        string Title,
        string Description,
        SmartVariantOptionsRequest[] Options
    );
}
