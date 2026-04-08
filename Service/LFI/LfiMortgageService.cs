using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiMortgageService : ILfiMortgageService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public LfiMortgageService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<LfiMortgage>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<LfiMortgage>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiMortgageDetail!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiMortgage>();
        }
    }


    public async Task<IEnumerable<LfiMortgage>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
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
            parameters.Add("MinimumFinanceAmount", minimumFinanceAmount, DbType.Decimal);
            parameters.Add("MaximumFinanceAmount", maximumFinanceAmount, DbType.Decimal);
            parameters.Add("ChargeRate", chargeRate, DbType.Decimal);
            parameters.Add("ChargeName", chargeName, DbType.String);
            parameters.Add("ChargeAmount", chargeAmount, DbType.Decimal);
            parameters.Add("LimitsAmount", limitsAmount, DbType.Decimal);
            parameters.Add("Status", status, DbType.String);


            var result = await _idbConnection.QueryAsync<LfiMortgage>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiMortgageSearch!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiMortgage>();
        }
    }

    public async Task<LfiMortgage?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<LfiMortgage>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiMortgageDetailByRefId!,
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

    public Task<IEnumerable<LfiMortgage>> GetProductDataSearchAsync(string? fromDate = null, string? toDate = null, string? type = null, string? description = null, decimal? minimumLoanAmount = null, string? maximumLoanAmount = null, decimal? minTenure = null, decimal? maxTenure = null, decimal? indicativeRateFrom = null, decimal? indicativeRateTo = null, string? rateType = null, string? documentationType = null, string? feesName = null, string? benefitsName = null, string? status = null)
    {
        throw new NotImplementedException();
    }
}