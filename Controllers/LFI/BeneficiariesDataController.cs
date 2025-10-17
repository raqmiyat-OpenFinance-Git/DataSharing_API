using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class BeneficiariesDataController : ControllerBase
{
    private readonly IBeneficiariesDataService _beneficiariesdataservice;

    public BeneficiariesDataController(IBeneficiariesDataService beneficiariesdataservice)
    {
        _beneficiariesdataservice = beneficiariesdataservice;
    }
    [HttpGet]
    [Route("GetBeneficiariesDataList")]
    public Task<IEnumerable<BeneficiariesResponse>> GetBeneficiariesDataList()
    {
        return _beneficiariesdataservice.GetBeneficiariesDataListAsync();

    }
    [HttpGet]
    [Route("GetBeneficiariesDataByRefId")]
    public Task<BeneficiariesResponse> GetBeneficiariesDataByRefId(string CorrelationId)
    {
        return _beneficiariesdataservice.GetBeneficiariesDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetBeneficiariesDataSearchById")]
    public Task<IEnumerable<BeneficiariesResponse>> GetBeneficiariesDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type)
    {
        return _beneficiariesdataservice.GetBeneficiariesDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!);

    }
}
