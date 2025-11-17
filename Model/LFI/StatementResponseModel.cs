namespace DataSharing_API.Model.LFI
{
    public class StatementResponseModel
    {
        public List<StatementResponse>? statementResponsesList { get; set; }

        public StatementResponse? statementResponse { get; set; }

    }
    public class StatementResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? AccountSubType { get; set; }
        public string? StatementId { get; set; }
        public string? StatementDate { get; set; }
        public string? OpeningDate { get; set; }
        public string? ClosingDate { get; set; }
        public string? CreditLineAmount { get; set; }
        public string? CreditLineCurrency { get; set; }
        public string? OpeningBalanceIndicator { get; set; }
        public string? OpeningBalanceAmount { get; set; }
        public string? OpeningBalanceCurrency { get; set; }
        public string? OpeningComponentsBalanceCategory { get; set; }
        public string? ClosingBalanceIndicator { get; set; }
        public string? ClosingBalanceAmount { get; set; }
        public string? ClosingBalanceCurrency { get; set; }
        public string? ClosingComponentsBalanceCategory { get; set; }
        public string? SummaryCreditDebitIndicator { get; set; }
        public string? SummaryTransactionType { get; set; }
        public string? SummarySubTransactionType { get; set; }
        public string? SummaryAmount { get; set; }
        public string? SummaryCurrency { get; set; }
        public string? SummaryCount { get; set; }
        public string? ExpectedChargeAmount { get; set; }
        public string? ExpectedChargeCurrency { get; set; }
        public string? ExpectedStatementType { get; set; }
        public string? NextPaymentDate { get; set; }
        public string? NextPaymentAmount { get; set; }
        public string? NextPaymentCurrency { get; set; }
        public string? NextPaymentType { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? TppName { get; set; }
        public string? TppClientId { get; set; }
        public string? ConsentId { get; set; }
    }
}

