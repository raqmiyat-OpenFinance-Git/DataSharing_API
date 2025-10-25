using DataSharing_API.IService.LFI;
using OpenFinance.Models;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class LfiCreateLeadController : ControllerBase
{
    private readonly ILfiCreateLeadService _createLeadservice;

    public LfiCreateLeadController(ILfiCreateLeadService createLeadservice)
    {
        _createLeadservice = createLeadservice;
    }
    [HttpGet]
    [Route("GetLeadListAsync")]
    public Task<IEnumerable<LeadModel>> GetLeadListAsync()
    {
        return _createLeadservice.GetLeadListAsync();

    }
    [HttpGet]
    [Route("GetLeadByRefIdAsync")]
    public Task<LeadModel> GetLeadByRefIdAsync(string RequestId)
    {
        return _createLeadservice.GetLeadByRefIdAsync(RequestId);

    }

    [HttpGet]
    [Route("GetLeadSearchByIdAsync")]
    public Task<IEnumerable<LeadModel>> GetLeadSearchByIdAsync(string? LeadId, string Fromdate, string Todate, string? Email, string? status, string? EmirateId, string? GivenName, string? ProductType, string? OrganizationId, string? ClientId)
    {
        return _createLeadservice.GetLeadSearchByIdAsync(LeadId!, Fromdate, Todate, Email!, status!, EmirateId!, GivenName!, ProductType!,OrganizationId!, ClientId!);

    }
}
