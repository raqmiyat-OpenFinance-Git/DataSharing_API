using DataSharing_API.Model.TPP;

namespace DataSharing_API.Model.LFI
{
    public class CreateBalanceCBModelDto
    {
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public TppBalancesRequest? centralBankCustomerRequestHeader { get; set; }
        // public CentralBankBalanceResponse? centralBankBalanceByIdResponse { get; set; }
    }
}
