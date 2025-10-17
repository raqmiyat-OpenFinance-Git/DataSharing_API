using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiCopQueryDataController : ControllerBase
{
    private readonly ILfiCopQueryDataService _lfiCopQueryDataService;

    public LfiCopQueryDataController(ILfiCopQueryDataService lfiCopQueryDataService)
    {
        _lfiCopQueryDataService = lfiCopQueryDataService;
    }
    [HttpGet]
    [Route("GetCopQueryDataList")]
    public Task<IEnumerable<LfiCoPQueryData>> GetCopQueryDataListAsync()
    {
        return _lfiCopQueryDataService.GetCopQueryDataListAsync();

    }
    [HttpGet]
    [Route("GetCopQueryDataByRefId")]
    public Task<LfiCoPQueryData> GetCopQueryDataByRefIdAsync(string CorrelationId)
    {
        return _lfiCopQueryDataService.GetCopQueryDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetCopQueryDataSearchById")]
    public Task<IEnumerable<LfiCoPQueryData>> GetCopQueryDataSearchByIdAsync(string FromDate, string ToDate, string? CustomerName, string? CustomerStatus)
    {
        return _lfiCopQueryDataService.GetCopQueryDataSearchByIdAsync(FromDate, ToDate, CustomerName, CustomerStatus);

    }
}
