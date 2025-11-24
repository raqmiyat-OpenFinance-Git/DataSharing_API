namespace DataSharing_API.IService.LFI;

public interface ILfiSchedPaymentDataService
{
    Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataListAsync();

    Task<SchedPaymentResponse> GetPaymentDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type,string statementstatus, string OrganizationId, string ClientId);
}
