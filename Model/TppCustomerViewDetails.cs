using OF.DataSharing.Model.EFModel;

namespace OpenFinance.Models
{
    public class TppCustomerViewDetails
    {

      
            public string? FromDate { get; set; }
            public string? ToDate { get; set; }
            public string? ConsentId { get; set; }
            public string? AccountId { get; set; }
            public string? Action { get; set; }
            public List<TppCustomerDetailDto>? tppCustomerDetailDtos { get; set; }
            public CustomerDataRequest? tppCustomerRequest { get; set; }
            public CustomerResponse? tppCustomerResponse { get; set; }
        
    }
}
