namespace DataSharing_API.IService.TPP;

public interface ITppAccountDataService
{
    Task<IEnumerable<TPPAccountDataResponse>> GetTppAccountDataListAsync();

    Task<TPPAccountDataResponse> GetTppAccountDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TPPAccountDataResponse>> GetTppAccountDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string? Accountstatus, string? OrganizationId, string? ClientId);
}
