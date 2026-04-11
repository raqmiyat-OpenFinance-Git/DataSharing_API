using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class TppTransactionalDataService : ITppTransactionalDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppTransactionalDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    

    public async Task<IEnumerable<TppTransactionalData>> GetTppTransactionalDataListAsync(string paymentCategory)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("PaymentCategory", paymentCategory, DbType.String);

            var result = await _idbConnection.QueryAsync<TppTransactionalData>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppTransactionalDataAsync!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppTransactionalData>();
        }
    }

    public async Task<TppTransactionalData> GetTppTransactionalDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppTransactionalData>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppTransactionalDataByIdAsync!,
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

    public async Task<IEnumerable<TppTransactionalData>> GetTppTransactionalDataSearchByIdAsync(string? fromdate, string? toDate, string? consentId, string? accountId, string? currentStatus, string? paymentCategory, string? OrganizationId, string? ClientId,string? PaymentTransactionId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("FromDate", fromdate, DbType.String);
            parameters.Add("ToDate", toDate, DbType.String);
            parameters.Add("ConsentId", consentId, DbType.String);
            parameters.Add("AccountId", accountId, DbType.String);
            parameters.Add("CurrentStatus", currentStatus, DbType.String);
            parameters.Add("PaymentCategory", paymentCategory, DbType.String);
            parameters.Add("TppOrganizationId", OrganizationId, DbType.String);
            parameters.Add("TppClientId", ClientId, DbType.String);
            parameters.Add("PaymentTransactionId", PaymentTransactionId, DbType.String);
            var result = await _idbConnection.QueryAsync<TppTransactionalData>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppTransactionalDataByDateAsync!,
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
