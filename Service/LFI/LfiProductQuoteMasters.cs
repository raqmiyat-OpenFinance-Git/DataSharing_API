using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiProductQuoteMasters : ILfiProductQuoteMasters
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

    public LfiProductQuoteMasters(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
    }

    public async Task<IEnumerable<ProductQuoteMaster>> GetProductQuoteMasters()
    {
        try
        {

            var result = await _idbConnection.QueryAsync<ProductQuoteMaster>(
                _storedProcedureParams.Value.dataSharingSPParams!.RetrieveLfiProductQuoteMaster!,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
        catch (Exception ex)
        {
            // Consider logging here (e.g., NLog or ILogger)
            return Enumerable.Empty<ProductQuoteMaster>();
        }
    }
}
