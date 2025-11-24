using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiStandingOrderDataController : ControllerBase
{
    private readonly ILfiStandingOrderDataService _standorderdataservice;

    public LfiStandingOrderDataController(ILfiStandingOrderDataService orderdataservice)
    {
        _standorderdataservice = orderdataservice;
    }
    [HttpGet]
    [Route("GetStandOrderDataList")]
    public Task<IEnumerable<StandOrderResponse>> GetStandOrderDataList()
    {
        return _standorderdataservice.GetStandOrderDataListAsync();

    }
    [HttpGet]
    [Route("GetStandOrderDataByRefId")]
    public Task<StandOrderResponse> GetStandOrderDataByRefId(string CorrelationId)
    {
        return _standorderdataservice.GetStandOrderDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetStandOrderDataSearchById")]
    public Task<IEnumerable<StandOrderResponse>> GetStandOrderDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? Spaymentstatus, string? OrganizationId, string? ClientId)
    {
        return _standorderdataservice.GetStandOrderDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!, Spaymentstatus!, OrganizationId!, ClientId!);

    }
}
