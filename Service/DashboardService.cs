using Dapper;
using DataSharing_API.IService;
using DataSharing_API.Model;
using DataSharing_API.Model.DataSharingDashboard;
using DataSharing_API.Services;
using System.Data;

namespace DataSharing_API.Service
{
    public class DashboardService : IDashboardService
    {
        private IDbConnection _idbConnection;
        private readonly NLogManagerService _logger;

        public DashboardService(IDbConnection idbConnection, NLogManagerService logger)
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
                _logger.LogError(ex, "Error while fetching DataSharing Dashboard Overview");
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
}



