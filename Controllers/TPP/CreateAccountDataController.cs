using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class CreateAccountDataController : Controller
{

    private readonly ICreateAccountDataService _service;
    private readonly DataSharingLogger _logger;
    public CreateAccountDataController(ICreateAccountDataService service, DataSharingLogger logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [Route("GetAllTppAccountAsync")]
    public Task<List<TppAccountsDetailDto>> GetAllTppAccountAsync()
    {
        return _service.GetAllTppAccountAsync();

    }
    [HttpPost]
    [Route("GetTppAccountByDateAsync")]
    public Task<List<TppAccountsDetailDto>> GetTppAccountByDateAsync([FromBody] TppAccountsViewModel tppAccountsViewModel)
    {
        return _service.GetTppAccountByDateAsync(tppAccountsViewModel);
    }

    [HttpGet]
    [Route("GetTppAccountByIdAsync")]
    public Task<TppAccountsDetailDto> GetTppAccountByIdAsync(long accountsRequestId)
    {
        return _service.GetTppAccountByIdAsync(accountsRequestId);
    }

    [HttpPost]
    [Route("SaveAccountAsync")]
    public async Task<ResponseStatus> SaveAccountAsync([FromBody] TppAccountsViewModel tppAccountsViewModel)
    {
        var responseStatus = new ResponseStatus();
        var errorDetails = new List<ErrorDetail>();
        var errorDetail = new ErrorDetail();
        try
        {
            var tppAccountsRequest = tppAccountsViewModel.tppAccountsRequest;
            var tppAccountsResponse = tppAccountsViewModel.tppAccountsResponse;
            long balanceRequestId = await _service.SaveAccountRequestAsync(tppAccountsRequest);
            var responseValue = await _service.SaveAccountResponseAsync(balanceRequestId, tppAccountsResponse);

            if (responseValue == "SUCCESS")
            {
                responseStatus.status = "SUCCESS";
                responseStatus.statusMessage = "Balances saved successfully.";

                errorDetail.ErrorCode = "000";
                errorDetail.ErrorDesc = "";
                errorDetails.Add(errorDetail);
            }
            else
            {
                errorDetail.ErrorCode = "401";
                errorDetail.ErrorDesc = "Unable to save consent.";
                errorDetails.Add(errorDetail);
            }
        }
        catch (Exception ex)
        {
            errorDetail.ErrorCode = "400";
            errorDetail.ErrorDesc = "Exception " + ex.Message;
            errorDetails.Add(errorDetail);
            _logger.Error(ex);
        }

        responseStatus.errorDetails = errorDetails;
        return responseStatus;
    }




}
