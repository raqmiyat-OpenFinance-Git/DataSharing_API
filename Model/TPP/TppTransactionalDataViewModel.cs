namespace DataSharing_API.Model.TPP
{
    public class TppTransactionalDataViewModel
    {
      
            public List<TppTransactionalData>? tppTransactionalDatas { get; set; }
            public TppTransactionalData? tppTransactionalData { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public string? ConsentId { get; set; }
            public string? AccountId { get; set; }
            public string? TransactionCode { get; set; }
            public string? Status { get; set; }
            public string? PaymentCategory { get; set; }
            public string? LFIName { get; set; }
            public string? LFIId { get; set; }



        
    }
}
