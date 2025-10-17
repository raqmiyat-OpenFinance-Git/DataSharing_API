namespace DataSharing_API.IService.LFI;

public interface ILfiProductQuoteMasters
{
    Task<IEnumerable<ProductQuoteMaster>> GetProductQuoteMasters();
}
