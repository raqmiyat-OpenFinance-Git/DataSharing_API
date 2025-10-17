using DataSharing_API.IService.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class CreateBalanceDataController : Controller
{

    private readonly ICreateBalanceDataService _service;
    private readonly DataSharingLogger _logger;
    public CreateBalanceDataController(ICreateBalanceDataService service, DataSharingLogger logger)
    {
        _service = service;
        _logger = logger;
    }


    [HttpGet]
    [Route("GetAllTppBalancesAsync")]
    public Task<List<TppBalancesDetailDto>> GetAllTppBalancesAsync()
    {
        return _service.GetAllTppBalancesAsync();

    }
    [HttpPost]
    [Route("GetTppBalancesByDateAsync")]
    public Task<List<TppBalancesDetailDto>> GetTppBalancesByDateAsync([FromBody] TppBalancesViewModel tppBalancesViewModel)
    {
        return _service.GetTppBalancesByDateAsync(tppBalancesViewModel);
    }

    [HttpGet]
    [Route("GetTppBalancesByIdAsync")]
    public Task<TppBalancesDetailDto> GetTppBalancesByIdAsync(long balanceRequestId)
    {
        return _service.GetTppBalancesByIdAsync(balanceRequestId);
    }

    [HttpGet]
    [Route("ValidateConsentId")]
    public bool ValidateConsentId(string consentId)
    {
        return _service.ValidateConsentId(consentId);
    }

    [HttpPost]
    [Route("SaveBalanceAsync")]
    public async Task<ResponseStatus> SaveBalanceAsync([FromBody] TppBalancesViewModel tppBalancesViewModel)
    {
        var responseStatus = new ResponseStatus();
        var errorDetails = new List<ErrorDetail>();
        var errorDetail = new ErrorDetail();

        try
        {
            var tppBalancesRequest = tppBalancesViewModel.tppBalancesRequest;
            var tppBalancesResponse = tppBalancesViewModel.tppBalancesResponse;
            long balanceRequestId = await _service.SaveBalanceRequestAsync(tppBalancesRequest);
            var responseValue = await _service.SaveBalanceResponseAsync(balanceRequestId, tppBalancesResponse);

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
