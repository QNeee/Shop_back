namespace Shop_back.Contracts.Request.items
{
    public record CreateSmartRequest(
        string Title,
        string Description,
        int Price
    );
}
