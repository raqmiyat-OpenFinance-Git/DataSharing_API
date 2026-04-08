using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppBalanceDataService : ITppBalanceDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppBalanceDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<TppBalanceData>> GetTppBalanceDataListAsync()
    {
        try
        {
            var parameters = new DynamicParameters();

            var result = await _idbConnection.QueryAsync<TppBalanceData>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppBalancesAsync!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppBalanceData>();
        }
    }

    public async Task<TppBalanceData?> GetTppBalanceDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppBalanceData>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppBalancesByIdAsync!,
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
    public async Task<IEnumerable<TppBalanceData?>> GetTppBalanceDataSearchByIdAsync(string AccountId, string Fromdate, string Todate, string ConsentId, string balancestatus, string OrganizationId, string ClientId, string amount)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("BalanceStatus", balancestatus, DbType.String);
            //parameters.Add("TppOrganizationId", OrganizationId, DbType.String);
            //parameters.Add("TppClientId", ClientId, DbType.String);
            parameters.Add("BalanceAmount", amount, DbType.String);
            var result = await _idbConnection.QueryAsync<TppBalanceData>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppBalancesByDateAsync!,
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
