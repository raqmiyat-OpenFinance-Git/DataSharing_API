using OpenFinance.Models;
using OpenFinance.Models.TPP;

namespace DataSharing_API.IService.TPP;

public interface ITppCreateLeadService
{
    Task<IEnumerable<TppLeadModel>> GetLeadListAsync();

    Task<TppLeadModel> GetLeadByRefIdAsync(string RequestId);

    Task<IEnumerable<TppLeadModel>> GetLeadSearchByIdAsync(string LeadId, string Fromdate, string Todate, string Email, string status, string EmirateId, string GivenName, string ProductType);
}
