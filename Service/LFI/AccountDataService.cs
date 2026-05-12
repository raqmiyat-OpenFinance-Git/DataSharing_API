using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class AccountDataService : IAccountDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;
    public AccountDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams, DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
    }
    public async Task<IEnumerable<AccountDataResponse>> GetAccountDataListAsync(string AccountType)
    {
        _logger.Info("Start a GetAccountDataListAsync");
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("AccountType", AccountType, DbType.String);
            var result = await _idbConnection.QueryAsync<AccountDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveAccountData!, parameters,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetAccountDataListAsync");
            return Enumerable.Empty<AccountDataResponse>();
          
        }
    }

    public async Task<AccountDataResponse?> GetAccountDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<AccountDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveAccountDataByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetAccountDataByRefIdAsync");
            return null;
        }
    }
    public async Task<IEnumerable<AccountDataResponse>> GetAccountDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string? Accountstatus, string? OrganizationId, string? ClientId, string AccountType)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("Type", Type, DbType.String);
            parameters.Add("@Status", Accountstatus, DbType.String);
            parameters.Add("@TppName", OrganizationId, DbType.String);
            parameters.Add("@TppID", ClientId, DbType.String);
            parameters.Add("AccountType", AccountType, DbType.String);
            var result = await _idbConnection.QueryAsync<AccountDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveAccountDataSearchByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetAccountDataSearchByIdAsync");
            return null;
        }
    }
}
