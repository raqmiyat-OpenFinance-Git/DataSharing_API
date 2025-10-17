namespace DataSharing_API.Model.TPP
{
    public class TppBalanceDataModel
    {

        public long BalanceId { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? AccountBalanceCreditDebitIndicator { get; set; }
        public string? AccountBalanceType { get; set; }
        public DateTime AccountBalanceTimestamp { get; set; }
        public decimal AccountBalanceAmount { get; set; }
        public string? AccountBalanceCurrency { get; set; }
        public bool BalanceCreditLineIncluded { get; set; }
        public string? BalanceCreditLineCreditType { get; set; }
        public decimal? BalanceCreditLineAmount { get; set; }
        public string? BalanceCreditLineCurrency { get; set; }
        public string? O3PsuIdentifier { get; set; }
        public string? O3CallerClientId { get; set; }
        public string? O3CallerOrgId { get; set; }
        public string? O3ConsentId { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ResponseJson { get; set; }
    }
}



