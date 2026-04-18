using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class BeneficiariesDataService : IBeneficiariesDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;

    public BeneficiariesDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams,DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
    }
    public async Task<IEnumerable<BeneficiariesResponse>> GetBeneficiariesDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<BeneficiariesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBeneficiariesData!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetBeneficiariesDataListAsync");
            return Enumerable.Empty<BeneficiariesResponse>();
        }
    }

    public async Task<BeneficiariesResponse?> GetBeneficiariesDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<BeneficiariesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBeneficiariesDataByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetBeneficiariesDataByRefIdAsync");
            return null;
        }
    }
    public async Task<IEnumerable<BeneficiariesResponse>> GetBeneficiariesDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string Status, string OrganizationId, string ClientId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("@Status", Status, DbType.String);
            parameters.Add("@TppName", OrganizationId, DbType.String);
            parameters.Add("@TppID", ClientId, DbType.String);
            var result = await _idbConnection.QueryAsync<BeneficiariesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveBeneficiariesDataSearchByRefId!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error Occurred in GetBeneficiariesDataSearchByIdAsync");
            return null;
        }
    }

}
