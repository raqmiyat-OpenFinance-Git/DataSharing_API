namespace DataSharing_API.Model
{
    public class DirectDebitResponseModel
    {
        public List<DirectDebitResponse>? directdebitDataResponsesList { get; set; }

        public DirectDebitResponse? directdebitDataResponses { get; set; }

    }
    public class DirectDebitResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? DirectDebitId { get; set; }
        public string? MandateIdentification { get; set; }
        public string? DirectDebitStatusCode { get; set; }
        public string? Name { get; set; }
        public string? Frequency { get; set; }
        public string? PreviousPaymentDateTime { get; set; }
        public string? PreviousPaymentAmount { get; set; }
        public string? PreviousPaymentCurrency { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    }

