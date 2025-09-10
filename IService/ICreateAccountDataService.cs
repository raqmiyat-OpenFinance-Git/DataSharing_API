using DataSharing_API.Model;
using DataSharing_API.Models;

namespace DataSharing_API.IService
{
    public interface ICreateAccountDataService
    {
        Task<List<TppAccountsDetailDto>> GetAllTppAccountAsync();
        Task<List<TppAccountsDetailDto>> GetTppAccountByDateAsync(TppAccountsViewModel tppAccountsViewModel);
        Task<TppAccountsDetailDto> GetTppAccountByIdAsync(long accountRequestId);
        Task<long> SaveAccountRequestAsync(TppAccountsRequest tppAccountsRequest);
        Task<string> SaveAccountResponseAsync(long id, TppAccountsResponse tppAccountsResponse);
    }
}
