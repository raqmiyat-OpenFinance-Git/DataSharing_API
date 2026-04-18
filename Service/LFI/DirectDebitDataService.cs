using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class DirectDebitDataService : IDirectDebitDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;

    public DirectDebitDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams, DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
    }
    public async Task<IEnumerable<DirectDebitResponse>> GetDirectdebitDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<DirectDebitResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveDirectDebitData!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetDirectdebitDataListAsync");
            return Enumerable.Empty<DirectDebitResponse>();
        }
    }
    public async Task<DirectDebitResponse?> GetDirectdebitDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<DirectDebitResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveDirectDebitDataByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetDirectdebitDataByRefIdAsync");
            return null;
        }
    }
    public async Task<IEnumerable<DirectDebitResponse>> GetDirectdebitDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string Status, string OrganizationId, string ClientId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("@Status", Status, DbType.String);
            parameters.Add("@TppName", OrganizationId, DbType.String);
            parameters.Add("@TppID", ClientId, DbType.String);
            var result = await _idbConnection.QueryAsync<DirectDebitResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveDirectDebitDataSearchByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetDirectdebitDataSearchByIdAsync");
            return null;
        }
    }

}
