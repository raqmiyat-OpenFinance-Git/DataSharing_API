using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class BalanceDataService : IBalanceDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;

    public BalanceDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams,DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
    }
   
    public async Task<IEnumerable<BalanceData>> GetBalanceDataListAsync()
    {
        try
        {
            var parameters = new DynamicParameters();

            var result = await _idbConnection.QueryAsync<BalanceData>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBalanceData!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetBalanceDataListAsync");
            return Enumerable.Empty<BalanceData>();
        }
    }

    public async Task<BalanceData?> GetBalanceDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<BalanceData>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBalanceDataByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetBalanceDataByRefIdAsync");
            return null;
        }
    }
    public async Task<IEnumerable<BalanceData?>> GetBalanceDataSearchByIdAsync(string AccountId, string Fromdate, string Todate, string ConsentId, string balancestatus, string OrganizationId, string ClientId, string amount)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("BalanceStatus", balancestatus, DbType.String);
            parameters.Add("TppOrganizationId", OrganizationId, DbType.String);
            parameters.Add("TppClientId", ClientId, DbType.String);
            parameters.Add("BalanceAmount", amount, DbType.String);
            var result = await _idbConnection.QueryAsync<BalanceData>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBalanceDataSearchByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetBalanceDataSearchByIdAsync");
            return null;
        }
    }

}
