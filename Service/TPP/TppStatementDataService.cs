using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppStatementDataService : ITppStatementDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppStatementDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TppStatementResponse>> GetTppStatementDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<TppStatementResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppStatementDataAsync!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppStatementResponse>();
        }
    }
    public async Task<TppStatementResponse?> GetTppStatementDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppStatementResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppStatementDataByIdAsync!,
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
    public async Task<IEnumerable<TppStatementResponse>> GetTppStatementDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string statementstatus, string? LFIName, string? LFIId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("statementstatus", statementstatus, DbType.String);
            parameters.Add("LFIName", LFIName, DbType.String);
            parameters.Add("LFIId", LFIId, DbType.String);

            var result = await _idbConnection.QueryAsync<TppStatementResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppStatementDataByDateAsync!,
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
