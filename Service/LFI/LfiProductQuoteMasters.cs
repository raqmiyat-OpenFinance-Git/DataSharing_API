using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class LfiProductQuoteMasters : ILfiProductQuoteMasters
{
    private IDbConnection _idbConnection;
    private readonly IOptions<StoredProcedureParams> _storedProcedureParams;
    private readonly DataSharingLogger _logger;

    public LfiProductQuoteMasters(IDbConnection idbConnection, IOptions<StoredProcedureParams> storedProcedureParams,DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _storedProcedureParams = storedProcedureParams;
        _logger = logger;
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
            _logger.Error(ex, "Error Occurred in GetProductQuoteMasters");
            return Enumerable.Empty<ProductQuoteMaster>();
        }
    }
}
