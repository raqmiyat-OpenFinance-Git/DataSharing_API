
using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppBalanceDataController : ControllerBase
{
    private readonly ITppBalanceDataService _tppbalancedataservice;

    public TppBalanceDataController(ITppBalanceDataService balancedataservice)
    {
        _tppbalancedataservice = balancedataservice;
    }
    [HttpGet]
    [Route("GetTppBalanceDataList")]
    public Task<IEnumerable<TppBalanceData>> GetTppBalanceDataList()
    {
        return _tppbalancedataservice.GetTppBalanceDataListAsync();

    }
    [HttpGet]
    [Route("GetTppBalanceDataByRefId")]
    public Task<TppBalanceData> GetTppBalanceDataByRefId(string CorrelationId)
    {
        return _tppbalancedataservice.GetTppBalanceDataByRefIdAsync(CorrelationId);
    }

    [HttpGet]
    [Route("GetTppBalanceDataSearchById")]
    public Task<IEnumerable<TppBalanceData>> GetTppBalanceDataSearchById(string? AccountId, string Fromdate, string Todate, string? ConsentId, string? balancestatus, string? OrganizationId, string? ClientId, string? amount)
    {
        return _tppbalancedataservice.GetTppBalanceDataSearchByIdAsync(AccountId!, Fromdate, Todate, ConsentId!, balancestatus!, OrganizationId!, ClientId!, amount!);

    }
}
