using DataSharing_API.IService.LFI;

namespace DataSharing_API.Service.LFI;

public class TppDashboardService : ITppDashboardService
{
    private IDbConnection _idbConnection;
    private readonly DataSharingLogger _logger;

    public TppDashboardService(IDbConnection idbConnection, DataSharingLogger logger)
    {
        _idbConnection = idbConnection;
        _logger = logger;

    }
    public async Task<List<TppDataSharingOverviewDto>> GetTppDashboardOverviewAsync(DateTime dateTime)
    {

        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Date", dateTime, DbType.Date);

            var result = await _idbConnection.QueryAsync<TppDataSharingOverviewDto>(
                "Usp_Of_GetDashboardOverview",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error while fetching DataSharing Dashboard Overview");
            return new List<TppDataSharingOverviewDto>();
        }
    }

    public async Task<TppDataSharingDashboardDto> GetTppDataSharingDashboardAsync()
    {
        using var multi = await _idbConnection.QueryMultipleAsync(
            "OF_Sp_Tpp_GetDataSharingDashboardSummary",
            commandType: CommandType.StoredProcedure);

        var dashboard = new TppDataSharingDashboardDto
        {
            Table = (await multi.ReadAsync<TppDataSharingTableDto>()).ToList(),
            Chart = (await multi.ReadAsync<TppDataSharingChartDto>()).ToList()
        };

        return dashboard;
    }
}



