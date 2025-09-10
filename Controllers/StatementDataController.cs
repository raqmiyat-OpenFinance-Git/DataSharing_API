using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace DataSharing_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatementDataController : ControllerBase
    {
        private readonly IStatementDataService _statementdataservice;

        public StatementDataController(IStatementDataService Statementdataservice)
        {
            this._statementdataservice = Statementdataservice;
        }
        [HttpGet]
        [Route("GetStatementDataList")]
        public Task<IEnumerable<StatementResponse>> GetStatementDataList()
        {
            return _statementdataservice.GetStatementDataListAsync();

        }
        [HttpGet]
        [Route("GetStatementDataByRefId")]
        public Task<StatementResponse> GetStatementDataByRefId(string CorrelationId)
        {
            return _statementdataservice.GetStatementDataByRefIdAsync(CorrelationId);

        }
        [HttpGet]
        [Route("GetStatementDataSearchById")]
        public Task<IEnumerable<StatementResponse>> GetStatementDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type)
        {
            return _statementdataservice.GetStatementDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!);

        }
    }
}
