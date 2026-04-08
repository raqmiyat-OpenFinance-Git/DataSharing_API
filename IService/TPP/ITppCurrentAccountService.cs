namespace DataSharing_API.IService.TPP;

public interface ITppCurrentAccountService
{
    /// <summary>
    /// Retrieves all product data records linked to a specific product quote.
    /// </summary>
    Task<IEnumerable<TppCurrentAccount>> GetProductDataListAsync(int productQuoteId);

    /// <summary>
    /// Searches for current account records based on filter criteria.
    /// </summary>
    Task<IEnumerable<TppCurrentAccount>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
    string? type = null,
    bool? isOverdraftAvailable = null,
    string? documentationType = null,
    decimal? rateType = null,
    decimal? chargeAmount = null,
    decimal? limitsAmount = null,
    string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<TppCurrentAccount?> GetProductDataByRefIdAsync(long requestId);
}



