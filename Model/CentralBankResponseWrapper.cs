using DataSharing_API.Models;

namespace DataSharing_API.Model
{
    public class CentralBankResponseWrapper
    {
            public Guid CorrelationId { get; set; }
            public CentralBankBalanceResponse? BalanceResponse { get; set; }
        
    }
}
