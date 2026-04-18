using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiCurrentAccountService : ILfiCurrentAccountService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;

    public LfiCurrentAccountService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams,DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
    }

    public async Task<IEnumerable<LfiCurrentAccount>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<LfiCurrentAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiCurrentAccountDetail!,
                parameters,  
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetProductDataListAsync");
            return Enumerable.Empty<LfiCurrentAccount>();
        }
    }
    

    public async Task<IEnumerable<LfiCurrentAccount>> GetProductDataSearchAsync(
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

            var result = await _idbConnection.QueryAsync<LfiCurrentAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiCurrentAccountSearch!,
                parameters, 
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetProductDataSearchAsync");
            return Enumerable.Empty<LfiCurrentAccount>();
        }
    }

    public async Task<LfiCurrentAccount?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64); 

            var result = await _idbConnection.QueryFirstOrDefaultAsync<LfiCurrentAccount>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiCurrentAccountDetailByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetProductDataByRefIdAsync");
            return null;
        }
    }

}
