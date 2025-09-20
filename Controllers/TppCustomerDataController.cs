using DataSharing_API.IService;
using DataSharing_API.Model;
using DataSharing_API.Models;
using Microsoft.AspNetCore.Mvc;
using OF.DataSharing.Model.CentralBank;
using OF.DataSharing.Model.EFModel;
using OpenFinance.Models;

namespace DataSharing_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TppCustomerDataController : ControllerBase
    {
        private readonly ITppCustomerDataService _customerdataservice;

        public TppCustomerDataController(ITppCustomerDataService customerdataservice)
        {
            this._customerdataservice = customerdataservice;
        }

        [HttpGet]
        [Route("GetTppCustomerList")]
        public Task<List<CustomerDataRequest>> GetTppCustomerList(string User)
        {
            return _customerdataservice.GetTppCustomerList(User);
        }

        [HttpGet]
        [Route("GetCustomerDataByCorrelationId")]
        public Task<CustomerDataRequest> GetCustomerDataByCorrelationId(Guid CorrelationId)
        {
            return _customerdataservice.GetTppCustomerDetails(CorrelationId);
        }

        [HttpGet]
        [Route("GetAllTppCustomerAsync")]
        public Task<List<TppCustomerDetailDto>> GetAllTppCustomerAsync()
        {
            return _customerdataservice.GetAllTppCustomerAsync();

        }
        [HttpPost]
        [Route("GetTppCustomerByDateAsync")]
        public Task<List<TppCustomerDetailDto>> GetTppCustomerByDateAsync([FromBody] TppCustomerViewDetails tppCustomerViewModel)
        {
            return _customerdataservice.GetTppCustomerByDateAsync(tppCustomerViewModel);
        }

        [HttpGet]
        [Route("GetTppCustomerByIdAsync")]
        public Task<TppCustomerDetailDto> GetTppCustomerByIdAsync(Guid CorrelationId)
        {
            return _customerdataservice.GetTppCustomerByIdAsync(CorrelationId);
        }

        [HttpPost]
        [Route("PostCustomerData")]
        public Task<string> PostCustomerData(CustomerDataRequest customerDataRequest)
        {
            return _customerdataservice.PostCustomerData(customerDataRequest);
        }

        [HttpPost]
        [Route("Approve")]
        public Task<string> Approve(CentralBankCustomerIdResponse customerDataResponse,[FromQuery] Guid CorrelationId)
        {
            return _customerdataservice.ApproveCustomerData(customerDataResponse,CorrelationId);
        }

        [HttpGet]
        [Route("FetchDetailsReponse")]
        public Task<CustomerResponse> FetchDetailsReponse(Guid CorrelationId)
        {
            return _customerdataservice.FetchDetailsReponse(CorrelationId);
        }

        [HttpGet]
        [Route("FetchCutomerDetailsResponse")]
        public Task<List<CustomerResponse>> FetchCutomerDetailsResponse(Guid CorrelationId)
        {
            return _customerdataservice.FetchCutomerDetailsResponse(CorrelationId);
        }
    }
}

