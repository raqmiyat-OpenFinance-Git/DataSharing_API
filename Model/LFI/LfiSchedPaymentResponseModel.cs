namespace DataSharing_API.Model.LFI
{
    public class LfiSchedPaymentResponseModel
    {
        public List<SchedPaymentResponse>? paymentDataResponsesList { get; set; }

        public SchedPaymentResponse? paymentDataResponses { get; set; }

    }
    public class SchedPaymentResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? ScheduledPaymentId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? ScheduledType { get; set; }
        public string? ScheduledPaymentDateTime { get; set; }
        public string? CreditorReference { get; set; }
        public string? DebtorReference { get; set; }
        public string? InstructedAmount { get; set; }
        public string? Currency { get; set; }
        public string? CreditorAgentSchemeName { get; set; }
        public string? CreditorAgentIdentification { get; set; }
        public string? CreditorAccountSchemeName { get; set; }
        public string? CreditorAccountIdentification { get; set; }
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

