namespace DataSharing_API.IService.LFI;

public interface ITppSchedPaymentDataService
{
    Task<IEnumerable<TppSchedPaymentResponse>> GetTppPaymentDataListAsync();

    Task<TppSchedPaymentResponse> GetTppPaymentDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TppSchedPaymentResponse>> GetTppPaymentDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type,string statementstatus, string? LFIName, string? LFIId);
}
