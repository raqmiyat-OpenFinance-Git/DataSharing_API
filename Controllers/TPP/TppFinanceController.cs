using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppFinanceController : ControllerBase
{
    private readonly ITppFinanceService _tppPersonalLoanService;

    public TppFinanceController(ITppFinanceService tppPersonalLoanService)
    {
        _tppPersonalLoanService = tppPersonalLoanService;
    }
    /// <summary>
    /// Retrieves list of current account product data by ProductQuoteId.
    /// </summary>
    [HttpGet("GetProductDataListAsync")]
    public async Task<IActionResult> GetProductDataListAsync([FromQuery] int productQuoteId)
    {
        if (productQuoteId <= 0)
            return BadRequest("Invalid ProductQuoteId");

        var result = await _tppPersonalLoanService.GetProductDataListAsync(productQuoteId);
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
        var result = await _tppPersonalLoanService.GetProductDataSearchAsync(
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

        var result = await _tppPersonalLoanService.GetProductDataByRefIdAsync(requestId);
        if (result == null)
            return NotFound($"No record found for RequestId: {requestId}");

        return Ok(result);
    }
}

