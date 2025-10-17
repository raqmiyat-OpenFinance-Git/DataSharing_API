using DataSharing_API.IService.LFI;
using DataSharing_API.Service.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiProductQuoteMastersController : ControllerBase
{
    private readonly ILfiProductQuoteMasters _lfiProductQuoteMasters;

    public LfiProductQuoteMastersController(ILfiProductQuoteMasters lfiProductQuoteMasters)
    {
        _lfiProductQuoteMasters = lfiProductQuoteMasters;
    }
    /// <summary>
    /// Retrieves list of current account product data by ProductQuoteId.
    /// </summary>
    [HttpGet("GetProductQuoteMasters")]
    public async Task<IActionResult> GetProductQuoteMasters()
    {
        var result = await _lfiProductQuoteMasters.GetProductQuoteMasters();
        return Ok(result);
    }
    
}

