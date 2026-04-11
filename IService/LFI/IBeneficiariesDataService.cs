namespace DataSharing_API.IService.LFI;

public interface IBeneficiariesDataService
{
    Task<IEnumerable<BeneficiariesResponse>> GetBeneficiariesDataListAsync();

    Task<BeneficiariesResponse> GetBeneficiariesDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<BeneficiariesResponse>> GetBeneficiariesDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string Status, string OrganizationId, string ClientId);
}
