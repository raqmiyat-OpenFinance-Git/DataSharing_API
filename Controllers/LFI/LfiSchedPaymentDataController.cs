using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiSchedPaymentDataController : ControllerBase
{
    private readonly ILfiSchedPaymentDataService _paymentdataservice;

    public LfiSchedPaymentDataController(ILfiSchedPaymentDataService paymentdataservice)
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
    public Task<IEnumerable<SchedPaymentResponse>> GetPaymentDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type, string? Spaymentstatus, string? OrganizationId, string? ClientId)
    {
        return _paymentdataservice.GetPaymentDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!, Spaymentstatus!, OrganizationId!, ClientId!);

    }
}
