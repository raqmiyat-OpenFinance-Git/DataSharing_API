using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppCreditCardController : ControllerBase
{
    private readonly ITppCreditCardService _tppCreditCardService;

    public TppCreditCardController(ITppCreditCardService tppCreditCardService)
    {
        _tppCreditCardService = tppCreditCardService;
    }
    /// <summary>
    /// Retrieves list of current account product data by ProductQuoteId.
    /// </summary>
    [HttpGet("GetProductDataListAsync")]
    public async Task<IActionResult> GetProductDataListAsync([FromQuery] int productQuoteId)
    {
        if (productQuoteId <= 0)
            return BadRequest("Invalid ProductQuoteId");

        var result = await _tppCreditCardService.GetProductDataListAsync(productQuoteId);
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
    [FromQuery] string? documentationType = null,
    [FromQuery] decimal? chargeRate = null,
    [FromQuery] decimal? fixedRate = null,
    [FromQuery] string? chargeName = null,
    [FromQuery] decimal? chargeAmount = null,
    [FromQuery] decimal? limitsAmount = null,
    [FromQuery] string? status = null)
    {
        var result = await _tppCreditCardService.GetProductDataSearchAsync(
            fromDate, toDate, type, documentationType, chargeRate,
            fixedRate, chargeName, chargeAmount, limitsAmount, status);

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

        var result = await _tppCreditCardService.GetProductDataByRefIdAsync(requestId);
        if (result == null)
            return NotFound($"No record found for RequestId: {requestId}");

        return Ok(result);
    }
}

