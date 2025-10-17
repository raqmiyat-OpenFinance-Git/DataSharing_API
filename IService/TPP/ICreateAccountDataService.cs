namespace DataSharing_API.IService.TPP;

public interface ICreateAccountDataService
{
    Task<List<TppAccountsDetailDto>> GetAllTppAccountAsync();
    Task<List<TppAccountsDetailDto>> GetTppAccountByDateAsync(TppAccountsViewModel tppAccountsViewModel);
    Task<TppAccountsDetailDto> GetTppAccountByIdAsync(long accountsRequestId);
    Task<long> SaveAccountRequestAsync(TppAccountsRequest tppAccountsRequest);
    Task<string> SaveAccountResponseAsync(long id, TppAccountsResponse tppAccountsResponse);
}
