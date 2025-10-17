using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class AccountDataController : ControllerBase
{
    private readonly IAccountDataService _accountdataservice;

    public AccountDataController(IAccountDataService accountdataservice)
    {
        _accountdataservice = accountdataservice;
    }
    [HttpGet]
    [Route("GetAccountDataList")]
    public Task<IEnumerable<AccountDataResponse>> GetAccountDataList()
    {
        return _accountdataservice.GetAccountDataListAsync();

    }
    [HttpGet]
    [Route("GetAccountDataByRefId")]
    public Task<AccountDataResponse> GetAccountDataByRefId(string CorrelationId)
    {
        return _accountdataservice.GetAccountDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetAccountDataSearchById")]
    public Task<IEnumerable<AccountDataResponse>> GetAccountDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? Accountstatus, string? OrganizationId, string? ClientId)
    {
        return _accountdataservice.GetAccountDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!, Accountstatus, OrganizationId, ClientId);

    }
}
