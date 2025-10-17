namespace DataSharing_API.IService.LFI;

public interface IDashboardService
{
    Task<List<DataSharingOverviewDto>> GetDashboardOverviewAsync(DateTime dateTime);

    Task<DataSharingDashboardDto> GetDataSharingDashboardAsync();

}
