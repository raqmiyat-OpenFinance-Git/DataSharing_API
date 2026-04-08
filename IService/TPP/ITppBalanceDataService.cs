namespace DataSharing_API.IService.TPP;

public interface ITppBalanceDataService
{
    Task<IEnumerable<TppBalanceData>> GetTppBalanceDataListAsync();

    Task<TppBalanceData> GetTppBalanceDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TppBalanceData>> GetTppBalanceDataSearchByIdAsync(string AccountId, string Fromdate, string todate, string ConsentId, string balancestatus, string OrganizationId, string ClientId, string amount);
}
