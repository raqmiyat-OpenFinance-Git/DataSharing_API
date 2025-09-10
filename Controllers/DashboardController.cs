using DataSharing_API.IService;
using DataSharing_API.Model;
using DataSharing_API.Model.DataSharingDashboard;
using Microsoft.AspNetCore.Mvc;

namespace DataSharing_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [Route("GetDashboardOverviewAsync")]
        public Task<List<DataSharingOverviewDto>> GetDashboardOverviewAsync(DateTime dateTime)
        {
            return _dashboardService.GetDashboardOverviewAsync(dateTime);
        }

        [HttpGet]
        [Route("GetDataSharingDashboardSummary")]
        public async Task<IActionResult> GetDataSharingDashboard()
        {
            try
            {
                DataSharingDashboardDto dashboard = await _dashboardService.GetDataSharingDashboardAsync();
                return Ok(dashboard);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching GetDataSharingDashboard data.", details = ex.Message });
            }
        }
    }
}
