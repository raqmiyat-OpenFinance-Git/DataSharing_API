using DataSharing_API.Model;

namespace DataSharing_API.IService
{
    public interface IStandingOrderDataService
    {
        Task<IEnumerable<StandOrderResponse>> GetStandOrderDataListAsync();

        Task<StandOrderResponse> GetStandOrderDataByRefIdAsync(string CorrelationId);

        Task<IEnumerable<StandOrderResponse>> GetStandOrderDataSearchByIdAsync(string Fromdate, string todate, string ConsentId,string AccountId, string Type);
    }
}
