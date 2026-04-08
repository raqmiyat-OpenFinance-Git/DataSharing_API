using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppDirectDebitDataController : ControllerBase
{
    private readonly ITppDirectDebitDataService _tppdirectdebitdataservice;

    public TppDirectDebitDataController(ITppDirectDebitDataService tppdirectdebitdataservice)
    {
        _tppdirectdebitdataservice = tppdirectdebitdataservice;
    }
    [HttpGet]
    [Route("GetTppDirectdebitDataList")]
    public Task<IEnumerable<TppDirectDebitResponse>> GetTppDirectdebitDataList()
    {
        return _tppdirectdebitdataservice.GetTppDirectdebitDataListAsync();

    }
    [HttpGet]
    [Route("GetTppDirectdebitDataByRefId")]
    public Task<TppDirectDebitResponse> GetTppDirectdebitDataByRefId(string CorrelationId)
    {
        return _tppdirectdebitdataservice.GetTppDirectdebitDataByRefIdAsync(CorrelationId);

    }
    [HttpGet]
    [Route("GetTppDirectdebitDataSearchById")]
    public Task<IEnumerable<TppDirectDebitResponse>> GetTppDirectdebitDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? status, string? LFIName, string? LFIId)
    {
        return _tppdirectdebitdataservice.GetTppDirectdebitDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!,  status!,  LFIName!,  LFIId!);

    }
}
