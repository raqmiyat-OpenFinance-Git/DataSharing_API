using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppPartiesDataService : ITppPartiesDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppPartiesDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TppPartiesResponse>> GetTppPartiesDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<TppPartiesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppPartiesDataAsync!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppPartiesResponse>();
        }
    }
    public async Task<TppPartiesResponse?> GetTppPartiesDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppPartiesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppPartiesDataByIdAsync!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<IEnumerable<TppPartiesResponse>> GetTppPartiesDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string Spaymentstatus, string? LFIName, string? LFIId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("Spaymentstatus", Spaymentstatus, DbType.String);
            parameters.Add("LFIName", LFIName, DbType.String);
            parameters.Add("LFIId", LFIId, DbType.String);

            var result = await _idbConnection.QueryAsync<TppPartiesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppPartiesDataByDateAsync!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}
