using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiCreditCardService : ILfiCreditCardService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public LfiCreditCardService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<LfiCreditCard>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<LfiCreditCard>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiCreditCardDetail!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiCreditCard>();
        }
    }


    public async Task<IEnumerable<LfiCreditCard>> GetProductDataSearchAsync(
           string? fromDate = null, string? toDate = null, string? type = null, string? description = null, decimal? Rate = null, string? documentationType = null, string? feesName = null, string? benefitsName = null, string? limitsType = null, string? currency = null, string? status = null)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", fromDate, DbType.String);
            parameters.Add("ToDate", toDate, DbType.String);
            parameters.Add("Type", type, DbType.String);
            parameters.Add("Description", description, DbType.String);
            parameters.Add("Rate", Rate, DbType.Decimal);
            parameters.Add("DocumentationType", documentationType, DbType.String);
            parameters.Add("FeesName", feesName, DbType.String);
            parameters.Add("BenefitsName", benefitsName, DbType.String);
            parameters.Add("LimitsType", limitsType, DbType.String);
            parameters.Add("Currency", currency, DbType.String);
            parameters.Add("Status", status, DbType.String);



            var result = await _idbConnection.QueryAsync<LfiCreditCard>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiCreditCardSearch!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiCreditCard>();
        }
    }

    public async Task<LfiCreditCard?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<LfiCreditCard>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiCreditCardDetailByRefId!,
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