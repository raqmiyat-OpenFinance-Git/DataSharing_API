namespace DataSharing_API.Models
{
    public class CreateBalanceCBModelDto
    {
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public TppBalancesRequest? centralBankCustomerRequestHeader { get; set; }
       // public CentralBankBalanceResponse? centralBankBalanceByIdResponse { get; set; }
    }
}
