namespace DataSharing_API.IService.TPP;

public interface ITppProductQuoteMasters
{
    Task<IEnumerable<ProductQuoteMaster>> GetProductQuoteMasters();
}
