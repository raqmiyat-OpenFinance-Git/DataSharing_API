using DataSharing_API.Model;
using DataSharing_API.Model.DataSharingDashboard;

namespace DataSharing_API.IService
{
    public interface IDashboardService
    {
        Task<List<DataSharingOverviewDto>> GetDashboardOverviewAsync(DateTime dateTime);

        Task<DataSharingDashboardDto> GetDataSharingDashboardAsync();

    }
}
