using DataSharing_API.IService.LFI;
using OpenFinance.Models;

namespace DataSharing_API.Service.LFI;

public class LfiCreateLeadService : ILfiCreateLeadService
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public LfiCreateLeadService(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }
    public async Task<IEnumerable<LeadModel>> GetLeadListAsync()
    {
        try
        {
            var parameters = new DynamicParameters();

            var result = await _idbConnection.QueryAsync<LeadModel>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCreateLead!,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<LeadModel>();
        }
    }

    public async Task<LeadModel?> GetLeadByRefIdAsync(string RequestId)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", RequestId, DbType.String);

            var result = await _idbConnection.QueryFirstOrDefaultAsync<LeadModel>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCreateLeadByRefId!,
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
    public async Task<IEnumerable<LeadModel?>> GetLeadSearchByIdAsync(string LeadId, string Fromdate, string Todate, string Email, string status, string EmirateId, string GivenName, string ProductType, string OrganizationId, string ClientId)
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
            parameters.Add("TppOrganizationId", OrganizationId, DbType.String);
            parameters.Add("TppClientId", ClientId, DbType.String);
            var result = await _idbConnection.QueryAsync<LeadModel>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveCreateLeadSearchByRefId!,
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
