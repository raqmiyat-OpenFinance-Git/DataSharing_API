namespace DataSharing_API.IService.TPP;

public interface ITppPartiesDataService
{
    Task<IEnumerable<TppPartiesResponse>> GetTppPartiesDataListAsync();

    Task<TppPartiesResponse> GetTppPartiesDataByRefIdAsync(string CorrelationId);

    Task<IEnumerable<TppPartiesResponse>> GetTppPartiesDataSearchByIdAsync(string Fromdate, string todate, string ConsentId, string AccountId, string Type, string statementstatus, string? LFIName, string? LFIId);
}
