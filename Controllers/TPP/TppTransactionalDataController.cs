using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class TppTransactionalDataController : ControllerBase
{
    private readonly ITppTransactionalDataService _TppTransactionalDataService;

    public TppTransactionalDataController(ITppTransactionalDataService TppTransactionalDataService)
    {
        _TppTransactionalDataService = TppTransactionalDataService;
    }

    [HttpGet("GetTppTransactionalDataListAsync")]
    public async Task<IActionResult> GetTppTransactionalDataListAsync([FromQuery] string paymentCategory)
    {
        if (string.IsNullOrEmpty(paymentCategory))
            return BadRequest("Invalid PaymentCategory");

        var result = await _TppTransactionalDataService.GetTppTransactionalDataListAsync(paymentCategory);
        return Ok(result);
    }

    [HttpGet("GetTppTransactionalDataSearchByIdAsync")]
    public async Task<IActionResult> GetTppTransactionalDataSearchByIdAsync(
        [FromQuery] string? fromDate = null,
        [FromQuery] string? toDate = null,
        [FromQuery] string? consentId = null,
        [FromQuery] string? accountId = null,
        [FromQuery] string? currentStatus = null,
        [FromQuery] string? paymentCategory = null, [FromQuery] string? OrganizationId= null, [FromQuery] string? ClientId = null, [FromQuery] string? PaymentTransactionId= null)
    {
        var result = await _TppTransactionalDataService.GetTppTransactionalDataSearchByIdAsync(
            fromDate, toDate, consentId, accountId, currentStatus, paymentCategory, OrganizationId, ClientId, PaymentTransactionId);

        return Ok(result);
    }



    [HttpGet("GetTppTransactionalDataByRefIdAsync")]
    public async Task<IActionResult> GetTppTransactionalDataByRefIdAsync([FromQuery] long requestId)
    {
        if (requestId <= 0)
            return BadRequest("Invalid RequestId");

        var result = await _TppTransactionalDataService.GetTppTransactionalDataByRefIdAsync(requestId);
        if (result == null)
            return NotFound($"No record found for RequestId: {requestId}");

        return Ok(result);
    }

}
