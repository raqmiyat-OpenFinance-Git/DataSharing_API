namespace DataSharing_API.Model.DataSharingDashboard
{
    public class DataSharingTableDto
    {
        public string TPPName { get; set; } = string.Empty;
        public string APIUsed { get; set; } = string.Empty;
        public int RequestsToday { get; set; }
        public int TotalRequests { get; set; }
        public string Status { get; set; } = string.Empty;
    }
    //Bar chart
    public class DataSharingChartDto
    {
        public string TPPName { get; set; } = string.Empty;
        public int TotalRequests { get; set; }
    }

    //Both result sets

    public class DataSharingDashboardDto
    {
        public List<DataSharingTableDto> Table { get; set; } = new();
        public List<DataSharingChartDto> Chart { get; set; } = new();
    }

}
