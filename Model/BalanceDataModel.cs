namespace DataSharing_API.Model
{
    public class BalanceDataModel
    {
        public List<BalanceData>? Data { get; set; }
        public BalanceData? balanceData { get; set; }

    }
    public class BalanceData
    {
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? CreditDebitIndicator { get; set; }
        public string? BalanceType { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Included { get; set; }
        public string? CreditType { get; set; }
        public string? AccountBalanceAmount { get; set; }
        public string? AccountBalanceCurrency { get; set; }
        public string? CreditLineAmount { get; set; }
        public string? CreditLineCurrency { get; set; }
        public string? Status { get; set; }
        public string? RequestType { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? O3CallerOrgId { get; set; }
        public string? O3CallerClientId { get; set; }
    }

}

