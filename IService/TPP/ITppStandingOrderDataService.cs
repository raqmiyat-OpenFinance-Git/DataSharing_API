namespace DataSharing_API.IService.TPP;

public interface ITppStandingOrderDataService
{
    Task<IEnumerable<TppStandOrderResponse>> GetTppStandOrderDataListAsync();

    Task<TppStandOrderResponse> GetTppStandOrderDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TppStandOrderResponse>> GetTppStandOrderDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string statementstatus, string? LFIName, string? LFIId);
}
