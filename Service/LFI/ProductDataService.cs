using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class ProductDataService : IProductDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;

    public ProductDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams,DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
    }
    public async Task<IEnumerable<ProductResponse>> GetProductDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<ProductResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveProductData!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetProductDataListAsync");
            return Enumerable.Empty<ProductResponse>();
        }
    }
    public async Task<ProductResponse?> GetProductDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<ProductResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveProductDataByRefId!,
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
    public async Task<IEnumerable<ProductResponse>> GetProductDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId,
        string Type, string Status, string OrganizationId, string ClientId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("TppName", OrganizationId, DbType.String);
            parameters.Add("TppID", ClientId, DbType.String);
            parameters.Add("Status", Status, DbType.String);

            var result = await _idbConnection.QueryAsync<ProductResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveProductDataSearchByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetProductDataSearchByIdAsync");
            return null;
        }
    }

}
