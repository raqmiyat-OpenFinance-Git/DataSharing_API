using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiSavingsAccountController : ControllerBase
{
    private readonly ILfiSavingsAccountService _lfiSavingsAccountService;

    public LfiSavingsAccountController(ILfiSavingsAccountService lfiSavingsAccountService)
    {
        _lfiSavingsAccountService = lfiSavingsAccountService;
    }
    /// <summary>
    /// Retrieves list of current account product data by ProductQuoteId.
    /// </summary>
    [HttpGet("GetProductDataListAsync")]
    public async Task<IActionResult> GetProductDataListAsync([FromQuery] int productQuoteId)
    {
        if (productQuoteId <= 0)
            return BadRequest("Invalid ProductQuoteId");

        var result = await _lfiSavingsAccountService.GetProductDataListAsync(productQuoteId);
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
    [FromQuery] decimal? minimumBalance = null,
    [FromQuery] string? documentationType = null,
    [FromQuery] string? rateType = null,
    [FromQuery] decimal? annualRate = null,
    [FromQuery] string? chargeName = null,
    [FromQuery] decimal? chargeAmount = null,
    [FromQuery] decimal? limitsAmount = null,
    [FromQuery] string? status = null)
    {
        var result = await _lfiSavingsAccountService.GetProductDataSearchAsync(
            fromDate, toDate, type, minimumBalance,
            documentationType, rateType, annualRate, chargeName, chargeAmount, limitsAmount, status);

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

        var result = await _lfiSavingsAccountService.GetProductDataByRefIdAsync(requestId);
        if (result == null)
            return NotFound($"No record found for RequestId: {requestId}");

        return Ok(result);
    }


}

