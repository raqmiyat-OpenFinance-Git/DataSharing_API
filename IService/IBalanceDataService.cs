using DataSharing_API.Model;

namespace DataSharing_API.IService
{
    public interface IBalanceDataService
    {
        Task<IEnumerable<BalanceData>> GetBalanceDataListAsync();

        Task<BalanceData> GetBalanceDataByRefIdAsync(string CorrelationId);

        Task<IEnumerable<BalanceData>> GetBalanceDataSearchByIdAsync(string AccountId,string Fromdate, string todate,string ConsentId,string balancestatus, string OrganizationId, string ClientId, string amount);
    }
}
