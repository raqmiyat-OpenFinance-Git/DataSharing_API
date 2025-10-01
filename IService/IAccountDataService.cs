
using DataSharing_API.Model;


namespace DataSharing_API.IService
{
    public interface IAccountDataService
    {
        Task<IEnumerable<AccountDataResponse>> GetAccountDataListAsync();

        Task<AccountDataResponse> GetAccountDataByRefIdAsync(string CorrelationId);

        Task<IEnumerable<AccountDataResponse>> GetAccountDataSearchByIdAsync(string Fromdate, string todate, string ConsentId,string AccountId, string Type, string? Accountstatus, string? OrganizationId, string? ClientId);
    }
}
