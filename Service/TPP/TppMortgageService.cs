using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppMortgageService : ITppMortgageService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppMortgageService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<TppMortgage>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<TppMortgage>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppMortgageDetail!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<TppMortgage>();
        }
    }


    public async Task<IEnumerable<TppMortgage>> GetProductDataSearchAsync(
           string? fromDate = null, string? toDate = null, string? type = null, string? description = null, decimal? minimumLoanAmount = null, decimal? maximumLoanAmount = null, decimal? minTenure = null, decimal? maxTenure = null, decimal? indicativeRateFrom = null, decimal? indicativeRateTo = null, string? rateType = null, string? documentationType = null, string? feesName = null, string? benefitsName = null, string? status = null)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", fromDate, DbType.String);
            parameters.Add("ToDate", toDate, DbType.String);
            parameters.Add("Type", type, DbType.String);
            parameters.Add("Description", description, DbType.String);
            parameters.Add("MinimumLoanAmount", minimumLoanAmount, DbType.Decimal);
            parameters.Add("MaximumLoanAmount", maximumLoanAmount, DbType.Decimal);
            parameters.Add("MinTenure", minTenure, DbType.Decimal);
            parameters.Add("MaxTenure", maxTenure, DbType.Decimal);
            parameters.Add("IndicativeRateFrom", indicativeRateFrom, DbType.Decimal);
            parameters.Add("IndicativeRateTo", indicativeRateTo, DbType.Decimal);
            parameters.Add("RateType", rateType, DbType.String);
            parameters.Add("DocumentationType", documentationType, DbType.String);
            parameters.Add("FeesName", feesName, DbType.String);
            parameters.Add("BenefitsName", benefitsName, DbType.String);
            parameters.Add("Status", status, DbType.String);



            var result = await _idbConnection.QueryAsync<TppMortgage>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppMortgageSearch!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<TppMortgage>();
        }
    }

    public async Task<TppMortgage?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppMortgage>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppMortgageDetailByRefId!,
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

    public Task<IEnumerable<TppMortgage>> GetProductDataSearchAsync(string? fromDate = null, string? toDate = null, string? type = null, string? description = null, decimal? minimumLoanAmount = null, string? maximumLoanAmount = null, decimal? minTenure = null, decimal? maxTenure = null, decimal? indicativeRateFrom = null, decimal? indicativeRateTo = null, string? rateType = null, string? documentationType = null, string? feesName = null, string? benefitsName = null, string? status = null)
    {
        throw new NotImplementedException();
    }
}