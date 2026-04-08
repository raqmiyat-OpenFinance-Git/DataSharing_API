using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppAccountDataService : ITppAccountDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppAccountDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TPPAccountDataResponse>> GetTppAccountDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<TPPAccountDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppAccountsAsync!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TPPAccountDataResponse>();
        }
    }

    public async Task<TPPAccountDataResponse?> GetTppAccountDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TPPAccountDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppAccountsByIdAsync!,
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
    public async Task<IEnumerable<TPPAccountDataResponse>> GetTppAccountDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string? Accountstatus, string? OrganizationId, string? ClientId)
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
            //parameters.Add("@TppName", OrganizationId, DbType.String);
            //parameters.Add("@TppID", ClientId, DbType.String);
            var result = await _idbConnection.QueryAsync<TPPAccountDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppAccountsByDateAsync!,
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
