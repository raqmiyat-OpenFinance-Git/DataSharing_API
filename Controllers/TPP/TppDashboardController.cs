using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class TppDashboardController : ControllerBase
{
    private readonly ITppDashboardService _tppdashboardService;

    public TppDashboardController(ITppDashboardService TppdashboardService)
    {
        _tppdashboardService = TppdashboardService;
    }

    [HttpGet]
    [Route("GetTppDashboardOverviewAsync")]
    public Task<List<TppDataSharingOverviewDto>> GetTppDashboardOverviewAsync(DateTime dateTime)
    {
        return _tppdashboardService.GetTppDashboardOverviewAsync(dateTime);
    }

    [HttpGet]
    [Route("GetTppDataSharingDashboardSummary")]
    public async Task<IActionResult> GetTppDataSharingDashboard()
    {
        try
        {
            TppDataSharingDashboardDto dashboard = await _tppdashboardService.GetTppDataSharingDashboardAsync();
            return Ok(dashboard);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while fetching GetDataSharingDashboard data.", details = ex.Message });
        }
    }
}
