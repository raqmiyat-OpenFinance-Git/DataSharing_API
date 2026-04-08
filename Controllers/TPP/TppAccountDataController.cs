using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class TppAccountDataController : ControllerBase
{
    private readonly ITppAccountDataService _tppaccountdataservice;

    public TppAccountDataController(ITppAccountDataService accountdataservice)
    {
        _tppaccountdataservice = accountdataservice;
    }
    [HttpGet]
    [Route("GetTppAccountDataList")]
    public Task<IEnumerable<TPPAccountDataResponse>> GetTppAccountDataList()
    {
        return _tppaccountdataservice.GetTppAccountDataListAsync();

    }
    [HttpGet]
    [Route("GetTppAccountDataByRefId")]
    public Task<TPPAccountDataResponse> GetTppAccountDataByRefId(string CorrelationId)
    {
        return _tppaccountdataservice.GetTppAccountDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetTppAccountDataSearchById")]
    public Task<IEnumerable<TPPAccountDataResponse>> GetTppAccountDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? Accountstatus, string? OrganizationId, string? ClientId)
    {
        return _tppaccountdataservice.GetTppAccountDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!, Accountstatus, OrganizationId, ClientId);

    }
}
