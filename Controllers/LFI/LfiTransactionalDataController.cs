using DataSharing_API.IService.LFI;
using DataSharing_API.Service.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiTransactionalDataController : ControllerBase
{
    private readonly ILfiTransactionalDataService _lfiTransactionalDataService;

    public LfiTransactionalDataController(ILfiTransactionalDataService lfiTransactionalDataService)
    {
        _lfiTransactionalDataService = lfiTransactionalDataService;
    }

    /// <summary>
    /// Retrieves list of Transactional data by PaymentCategory.
    /// </summary>
    [HttpGet("GetTransactionalDataListAsync")]
    public async Task<IActionResult> GetTransactionalDataListAsync([FromQuery] string paymentCategory)
    {
        if (string.IsNullOrEmpty(paymentCategory))
            return BadRequest("Invalid PaymentCategory");

        var result = await _lfiTransactionalDataService.GetTransactionalDataListAsync(paymentCategory);
        return Ok(result);
    }


    /// <summary>
    /// Searches Transactional data using filter parameters.
    /// </summary>
    [HttpGet("GetTransactionalDataSearchByIdAsync")]
    public async Task<IActionResult> GetTransactionalDataSearchByIdAsync(
        [FromQuery] string? fromDate = null,
        [FromQuery] string? toDate = null,
        [FromQuery] string? consentId = null,
        [FromQuery] string? accountId = null,
        [FromQuery] string? currentStatus = null,
        [FromQuery] string? paymentCategory = null)
    {
        var result = await _lfiTransactionalDataService.GetTransactionalDataSearchByIdAsync(
            fromDate, toDate, consentId, accountId, currentStatus, paymentCategory);

        return Ok(result);
    }


    /// <summary>
    /// Retrieves Transactional by unique RequestId.
    /// </summary>
    [HttpGet("GetTransactionalDataByRefIdAsync")]
    public async Task<IActionResult> GetTransactionalDataByRefIdAsync([FromQuery] long requestId)
    {
        if (requestId <= 0)
            return BadRequest("Invalid RequestId");

        var result = await _lfiTransactionalDataService.GetTransactionalDataByRefIdAsync(requestId);
        if (result == null)
            return NotFound($"No record found for RequestId: {requestId}");

        return Ok(result);
    }

}
