using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppDirectDebitDataService : ITppDirectDebitDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppDirectDebitDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TppDirectDebitResponse>> GetTppDirectdebitDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<TppDirectDebitResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppDirectDebitAsync!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppDirectDebitResponse>();
        }
    }
    public async Task<TppDirectDebitResponse?> GetTppDirectdebitDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppDirectDebitResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppDirectDebitByIdAsync!,
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
    public async Task<IEnumerable<TppDirectDebitResponse>> GetTppDirectdebitDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string status, string LFIName, string LFIId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("status", status, DbType.String);
            parameters.Add("LFIName", LFIName, DbType.String);
            parameters.Add("LFIId", LFIId, DbType.String);

            var result = await _idbConnection.QueryAsync<TppDirectDebitResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppDirectDebitByDateAsync!,
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
