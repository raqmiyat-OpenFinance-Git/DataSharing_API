using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class TppSchedPaymentDataService : ITppSchedPaymentDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppSchedPaymentDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TppSchedPaymentResponse>> GetTppPaymentDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<TppSchedPaymentResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppSchedPaymentAsync!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppSchedPaymentResponse>();
        }
    }
    public async Task<TppSchedPaymentResponse?> GetTppPaymentDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppSchedPaymentResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppSchedPaymentByIdAsync!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<IEnumerable<TppSchedPaymentResponse>> GetTppPaymentDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string Type, string Spaymentstatus, string? LFIName, string? LFIId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("Spaymentstatus", Spaymentstatus, DbType.String);
            parameters.Add("LFIName", LFIName, DbType.String);
            parameters.Add("LFIId", LFIId, DbType.String);

            var result = await _idbConnection.QueryAsync<TppSchedPaymentResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppSchedPaymentByDateAsync!,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}
