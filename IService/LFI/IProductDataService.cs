namespace DataSharing_API.IService.LFI;

public interface IProductDataService
{
    Task<IEnumerable<ProductResponse>> GetProductDataListAsync();

    Task<ProductResponse> GetProductDataByRefIdAsync(long RequestId);

    Task<IEnumerable<ProductResponse>> GetProductDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string Status, string OrganizationId, string ClientId, string ChargeAmount);
}
