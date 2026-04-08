using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppCurrentAccountService : ITppCurrentAccountService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppCurrentAccountService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<TppCurrentAccount>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<TppCurrentAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCurrentAccountDetail!,
                parameters,  
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<TppCurrentAccount>();
        }
    }
    
    public async Task<IEnumerable<TppCurrentAccount>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
    string? type = null,
    bool? isOverdraftAvailable = null,
    string? documentationType = null,
    decimal? rateType = null,
    decimal? chargeAmount = null,
    decimal? limitsAmount = null,
    string? status = null)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", fromDate, DbType.String);
            parameters.Add("ToDate", toDate, DbType.String);
            parameters.Add("Type", type, DbType.String);
            parameters.Add("IsOverdraftAvailable", isOverdraftAvailable, DbType.Boolean);
            parameters.Add("DocumentationType", documentationType, DbType.String);
            parameters.Add("RateType", rateType, DbType.Decimal);
            parameters.Add("ChargeAmount", chargeAmount, DbType.Decimal);
            parameters.Add("LimitsAmount", limitsAmount, DbType.Decimal);
            parameters.Add("Status", status, DbType.String);

            var result = await _idbConnection.QueryAsync<TppCurrentAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCurrentAccountSearch!,
                parameters, 
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<TppCurrentAccount>();
        }
    }

    public async Task<TppCurrentAccount?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64); 

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppCurrentAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCurrentAccountDetailByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return null;
        }
    }
}
