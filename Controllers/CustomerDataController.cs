using DataSharing_API.IService;
using DataSharing_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConsentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerDataController : ControllerBase
    {
        private readonly ICustomerDataService _customerdataservice;

        public CustomerDataController(ICustomerDataService customerdataservice)
        {
            this._customerdataservice = customerdataservice;
        }
        [HttpGet]
        [Route("GetCustomerDataList")]
        public Task<IEnumerable<CustomerDataResponse>> GetCustomerDataList()
        {
            return _customerdataservice.GetCustomerDataListAsync();

        }
        [HttpGet]
        [Route("GetCustomerDataByRefId")]
        public Task<CustomerDataResponse> GetCustomerDataByRefId(string CorrelationId)
        {
            return _customerdataservice.GetCustomerDataByRefIdAsync(CorrelationId);

        }

        [HttpGet]
        [Route("GetCustomerDataSearchById")]
        public Task<IEnumerable<CustomerDataResponse>> GetCustomerDataSearchById(string Fromdate, string Todate,string? ConsentId, string? Type, string? CustomerId, string? Customernbr, string? Customername, string? Customerstatus, string? OrganizationId, string? ClientId)
        {
            return _customerdataservice.GetCustomerDataSearchByIdAsync(Fromdate, Todate, ConsentId!, Type!,CustomerId!,Customernbr!,Customername!,Customerstatus!, OrganizationId,ClientId);

        }
    }
}
