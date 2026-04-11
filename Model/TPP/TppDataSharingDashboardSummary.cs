namespace DataSharing_API.Model.TPP
{
    public class TppDataSharingTableDto
    {
        public string LFIName { get; set; } = string.Empty;
        public string ConsentId { get; set; } = string.Empty;
        public string APIUsed { get; set; } = string.Empty;
        public int TotalRequests { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
    }
    //Bar chart
    public class TppDataSharingChartDto
    {
        public string LFIName { get; set; }
        public string Endpoint { get; set; }
        public int TotalRequests { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
    }
    public class TppDataSharingDashboardDto
    {
        public List<TppDataSharingTableDto> Table { get; set; } = new();
        public List<TppDataSharingChartDto> Chart { get; set; } = new();
    }
}
