using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppStandingOrderDataController : ControllerBase
{
    private readonly ITppStandingOrderDataService _standorderdataservice;

    public TppStandingOrderDataController(ITppStandingOrderDataService orderdataservice)
    {
        _standorderdataservice = orderdataservice;
    }
    [HttpGet]
    [Route("GetTppStandOrderDataList")]
    public Task<IEnumerable<TppStandOrderResponse>> GetTppStandOrderDataList()
    {
        return _standorderdataservice.GetTppStandOrderDataListAsync();
    }
    [HttpGet]
    [Route("GetTppStandOrderDataByRefId")]
    public Task<TppStandOrderResponse> GetTppStandOrderDataByRefId(string CorrelationId)
    {
        return _standorderdataservice.GetTppStandOrderDataByRefIdAsync(CorrelationId);

    }
    [HttpGet]
    [Route("GetTppStandOrderDataSearchById")]
    public Task<IEnumerable<TppStandOrderResponse>> GetStandOrderDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? Spaymentstatus, string? LFIName, string? LFIId)
    {
        return _standorderdataservice.GetTppStandOrderDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!, Spaymentstatus!, LFIName!, LFIId!);

    }
}
