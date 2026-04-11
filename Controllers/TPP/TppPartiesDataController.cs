using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppPartiesDataController : ControllerBase
{
    private readonly ITppPartiesDataService _partiesdataservice;

    public TppPartiesDataController(ITppPartiesDataService partiesdataservice)
    {
        _partiesdataservice = partiesdataservice;
    }
    [HttpGet]
    [Route("GetTppPartiesDataList")]
    public Task<IEnumerable<TppPartiesResponse>> GetTppPartiesDataList()
    {
        return _partiesdataservice.GetTppPartiesDataListAsync();
    }
    [HttpGet]
    [Route("GetTppPartiesDataByRefId")]
    public Task<TppPartiesResponse> GetTppPartiesDataByRefId(string CorrelationId)
    {
        return _partiesdataservice.GetTppPartiesDataByRefIdAsync(CorrelationId);

    }
    [HttpGet]
    [Route("GetTppPartiesDataSearchById")]
    public Task<IEnumerable<TppPartiesResponse>> GetTppPartiesDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? Spaymentstatus, string? LFIName, string? LFIId)
    {
        return _partiesdataservice.GetTppPartiesDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!, Spaymentstatus!, LFIName!, LFIId!);

    }
}
