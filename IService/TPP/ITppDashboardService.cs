namespace DataSharing_API.IService.LFI;

public interface ITppDashboardService
{
    Task<List<TppDataSharingOverviewDto>> GetTppDashboardOverviewAsync(DateTime dateTime);

    Task<TppDataSharingDashboardDto> GetTppDataSharingDashboardAsync();

}
