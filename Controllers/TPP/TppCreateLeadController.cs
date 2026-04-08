using DataSharing_API.IService.TPP;
using OpenFinance.Models;
using OpenFinance.Models.TPP;

namespace DataSharing_API.Controllers.TPP;

[ApiController]
[Route("api/[controller]")]
public class TppCreateLeadController : ControllerBase
{
    private readonly ITppCreateLeadService _createLeadservice;

    public TppCreateLeadController(ITppCreateLeadService createLeadservice)
    {
        _createLeadservice = createLeadservice;
    }
    [HttpGet]
    [Route("GetLeadListAsync")]
    public Task<IEnumerable<TppLeadModel>> GetLeadListAsync()
    {
        return _createLeadservice.GetLeadListAsync();

    }
    [HttpGet]
    [Route("GetLeadByRefIdAsync")]
    public Task<TppLeadModel> GetLeadByRefIdAsync(string RequestId)
    {
        return _createLeadservice.GetLeadByRefIdAsync(RequestId);

    }

    [HttpGet]
    [Route("GetLeadSearchByIdAsync")]
    public Task<IEnumerable<TppLeadModel>> GetLeadSearchByIdAsync(string? LeadId, string Fromdate, string Todate, string? Email, string? status, string? EmirateId, string? GivenName, string? ProductType)
    {
        return _createLeadservice.GetLeadSearchByIdAsync(LeadId!, Fromdate, Todate, Email!, status!, EmirateId!, GivenName!, ProductType!);

    }
}
