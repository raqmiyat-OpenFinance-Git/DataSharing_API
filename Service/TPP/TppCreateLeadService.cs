using DataSharing_API.IService.TPP;
using OpenFinance.Models.TPP;

namespace DataSharing_API.Service.TPP;

public class TppCreateLeadService : ITppCreateLeadService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public TppCreateLeadService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<TppLeadModel>> GetLeadListAsync()
    {
        try
        {
            var parameters = new DynamicParameters();

            var result = await _idbConnection.QueryAsync<TppLeadModel>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCreateLead!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<TppLeadModel>();
        }
    }

    public async Task<TppLeadModel?> GetLeadByRefIdAsync(string RequestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", RequestId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<TppLeadModel>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCreateLeadByRefId!,
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
    public async Task<IEnumerable<TppLeadModel?>> GetLeadSearchByIdAsync(
    string LeadId, 
    string Fromdate, 
    string Todate, 
    string Email, 
    string status, 
    string EmirateId, 
    string GivenName, 
    string ProductType)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FromDate", Fromdate ?? "", DbType.String);
            parameters.Add("@ToDate", Todate ?? "", DbType.String);
            parameters.Add("@LeadId", LeadId ?? "", DbType.String);
            parameters.Add("@Email", Email ?? "", DbType.String);
            parameters.Add("@Status", status ?? "", DbType.String);
            parameters.Add("@EmiratesId", EmirateId ?? "", DbType.String);
            parameters.Add("@GivenName", GivenName ?? "", DbType.String);
            parameters.Add("@ProductType", ProductType ?? "", DbType.String);
            var result = await _idbConnection.QueryAsync<TppLeadModel>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveTppCreateLeadSearchByRefId!,
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
