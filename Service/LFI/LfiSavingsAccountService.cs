using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiSavingsAccountService : ILfiSavingsAccountService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public LfiSavingsAccountService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<LfiSavingsAccount>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<LfiSavingsAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiSavingsAccountDetail!,
                parameters,  
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiSavingsAccount>();
        }
    }

    public async Task<IEnumerable<LfiSavingsAccount>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
    string? type = null,
    decimal? minimumBalance = null,
    string? documentationType = null,
    string? rateType = null,
    decimal? annualRate = null,
    string? chargeName = null,
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
            parameters.Add("MinimumBalance", minimumBalance, DbType.Decimal);
            parameters.Add("DocumentationType", documentationType, DbType.String);
            parameters.Add("AnnualRate", annualRate, DbType.Decimal);
            parameters.Add("RateType", rateType, DbType.String);
            parameters.Add("ChargeName", chargeName, DbType.String);
            parameters.Add("ChargeAmount", chargeAmount, DbType.Decimal);
            parameters.Add("LimitsAmount", limitsAmount, DbType.Decimal);
            parameters.Add("Status", status, DbType.String);

            var result = await _idbConnection.QueryAsync<LfiSavingsAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiSavingsAccountSearch!,
                parameters, 
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiSavingsAccount>();
        }
    }

    public async Task<LfiSavingsAccount?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64); 

            var result = await _idbConnection.QueryFirstOrDefaultAsync<LfiSavingsAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiSavingsAccountDetailByRefId!,
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
