using DataSharing_API.IService.TPP;

namespace DataSharing_API.Service.TPP;

public class TppBeneficiariesDataService : ITppBeneficiariesDataService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppBeneficiariesDataService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TppBeneficiariesResponse>> GetTppBeneficiariesDataListAsync()
    {
        try
        {
            var result = await _idbConnection.QueryAsync<TppBeneficiariesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetAllTppBeneficiariesAsync!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppBeneficiariesResponse>();
        }
    }

    public async Task<TppBeneficiariesResponse?> GetTppBeneficiariesDataByRefIdAsync(string CorrelationId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("CorrelationId", CorrelationId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppBeneficiariesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppBeneficiariesByIdAsync!,
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
    public async Task<IEnumerable<TppBeneficiariesResponse>> GetTppBeneficiariesDataSearchByIdAsync(string Fromdate, string Todate, string ConsentId, string AccountId, string status,string LFIName,string LFIId)
    {
        try
        {
            var parameters = new DynamicParameters();

            parameters.Add("Fromdate", Fromdate, DbType.String);
            parameters.Add("Todate", Todate, DbType.String);
            parameters.Add("ConsentId", ConsentId, DbType.String);
            parameters.Add("AccountId", AccountId, DbType.String);
            parameters.Add("status", status, DbType.String);
            parameters.Add("LFIName", LFIName, DbType.String);
            parameters.Add("LFIId", LFIId, DbType.String);


            var result = await _idbConnection.QueryAsync<TppBeneficiariesResponse>(
                _storedProcedureParams.Value.dataSharingSPParams!.GetTppBeneficiariesByDateAsync!,
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
