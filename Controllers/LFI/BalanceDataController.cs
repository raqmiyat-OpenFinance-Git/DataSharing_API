using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class BalanceDataController : ControllerBase
{
    private readonly IBalanceDataService _balancedataservice;

    public BalanceDataController(IBalanceDataService balancedataservice)
    {
        _balancedataservice = balancedataservice;
    }
    [HttpGet]
    [Route("GetBalanceDataList")]
    //public Task<IEnumerable<BalanceData>> GetBalanceDataList(string? RequestType)
    //{
    //    return _balancedataservice.GetBalanceDataListAsync(RequestType!);

    //}

    public Task<IEnumerable<BalanceData>> GetBalanceDataList()
    {
        return _balancedataservice.GetBalanceDataListAsync();

    }
    [HttpGet]
    [Route("GetBalanceDataByRefId")]
    public Task<BalanceData> GetBalanceDataByRefId(string CorrelationId)
    {
        return _balancedataservice.GetBalanceDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetBalanceDataSearchById")]
    public Task<IEnumerable<BalanceData>> GetBalanceDataSearchById(string? AccountId, string Fromdate, string Todate, string? ConsentId, string? balancestatus, string? OrganizationId, string? ClientId, string? amount)
    {
        return _balancedataservice.GetBalanceDataSearchByIdAsync(AccountId!, Fromdate, Todate, ConsentId!, balancestatus!, OrganizationId!, ClientId!, amount!);

    }
}
