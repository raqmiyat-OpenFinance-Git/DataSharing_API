using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class SchedPaymentDataController : ControllerBase
{
    private readonly ISchedPaymentDataService _paymentdataservice;

    public SchedPaymentDataController(ISchedPaymentDataService paymentdataservice)
    {
        _paymentdataservice = paymentdataservice;
    }
    [HttpGet]
    [Route("GetPaymentDataList")]
    public Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataList()
    {
        return _paymentdataservice.GetPaymentDataListAsync();

    }
    [HttpGet]
    [Route("GetPaymentDataByRefId")]
    public Task<SchedPaymentResponse> GetPaymentDataByRefId(string CorrelationId)
    {
        return _paymentdataservice.GetPaymentDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetPaymentDataSearchById")]
    public Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type)
    {
        return _paymentdataservice.GetPaymentDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!);

    }
}
