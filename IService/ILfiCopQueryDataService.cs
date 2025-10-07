using DataSharing_API.Model;


namespace DataSharing_API.IService
{
    public interface ILfiCopQueryDataService
    {
        Task<IEnumerable<LfiCoPQueryData>> GetCopQueryDataListAsync();

        Task<LfiCoPQueryData> GetCopQueryDataByRefIdAsync(string CorrelationId);

        Task<IEnumerable<LfiCoPQueryData>> GetCopQueryDataSearchByIdAsync(string Fromdate, string todate,
            string CustomerName, string Customerstatus);
    }
}
