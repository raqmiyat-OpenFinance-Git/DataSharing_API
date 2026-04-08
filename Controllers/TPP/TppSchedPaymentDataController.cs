using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class TppSchedPaymentDataController : ControllerBase
{
    private readonly ITppSchedPaymentDataService _tpppaymentdataservice;

    public TppSchedPaymentDataController(ITppSchedPaymentDataService tpppaymentdataservice)
    {
        _tpppaymentdataservice = tpppaymentdataservice;
    }
    [HttpGet]
    [Route("GetTppPaymentDataList")]
    public Task<IEnumerable<TppSchedPaymentResponse>> GetTppPaymentDataList()
    {
        return _tpppaymentdataservice.GetTppPaymentDataListAsync();

    }
    [HttpGet]
    [Route("GetTppPaymentDataByRefId")]
    public Task<TppSchedPaymentResponse> GetTppPaymentDataByRefId(string CorrelationId)
    {
        return _tpppaymentdataservice.GetTppPaymentDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetTppPaymentDataSearchById")]
    public Task<IEnumerable<TppSchedPaymentResponse>> GetTppPaymentDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? Spaymentstatus, string? LFIName, string? LFIId)
    {
        return _tpppaymentdataservice.GetTppPaymentDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!, Spaymentstatus!, LFIName!, LFIId!);

    }
}
