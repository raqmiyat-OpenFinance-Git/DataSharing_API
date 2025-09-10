using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace DataSharing_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectDebitDataController : ControllerBase
    {
        private readonly IDirectDebitDataService _directdebitdataservice;

        public DirectDebitDataController(IDirectDebitDataService directdebitdataservice)
        {
            this._directdebitdataservice = directdebitdataservice;
        }
        [HttpGet]
        [Route("GetDirectdebitDataList")]
        public Task<IEnumerable<DirectDebitResponse>> GetDirectdebitDataList()
        {
            return _directdebitdataservice.GetDirectdebitDataListAsync();

        }
        [HttpGet]
        [Route("GetDirectdebitDataByRefId")]
        public Task<DirectDebitResponse> GetDirectdebitDataByRefId(string CorrelationId)
        {
            return _directdebitdataservice.GetDirectdebitDataByRefIdAsync(CorrelationId);

        }
        [HttpGet]
        [Route("GetDirectdebitDataSearchById")]
        public Task<IEnumerable<DirectDebitResponse>> GetDirectdebitDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type)
        {
            return _directdebitdataservice.GetDirectdebitDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!);

        }
    }
}
