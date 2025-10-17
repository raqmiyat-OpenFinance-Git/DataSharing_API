using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiPersonalLoanController : ControllerBase
{
    private readonly ILfiPersonalLoanService _lfiPersonalLoanService;

    public LfiPersonalLoanController(ILfiPersonalLoanService lfiPersonalLoanService)
    {
        _lfiPersonalLoanService = lfiPersonalLoanService;
    }
    /// <summary>
    /// Retrieves list of current account product data by ProductQuoteId.
    /// </summary>
    [HttpGet("GetProductDataListAsync")]
    public async Task<IActionResult> GetProductDataListAsync([FromQuery] int productQuoteId)
    {
        if (productQuoteId <= 0)
            return BadRequest("Invalid ProductQuoteId");

        var result = await _lfiPersonalLoanService.GetProductDataListAsync(productQuoteId);
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
        [FromQuery] decimal? minimumLoanAmount = null,
        [FromQuery] string? minimumLoanCurrency = null,
        [FromQuery] decimal? minTenure = null,
        [FromQuery] decimal? indicativeRateFrom = null,
        [FromQuery] string? rateType = null,
        [FromQuery] string? documentationType = null,
        [FromQuery] string? feesName = null,
        [FromQuery] string? benefitsName = null,
        [FromQuery] string? status = null)
    {
        var result = await _lfiPersonalLoanService.GetProductDataSearchAsync(
            fromDate, toDate, type, description, minimumLoanAmount, minimumLoanCurrency,
            minTenure, indicativeRateFrom, rateType, documentationType, feesName, benefitsName, status);

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

        var result = await _lfiPersonalLoanService.GetProductDataByRefIdAsync(requestId);
        if (result == null)
            return NotFound($"No record found for RequestId: {requestId}");

        return Ok(result);
    }


}

