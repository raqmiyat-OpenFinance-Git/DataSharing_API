using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class TransactionDataService : ITransactionDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TransactionDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TransactionDataResponse>> GetTransactionDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<TransactionDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTransactionData!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TransactionDataResponse>();
        }
    }

    public async Task<TransactionDataResponse?> GetTransactionDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TransactionDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTransactionDataByRefId!,
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
    public async Task<IEnumerable<TransactionDataResponse>> GetTransactionDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            var result = await _idbConnection.QueryAsync<TransactionDataResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTransactionDataSearchByRefId!,
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
