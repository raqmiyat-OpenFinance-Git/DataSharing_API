namespace DataSharing_API.Model.TPP
{
    public class TppBalanceDataModel
    {
        public List<TppBalanceData>? tppDataList { get; set; }
        public TppBalanceData? tppbalanceData { get; set; }
    }
    public class TppBalanceData
    {

        public Guid CorrelationId { get; set; }
        public string? AuthDate { get; set; }
        public string? ipAddress { get; set; }
        public string? InteractionId { get; set; }
        public string? Authorization { get; set; }
        public string? CustomerUseragent { get; set; }
        public string? AccountId { get; set; }
        public string? CreditDebitIndicator { get; set; }
        public string? BalanceType { get; set; }
        public DateTime AccountBalanceDateTime { get; set; }
        public bool Included { get; set; }
        public string? CreditType { get; set; }
        public string? AccountBalanceAmount { get; set; }
        public string? AccountBalanceCurrency { get; set; }
        public string? CreditLineAmount { get; set; }
        public string? CreditLineCurrency { get; set; }
        public string? BalanceCategory { get; set; }
        public string? ComponentsAmount { get; set; }
        public string? ComponentsCurrency { get; set; }
        public string? LinksSelf { get; set; }

        public string? LinksFirst { get; set; }
        public string? LinksPrev { get; set; }
        public string? LinksNext { get; set; }
        public string? LinksLast { get; set; }
        public string? LFIName { get; set; }
        public string? LFIId { get; set; }
        public string? Status { get; set; }
        public string? RequestType { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ConsentId { get; set; }
    }
}



