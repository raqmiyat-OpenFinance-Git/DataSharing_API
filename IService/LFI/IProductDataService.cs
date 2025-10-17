namespace DataSharing_API.IService.LFI;

public interface IProductDataService
{
    Task<IEnumerable<ProductResponse>> GetProductDataListAsync();

    Task<ProductResponse> GetProductDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<ProductResponse>> GetProductDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type);
}
