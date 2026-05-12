namespace DataSharing_API.IService.LFI;

public interface IAccountDataService
{
    Task<IEnumerable<AccountDataResponse>> GetAccountDataListAsync(string AccountType);

    Task<AccountDataResponse> GetAccountDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<AccountDataResponse>> GetAccountDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string? Accountstatus, string? OrganizationId, string? ClientId, string AccountType);
}
