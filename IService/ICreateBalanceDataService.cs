using DataSharing_API.Model;
using DataSharing_API.Models;

namespace DataSharing_API.IService
{
    public interface ICreateBalanceDataService
    {
        //Task<List<TppBalanceDataModel>> GetBalanceDataList();
        //Task<TppBalanceDataModel> GetBalanceDataDetails(Guid CorrelationId);
        //Task<CentralBankBalanceResponse> GetBalanceResponseDetails(long RequestId);
        //Task<string> InsertBalanceData(CreateBalanceCBModelDto balancerequest);
        //Task<string> InsertBalanceDataResponse(CentralBankResponseWrapper bankResponseWrapper);
        //bool GetConsentEnquiry(string consentId);
        //Task RejectBalanceData(Guid CorrelationId);

        Task<List<TppBalancesDetailDto>> GetAllTppBalancesAsync();
        Task<List<TppBalancesDetailDto>> GetTppBalancesByDateAsync(TppBalancesViewModel tppBalancesViewModel);
        Task<TppBalancesDetailDto> GetTppBalancesByIdAsync(long balanceRequestId);
        Task<long> SaveBalanceRequestAsync(TppBalancesRequest tppBalancesRequest);
        Task<string> SaveBalanceResponseAsync(long id, TppBalancesResponse tppBalancesResponse);
        bool ValidateConsentId(string consentId);
    }
}
