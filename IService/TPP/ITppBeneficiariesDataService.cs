namespace DataSharing_API.IService.TPP;

public interface ITppBeneficiariesDataService
{
    Task<IEnumerable<TppBeneficiariesResponse>> GetTppBeneficiariesDataListAsync();

    Task<TppBeneficiariesResponse> GetTppBeneficiariesDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TppBeneficiariesResponse>> GetTppBeneficiariesDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string status, string LFIName, string LFIId);
}
