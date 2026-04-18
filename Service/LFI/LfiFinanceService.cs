using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiFinanceService : ILfiFinanceService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;

    public LfiFinanceService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams,DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
    }

    public async Task<IEnumerable<LfiFinance>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<LfiFinance>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiPersonalLoanDetail!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetProductDataListAsync");
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiFinance>();
        }
    }


    public async Task<IEnumerable<LfiFinance>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
    string? type = null,
    decimal? minimumFinanceAmount = null,
    decimal? maximumFinanceAmount = null,
    decimal? chargeRate = null,
    decimal? fixedRate = null,
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
            parameters.Add("MinimumFinanceAmount", minimumFinanceAmount, DbType.Decimal);
            parameters.Add("MaximumFinanceAmount", maximumFinanceAmount, DbType.Decimal);
            parameters.Add("ChargeRate", chargeRate, DbType.Decimal);
            parameters.Add("ChargeName", chargeName, DbType.String);
            parameters.Add("ChargeAmount", chargeAmount, DbType.Decimal);
            parameters.Add("LimitsAmount", limitsAmount, DbType.Decimal);
            parameters.Add("Status", status, DbType.String);

            var result = await _idbConnection.QueryAsync<LfiFinance>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiPersonalLoanSearch!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetProductDataSearchAsync");
            return Enumerable.Empty<LfiFinance>();
        }
    }

    public async Task<LfiFinance?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<LfiFinance>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiPersonalLoanDetailByRefId!,
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