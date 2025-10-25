using OpenFinance.Models;

namespace DataSharing_API.IService.LFI;

public interface ILfiCreateLeadService
{
    Task<IEnumerable<LeadModel>> GetLeadListAsync();

    Task<LeadModel> GetLeadByRefIdAsync(string RequestId);

    Task<IEnumerable<LeadModel>> GetLeadSearchByIdAsync(string LeadId, string Fromdate, string Todate, string Email, string status, string EmirateId, string GivenName, string ProductType, string OrganizationId, string ClientId);
}
