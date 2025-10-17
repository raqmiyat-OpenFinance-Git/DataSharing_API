namespace DataSharing_API.IService.LFI;

public interface IBankProductDataService
{
    Task<IEnumerable<LfiCoPQueryData>> GetProductCategoryAsync();
   
}
