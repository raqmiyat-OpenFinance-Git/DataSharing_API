using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace DataSharing_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountDataController : ControllerBase
    {
        private readonly IAccountDataService _accountdataservice;

        public AccountDataController(IAccountDataService accountdataservice)
        {
            this._accountdataservice = accountdataservice;
        }
        [HttpGet]
        [Route("GetAccountDataList")]
        public Task<IEnumerable<AccountDataResponse>> GetAccountDataList()
        {
            return _accountdataservice.GetAccountDataListAsync();

        }
        [HttpGet]
        [Route("GetAccountDataByRefId")]
        public Task<AccountDataResponse> GetAccountDataByRefId(string CorrelationId)
        {
            return _accountdataservice.GetAccountDataByRefIdAsync(CorrelationId);

        }

        [HttpGet]
        [Route("GetAccountDataSearchById")]
        public Task<IEnumerable<AccountDataResponse>> GetAccountDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type)
        {
            return _accountdataservice.GetAccountDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId, Type);

        }
    }
}
