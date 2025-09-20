using DataSharing_API.Models;
using OF.DataSharing.Model.CentralBank;
using OF.DataSharing.Model.EFModel;
using OpenFinance.Models;

namespace DataSharing_API.IService
{
    public interface ITppCustomerDataService
    {
        Task<List<CustomerDataRequest>> GetTppCustomerList(string User);
        Task<CustomerDataRequest> GetTppCustomerDetails(Guid CorrelationId);
        Task<string> PostCustomerData(CustomerDataRequest customerDataRequest);
        Task<string> ApproveCustomerData(CentralBankCustomerIdResponse customerDataResponse, Guid CorrelationId);
        Task<CustomerResponse> FetchDetailsReponse(Guid CorrelationId);

        Task<List<CustomerResponse>> FetchCutomerDetailsResponse(Guid CorrelationId);

        Task<List<TppCustomerDetailDto>> GetAllTppCustomerAsync();
        Task<List<TppCustomerDetailDto>> GetTppCustomerByDateAsync(TppCustomerViewDetails tppCustomerViewModel);
        Task<TppCustomerDetailDto> GetTppCustomerByIdAsync(Guid CorrelationId);


    }
}
