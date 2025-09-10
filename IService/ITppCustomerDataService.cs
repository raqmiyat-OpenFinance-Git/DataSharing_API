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

    }
}
