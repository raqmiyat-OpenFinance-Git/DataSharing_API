using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiStatementDataController : ControllerBase
{
    private readonly IStatementDataService _statementdataservice;

    public LfiStatementDataController(IStatementDataService Statementdataservice)
    {
        _statementdataservice = Statementdataservice;
    }
    [HttpGet]
    [Route("GetStatementDataList")]
    public Task<IEnumerable<StatementResponse>> GetStatementDataList()
    {
        return _statementdataservice.GetStatementDataListAsync();

    }
    [HttpGet]
    [Route("GetStatementDataByRefId")]
    public Task<StatementResponse> GetStatementDataByRefId(string CorrelationId)
    {
        return _statementdataservice.GetStatementDataByRefIdAsync(CorrelationId);

    }
    [HttpGet]
    [Route("GetStatementDataSearchById")]
    public Task<IEnumerable<StatementResponse>> GetStatementDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? statementstatus, string? OrganizationId, string? ClientId)
    {
        return _statementdataservice.GetStatementDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!,statementstatus!,OrganizationId!,ClientId!);

    }
}
