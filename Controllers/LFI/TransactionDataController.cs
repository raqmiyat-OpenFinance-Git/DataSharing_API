using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class TransactionDataController : ControllerBase
{
    private readonly ITransactionDataService _transactionDataservice;

    public TransactionDataController(ITransactionDataService transactionDataservice)
    {
        _transactionDataservice = transactionDataservice;
    }
    [HttpGet]
    [Route("GetTransactionDataList")]
    public Task<IEnumerable<TransactionDataResponse>> GetTransactionDataList()
    {
        return _transactionDataservice.GetTransactionDataListAsync();

    }
    [HttpGet]
    [Route("GetTransactionDataByRefId")]
    public Task<TransactionDataResponse> GetTransactionDataByRefId(string CorrelationId)
    {
        return _transactionDataservice.GetTransactionDataByRefIdAsync(CorrelationId);

    }
    [HttpGet]
    [Route("GetTransactionDataSearchById")]
    public Task<IEnumerable<TransactionDataResponse>> GetTransactionDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId)
    {
        return _transactionDataservice.GetTransactionDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId);

    }
}
