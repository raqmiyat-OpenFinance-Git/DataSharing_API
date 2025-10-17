namespace DataSharing_API.IService.TPP;

public interface ICreateBalanceDataService
{

    Task<List<TppBalancesDetailDto>> GetAllTppBalancesAsync();
    Task<List<TppBalancesDetailDto>> GetTppBalancesByDateAsync(TppBalancesViewModel tppBalancesViewModel);
    Task<TppBalancesDetailDto> GetTppBalancesByIdAsync(long balanceRequestId);
    Task<long> SaveBalanceRequestAsync(TppBalancesRequest tppBalancesRequest);
    Task<string> SaveBalanceResponseAsync(long id, TppBalancesResponse tppBalancesResponse);
    bool ValidateConsentId(string consentId);
}
