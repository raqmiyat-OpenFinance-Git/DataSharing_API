namespace DataSharing_API.Model.LFI
{
    public class AccountDataResponseModel
    {
        public List<AccountDataResponse>? accountDataResponsesList { get; set; }

        public AccountDataResponse? accountDataResponses { get; set; }
    }
    public class AccountDataResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? AccountType { get; set; }
        public string? AccountSubType { get; set; }
        public string? Currency { get; set; }
        public string? AccountStatus { get; set; }
        public string? AccountHolderName { get; set; }
        public string? ServicerSchemeName { get; set; }
        public string? ServicerIdentification { get; set; }
        public string? AccountNumberName { get; set; }
        public string? AccountNumberSchemeName { get; set; }
        public string? AccountNumberIdentification { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? BundleName { get; set; }
        public string? MultiAuth { get; set; }
        public string? BusinessCustomerId { get; set; }
        public string? BusinessCustomerName { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? StatusUpdateDateTime { get; set; }
        public string? Description { get; set; }
        public string? NickName { get; set; }
        public string? OpeningDate { get; set; }
        public string? MaturityDate { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? ConsentId { get; set; }
        public string? TppName { get; set; }
        public string? TppId { get; set; }
    }
}

