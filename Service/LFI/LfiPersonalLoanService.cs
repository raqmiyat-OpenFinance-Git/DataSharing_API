using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiPersonalLoanService : ILfiPersonalLoanService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public LfiPersonalLoanService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<LfiPersonalLoan>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<LfiPersonalLoan>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiPersonalLoanDetail!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiPersonalLoan>();
        }
    }


    public async Task<IEnumerable<LfiPersonalLoan>> GetProductDataSearchAsync(
           string? fromDate = null, string? toDate = null, string? type = null, string? description = null, decimal? minimumLoanAmount = null, string? minimumLoanCurrency = null, decimal? minTenure = null, decimal? indicativeRateFrom = null, string? rateType = null, string? documentationType = null, string? feesName = null, string? benefitsName = null, string? status = null)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", fromDate, DbType.String);
            parameters.Add("ToDate", toDate, DbType.String);
            parameters.Add("Type", type, DbType.String);
            parameters.Add("Description", description, DbType.String);
            parameters.Add("MinimumLoanAmount", minimumLoanAmount, DbType.Decimal);
            parameters.Add("MinimumLoanCurrency", minimumLoanCurrency, DbType.Decimal);
            parameters.Add("MinTenure", minTenure, DbType.Decimal);
            parameters.Add("IndicativeRateFrom", indicativeRateFrom, DbType.Decimal);
            parameters.Add("RateType", rateType, DbType.String);
            parameters.Add("DocumentationType", documentationType, DbType.String);
            parameters.Add("FeesName", feesName, DbType.String);
            parameters.Add("BenefitsName", benefitsName, DbType.String);
            parameters.Add("Status", status, DbType.String);



            var result = await _idbConnection.QueryAsync<LfiPersonalLoan>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiPersonalLoanSearch!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiPersonalLoan>();
        }
    }

    public async Task<LfiPersonalLoan?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<LfiPersonalLoan>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiPersonalLoanDetailByRefId!,
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