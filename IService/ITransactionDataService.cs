

using DataSharing_API.Model;


namespace DataSharing_API.IService
{
    public interface ITransactionDataService
    {
        Task<IEnumerable<TransactionDataResponse>> GetTransactionDataListAsync();

        Task<TransactionDataResponse> GetTransactionDataByRefIdAsync(string CorrelationId);

        Task<IEnumerable<TransactionDataResponse>> GetTransactionDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId);
    }
}
