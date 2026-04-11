namespace DataSharing_API.Model.TPP
{
    public class TppStatementDataModel
    {

        public List<TppStatementResponse>? tppstatementResponsesList { get; set; }

        public TppStatementResponse? tppstatementResponse { get; set; }
    }
    public class TppStatementResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AuthDate { get; set; }
        public string? ipAddress { get; set; }
        public string? InteractionId { get; set; }
        public string? Authorization { get; set; }
        public string? CustomerUseragent { get; set; }
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
        public string? LinksSelf { get; set; }
        public string? LinksFirst { get; set; }
        public string? LinksPrev { get; set; }
        public string? LinksNext { get; set; }
        public string? LinksLast { get; set; }
        public int? TotalPages { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? LFIName { get; set; }
        public string? ConsentId { get; set; }
        public string? LFIId { get; set; }
        public string? Type { get; set; }
    

    }
}
