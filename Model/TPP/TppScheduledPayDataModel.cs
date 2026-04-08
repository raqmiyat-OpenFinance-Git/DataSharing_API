namespace DataSharing_API.Model.TPP
{
    public class TppScheduledPayDataModel
    {

        public List<TppSchedPaymentResponse>? tpppaymentDataResponsesList { get; set; }

        public TppSchedPaymentResponse? tpppaymentDataResponses { get; set; }

    }
    public class TppSchedPaymentResponse
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
