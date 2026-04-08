using DataSharing_API.IService.TPP;
namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppProductQuoteMastersController : ControllerBase
{
    private readonly ITppProductQuoteMasters _tppProductQuoteMasters;

    public TppProductQuoteMastersController(ITppProductQuoteMasters tppProductQuoteMasters)
    {
        _tppProductQuoteMasters = tppProductQuoteMasters;
    }

    /// <summary>
    /// Retrieves list of current account product data by ProductQuoteId.
    /// </summary>
    [HttpGet("GetProductQuoteMasters")]
    public async Task<IActionResult> GetProductQuoteMasters()
    {
        var result = await _tppProductQuoteMasters.GetProductQuoteMasters();
        return Ok(result);
    }
}