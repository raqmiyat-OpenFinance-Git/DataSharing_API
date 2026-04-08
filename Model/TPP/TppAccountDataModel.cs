namespace DataSharing_API.Model.TPP
{
    public class TPPAccounDataModel
    {
        public List<TPPAccountDataResponse>? tppaccountDataResponseList { get; set; }

        public TPPAccountDataResponse? tppaccountDataResponses { get; set; }
    }
    public class TPPAccountDataResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AuthDate { get; set; }
        public string? ipAddress { get; set; }
        public string? InteractionId { get; set; }
        public string? CustomerUseragent { get; set; }
        public string? AccountId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? AccountStatus { get; set; }

        public string? StatusUpdateDateTime { get; set; }
        public string? Currency { get; set; }

        public string? AccountType { get; set; }
        public string? AccountSubType { get; set; }
        public string? NickName { get; set; }
        public string? OpeningDate { get; set; }
        public string? MaturityDate { get; set; }


        public string? AccountIdentifiersName { get; set; }
        public string? AccountIdentifiersSchemeName { get; set; }
        public string? AccountIdentifiersId { get; set; }

        public string? ServicerSchemeName { get; set; }
        public string? ServicerIdentification { get; set; }

        public string? IsShariaCompliant { get; set; }
        public string? LinksSelf { get; set; }

        public string? LinksFirst { get; set; }
        public string? LinksPrev { get; set; }
        public string? LinksNext { get; set; }
        public string? LinksLast { get; set; }
        public string? LFIName { get; set; }
        public string? LFIId { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
