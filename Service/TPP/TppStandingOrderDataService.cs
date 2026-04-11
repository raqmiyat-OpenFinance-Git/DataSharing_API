using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppStandingOrderDataService : ITppStandingOrderDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppStandingOrderDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TppStandOrderResponse>> GetTppStandOrderDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<TppStandOrderResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppStandingOrderAsync!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppStandOrderResponse>();
        }
    }
    public async Task<TppStandOrderResponse?> GetTppStandOrderDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppStandOrderResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppStandingOrderByIdAsync!,
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
    public async Task<IEnumerable<TppStandOrderResponse>> GetTppStandOrderDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string Spaymentstatus, string? LFIName, string? LFIId)
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

            var result = await _idbConnection.QueryAsync<TppStandOrderResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppStandingOrderByDateAsync!,
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
