using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppCreditCardService : ITppCreditCardService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppCreditCardService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<TppCreditCard>> GetProductDataListAsync(int productQuoteId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ProductQuoteId", productQuoteId, DbType.Int32);

            var result = await _idbConnection.QueryAsync<TppCreditCard>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCreditCardDetail!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<TppCreditCard>();
        }
    }


    public async Task<IEnumerable<TppCreditCard>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
    string? type = null,
    string? documentationType = null,
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
            parameters.Add("DocumentationType", documentationType, DbType.String);
            parameters.Add("FixedRate", fixedRate, DbType.Decimal);
            parameters.Add("ChargeRate", chargeRate, DbType.Decimal);
            parameters.Add("ChargeName", chargeName, DbType.String);
            parameters.Add("ChargeAmount", chargeAmount, DbType.Decimal);
            parameters.Add("LimitsAmount", limitsAmount, DbType.Decimal);
            parameters.Add("Status", status, DbType.String);

            var result = await _idbConnection.QueryAsync<TppCreditCard>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCreditCardSearch!,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<TppCreditCard>();
        }
    }

    public async Task<TppCreditCard?> GetProductDataByRefIdAsync(long requestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", requestId, DbType.Int64);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppCreditCard>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCreditCardDetailByRefId!,
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