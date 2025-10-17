namespace DataSharing_API.Model.LFI
{
    public class CentralBankResponseWrapper
    {
        public Guid CorrelationId { get; set; }
        public CentralBankBalanceResponse? BalanceResponse { get; set; }

    }
}
