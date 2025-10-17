using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiCurrentAccountService : ILfiCurrentAccountService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public LfiCurrentAccountService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
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
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<LfiCurrentAccount>();
        }
    }
    

    public async Task<IEnumerable<LfiCurrentAccount>> GetProductDataSearchAsync(
            string? fromDate = null,
            string? toDate = null,
            string? type = null,
            string? description = null,
            bool? isOverdraftAvailable = null,
            string? documentationType = null,
            string? feesName = null,
            string? benefitsName = null,
            string? currency = null,
            string? status = null)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", fromDate, DbType.String);
            parameters.Add("ToDate", toDate, DbType.String);
            parameters.Add("Type", type, DbType.String);
            parameters.Add("Description", description, DbType.String);
            parameters.Add("IsOverdraftAvailable", isOverdraftAvailable, DbType.Boolean);
            parameters.Add("DocumentationType", documentationType, DbType.String);
            parameters.Add("FeesName", feesName, DbType.String);
            parameters.Add("BenefitsName", benefitsName, DbType.String);
            parameters.Add("Currency", currency, DbType.String);
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
            // Consider logging here (e.g., NLog or ILogger)
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
            // Consider logging here (e.g., NLog or ILogger)
            return null;
        }
    }

}
