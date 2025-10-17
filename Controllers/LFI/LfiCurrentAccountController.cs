using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiCurrentAccountController : ControllerBase
{
    private readonly ILfiCurrentAccountService _lfiCurrentAccountService;

    public LfiCurrentAccountController(ILfiCurrentAccountService lfiCurrentAccountService)
    {
        _lfiCurrentAccountService = lfiCurrentAccountService;
    }
    /// <summary>
    /// Retrieves list of current account product data by ProductQuoteId.
    /// </summary>
    [HttpGet("GetProductDataListAsync")]
    public async Task<IActionResult> GetProductDataListAsync([FromQuery] int productQuoteId)
    {
        if (productQuoteId <= 0)
            return BadRequest("Invalid ProductQuoteId");

        var result = await _lfiCurrentAccountService.GetProductDataListAsync(productQuoteId);
        return Ok(result);
    }

    /// <summary>
    /// Searches current account product data using filter parameters.
    /// </summary>
    [HttpGet("GetProductDataSearchAsync")]
    public async Task<IActionResult> GetProductDataSearchAsync(
        [FromQuery] string? fromDate = null,
        [FromQuery] string? toDate = null,
        [FromQuery] string? type = null,
        [FromQuery] string? description = null,
        [FromQuery] bool? isOverdraftAvailable = null,
        [FromQuery] string? documentationType = null,
        [FromQuery] string? feesName = null,
        [FromQuery] string? benefitsName = null,
        [FromQuery] string? currency = null,
        [FromQuery] string? status = null)
    {
        var result = await _lfiCurrentAccountService.GetProductDataSearchAsync(
            fromDate, toDate, type, description, isOverdraftAvailable,
            documentationType, feesName, benefitsName, currency, status);

        return Ok(result);
    }


    /// <summary>
    /// Retrieves product data by unique RequestId.
    /// </summary>
    [HttpGet("GetProductDataByRefIdAsync")]
    public async Task<IActionResult> GetProductDataByRefIdAsync([FromQuery] long requestId)
    {
        if (requestId <= 0)
            return BadRequest("Invalid RequestId");

        var result = await _lfiCurrentAccountService.GetProductDataByRefIdAsync(requestId);
        if (result == null)
            return NotFound($"No record found for RequestId: {requestId}");

        return Ok(result);
    }


}

