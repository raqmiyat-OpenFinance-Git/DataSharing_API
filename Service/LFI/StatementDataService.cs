using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class StatementDataService : IStatementDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public StatementDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<StatementResponse>> GetStatementDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<StatementResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveStatementData!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<StatementResponse>();
        }
    }
    public async Task<StatementResponse?> GetStatementDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<StatementResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveStatementDataByRefId!,
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
    public async Task<IEnumerable<StatementResponse>> GetStatementDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);

            var result = await _idbConnection.QueryAsync<StatementResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveStatementDataSearchByRefId!,
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
