namespace DataSharing_API.IService.LFI;

public interface IDirectDebitDataService
{
    Task<IEnumerable<DirectDebitResponse>> GetDirectdebitDataListAsync();

    Task<DirectDebitResponse> GetDirectdebitDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<DirectDebitResponse>> GetDirectdebitDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type);
}
