namespace DataSharing_API.IService.TPP;

public interface ITppDirectDebitDataService
{
    Task<IEnumerable<TppDirectDebitResponse>> GetTppDirectdebitDataListAsync();

    Task<TppDirectDebitResponse> GetTppDirectdebitDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TppDirectDebitResponse>> GetTppDirectdebitDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string status, string LFIName, string LFIId);
}
