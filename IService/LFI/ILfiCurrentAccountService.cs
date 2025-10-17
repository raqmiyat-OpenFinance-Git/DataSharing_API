namespace DataSharing_API.IService.LFI;

public interface ILfiCurrentAccountService
{
    /// <summary>
    /// Retrieves all product data records linked to a specific product quote.
    /// </summary>
    Task<IEnumerable<LfiCurrentAccount>> GetProductDataListAsync(int productQuoteId);

    /// <summary>
    /// Searches for current account records based on filter criteria.
    /// </summary>
    Task<IEnumerable<LfiCurrentAccount>> GetProductDataSearchAsync(
        string? fromDate = null,
        string? toDate = null,
        string? type = null,
        string? description = null,
        bool? isOverdraftAvailable = null,
        string? documentationType = null,
        string? feesName = null,
        string? benefitsName = null,
        string? currency = null, string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<LfiCurrentAccount?> GetProductDataByRefIdAsync(long requestId);
}



