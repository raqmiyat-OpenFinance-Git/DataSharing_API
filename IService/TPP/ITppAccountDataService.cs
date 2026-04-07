namespace DataSharing_API.IService.TPP;

public interface ITppAccountDataService
{
    Task<IEnumerable<TPPAccounDataResponse>> GetTppAccountDataListAsync();

    Task<TPPAccounDataResponse> GetTppAccountDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TPPAccounDataResponse>> GetTppAccountDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string? Accountstatus, string? OrganizationId, string? ClientId);
}
