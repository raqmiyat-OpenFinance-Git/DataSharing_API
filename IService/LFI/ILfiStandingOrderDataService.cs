namespace DataSharing_API.IService.LFI;

public interface ILfiStandingOrderDataService
{
    Task<IEnumerable<StandOrderResponse>> GetStandOrderDataListAsync();

    Task<StandOrderResponse> GetStandOrderDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<StandOrderResponse>> GetStandOrderDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string statementstatus, string OrganizationId, string ClientId);
}
