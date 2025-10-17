namespace DataSharing_API.Model.LFI
{
    public class StandOrderResponseModel
    {
        public List<StandOrderResponse>? standOrderDataResponsesList { get; set; }

        public StandOrderResponse? standOrderDataResponses { get; set; }

    }
    public class StandOrderResponse
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
    }
}

