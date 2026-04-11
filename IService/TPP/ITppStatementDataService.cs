namespace DataSharing_API.IService.TPP;

public interface ITppStatementDataService
{
    Task<IEnumerable<TppStatementResponse>> GetTppStatementDataListAsync();

    Task<TppStatementResponse> GetTppStatementDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TppStatementResponse>> GetTppStatementDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string statementstatus, string? LFIName, string? LFIId);
}
