using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppBeneficiariesDataController : ControllerBase
{
    private readonly ITppBeneficiariesDataService _beneficiariesdataservice;

    public TppBeneficiariesDataController(ITppBeneficiariesDataService beneficiariesdataservice)
    {
        _beneficiariesdataservice = beneficiariesdataservice;
    }
    [HttpGet]
    [Route("GetTppBeneficiariesDataList")]
    public Task<IEnumerable<TppBeneficiariesResponse>> GetTppBeneficiariesDataList()
    {
        return _beneficiariesdataservice.GetTppBeneficiariesDataListAsync();

    }
    [HttpGet]
    [Route("GetTppBeneficiariesDataByRefId")]
    public Task<TppBeneficiariesResponse> GetTppBeneficiariesDataByRefId(string CorrelationId)
    {
        return _beneficiariesdataservice.GetTppBeneficiariesDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetTppBeneficiariesDataSearchById")]
    public Task<IEnumerable<TppBeneficiariesResponse>> GetTppBeneficiariesDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? status, string? LFIName, string? LFIId)
    {
        return _beneficiariesdataservice.GetTppBeneficiariesDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, status!, LFIName!,  LFIId!);

    }
}
