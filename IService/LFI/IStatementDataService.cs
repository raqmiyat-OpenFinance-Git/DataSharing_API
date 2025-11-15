namespace DataSharing_API.IService.LFI;

public interface IStatementDataService
{
    Task<IEnumerable<StatementResponse>> GetStatementDataListAsync();

    Task<StatementResponse> GetStatementDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<StatementResponse>> GetStatementDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string statementstatus, string OrganizationId, string ClientId);
}
