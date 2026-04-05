namespace Shop_back.Contracts.Response.Items
{
    public record GetAllSmartsResponse(
        Guid Id,
        string Title,
        string Description,
        int Price
    );

}
