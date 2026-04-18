using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiStandingOrderDataService : ILfiStandingOrderDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;

    public LfiStandingOrderDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams,DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
    }
    public async Task<IEnumerable<StandOrderResponse>> GetStandOrderDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<StandOrderResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveStandingOrderData!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetStandOrderDataListAsync");
            return Enumerable.Empty<StandOrderResponse>();
        }
    }
    public async Task<StandOrderResponse?> GetStandOrderDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<StandOrderResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveStandingOrderDataByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetStandOrderDataByRefIdAsync");
            return null;
        }
    }
    public async Task<IEnumerable<StandOrderResponse>> GetStandOrderDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string Spaymentstatus, string OrganizationId, string ClientId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("Spaymentstatus", Spaymentstatus, DbType.String);
            parameters.Add("TppOrganizationId", OrganizationId, DbType.String);
            parameters.Add("TppClientId", ClientId, DbType.String);

            var result = await _idbConnection.QueryAsync<StandOrderResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveStandingOrderDataSearchByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetStandOrderDataSearchByIdAsync");
            return null;
        }
    }

}
