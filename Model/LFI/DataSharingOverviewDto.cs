namespace DataSharing_API.Model.LFI
{
    public class DataSharingOverviewDto
    {
        public int TotalCount { get; set; }
        public int PendingCount { get; set; }
        public int SuccessfullyProcessed { get; set; }
        public int Failed { get; set; }
        public string TransactionName { get; set; } = string.Empty;
    }

}
