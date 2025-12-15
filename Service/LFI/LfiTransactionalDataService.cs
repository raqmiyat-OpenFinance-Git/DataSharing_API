using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiTransactionalDataService : ILfiTransactionalDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public LfiTransactionalDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    

    public async Task<IEnumerable<LfiTransactionalData>> GetTransactionalDataListAsync(string paymentCategory)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("PaymentCategory", paymentCategory, DbType.String);

            var result = await _idbConnection.QueryAsync<LfiTransactionalData>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiTransactionalData!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<LfiTransactionalData>();
        }
    }

    public async Task<LfiTransactionalData> GetTransactionalDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<LfiTransactionalData>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiTransactionalDataByRefId!,
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

    public async Task<IEnumerable<LfiTransactionalData>> GetTransactionalDataSearchByIdAsync(string? fromdate, string? toDate, string? consentId, string? accountId, string? currentStatus, string? paymentCategory, string? OrganizationId, string? ClientId)
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
            var result = await _idbConnection.QueryAsync<LfiTransactionalData>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiTransactionalDataSearch!,
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
