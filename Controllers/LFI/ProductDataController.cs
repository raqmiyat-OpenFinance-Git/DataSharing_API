using DataSharing_API.IService.LFI;

namespace DataSharing_API.Controllers.LFI;

[ApiController]
[Route("api/[controller]")]
public class ProductDataController : ControllerBase
{
    private readonly IProductDataService _productdataservice;

    public ProductDataController(IProductDataService productdataservice)
    {
        _productdataservice = productdataservice;
    }
    [HttpGet]
    [Route("GetProductDataList")]
    public Task<IEnumerable<ProductResponse>> GetProductDataList()
    {
        return _productdataservice.GetProductDataListAsync();

    }
    [HttpGet]
    [Route("GetProductDataByRefId")]
    public Task<ProductResponse> GetProductDataByRefId(string CorrelationId)
    {
        return _productdataservice.GetProductDataByRefIdAsync(CorrelationId);

    }

    [HttpGet]
    [Route("GetProductDataSearchById")]
    public Task<IEnumerable<ProductResponse>> GetProductDataSearchById(string Fromdate, string Todate, string? ConsentId, string? AccountId, string? Type)
    {
        return _productdataservice.GetProductDataSearchByIdAsync(Fromdate, Todate, ConsentId!, AccountId!, Type!);

    }
}
