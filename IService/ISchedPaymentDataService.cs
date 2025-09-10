
using DataSharing_API.Model;


namespace DataSharing_API.IService
{
    public interface ISchedPaymentDataService
    {
        Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataListAsync();

        Task<SchedPaymentResponse> GetPaymentDataByRefIdAsync(string CorrelationId);

        Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataSearchByIdAsync(string Fromdate, string todate, string ConsentId,string AccountId, string Type);
    }
}
