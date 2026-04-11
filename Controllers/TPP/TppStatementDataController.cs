using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppStatementDataController : ControllerBase
{
    private readonly ITppStatementDataService _statementdataservice;

    public TppStatementDataController(ITppStatementDataService statementdataservice)
    {
        _statementdataservice = statementdataservice;
    }
    [HttpGet]
    [Route("GetTppStatementDataList")]
    public Task<IEnumerable<TppStatementResponse>> GetTppStatementDataList()
    {
        return _statementdataservice.GetTppStatementDataListAsync();
    }
    [HttpGet]
    [Route("GetTppStatementDataByRefIdAsync")]
    public Task<TppStatementResponse> GetTppStatementDataByRefId(string CorrelationId)
    {
        return _statementdataservice.GetTppStatementDataByRefIdAsync(CorrelationId);

    }
    [HttpGet]
    [Route("GetTppStatementDataSearchById")]
    public Task<IEnumerable<TppStatementResponse>> GetStatementDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? statementstatus, string? LFIName, string? LFIId)
    {
        return _statementdataservice.GetTppStatementDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!, statementstatus!, LFIName!, LFIId!);

    }
}
