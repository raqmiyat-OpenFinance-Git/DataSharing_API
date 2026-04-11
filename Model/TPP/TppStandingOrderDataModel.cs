namespace DataSharing_API.Model.TPP
{
    public class TppStandingOrderDataModel
    {
        public List<TppStandOrderResponse>? tppstandOrderDataResponsesList { get; set; }
        public TppStandOrderResponse? tppstandOrderDataResponses { get; set; }
    }
    public class TppStandOrderResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? StandingOrderId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? StandingOrderType { get; set; }
        public string? Frequency { get; set; }
        public string? CreditorReference { get; set; }
        public string? Purpose { get; set; }
        public string? FirstPaymentDateTime { get; set; }
        public string? NextPaymentDateTime { get; set; }
        public string? LastPaymentDateTime { get; set; }
        public string? FinalPaymentDateTime { get; set; }
        public string? NumberOfPayments { get; set; }
        public string? StandingOrderStatusCode { get; set; }
        public string? FirstPaymentAmount { get; set; }
        public string? FirstPaymentCurrency { get; set; }
        public string? NextPaymentAmount { get; set; }
        public string? NextPaymentCurrency { get; set; }
        public string? LastPaymentAmount { get; set; }
        public string? LastPaymentCurrency { get; set; }
        public string? FinalPaymentAmount { get; set; }
        public string? FinalPaymentCurrency { get; set; }
        public string? CreditorAgentSchemeName { get; set; }
        public string? CreditorAgentId { get; set; }
        public string? CreditorAccountSchemeName { get; set; }
        public string? CreditorAccountId { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? LinksSelf { get; set; }
        public string? LinksFirst { get; set; }
        public string? LinksPrev { get; set; }
        public string? LinksNext { get; set; }
        public string? LinksLast { get; set; }
        public string? LFIName { get; set; }
        public string? ConsentId { get; set; }
        public string? LFIId { get; set; }
    }
}

