namespace DataSharing_API.IService.LFI;

public interface ILfiCopQueryDataService
{
    Task<IEnumerable<LfiCoPQueryData>> GetCopQueryDataListAsync();

    Task<LfiCoPQueryData> GetCopQueryDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<LfiCoPQueryData>> GetCopQueryDataSearchByIdAsync(string Fromdate, string todate,
        string CustomerName, string Iban, string EmiratesId, string Email, string CustomerQueryStatus, string Customerstatus);
}
