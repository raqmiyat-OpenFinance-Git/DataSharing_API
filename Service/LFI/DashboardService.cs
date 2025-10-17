using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class DashboardService : IDashboardService
{
    private IDbConnection _idbConnection;
    private readonly DataSharingLogger _logger;

    public DashboardService(IDbConnection idbConnection, DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _logger = logger;

    }
    public async Task<List<DataSharingOverviewDto>> GetDashboardOverviewAsync(DateTime dateTime)
    {
        //var result = new DataSharingOverviewDto();
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Date", dateTime, DbType.Date);

            var result = await _idbConnection.QueryAsync<DataSharingOverviewDto>(
                "Usp_Of_GetDashboardOverview",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error while fetching DataSharing Dashboard Overview");
            return new List<DataSharingOverviewDto>();
        }
    }

    public async Task<DataSharingDashboardDto> GetDataSharingDashboardAsync()
    {
        using var multi = await _idbConnection.QueryMultipleAsync(
            "OF_Sp_GetDataSharingDashboardSummary",
            commandType: CommandType.StoredProcedure);

        var dashboard = new DataSharingDashboardDto
        {
            Table = (await multi.ReadAsync<DataSharingTableDto>()).ToList(),
            Chart = (await multi.ReadAsync<DataSharingChartDto>()).ToList()
        };

        return dashboard;
    }
}



