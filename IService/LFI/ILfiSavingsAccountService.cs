using OpenTelemetry.Trace;

namespace DataSharing_API.IService.LFI;

public interface ILfiSavingsAccountService
{
    /// <summary>
    /// Retrieves all product data records linked to a specific product quote.
    /// </summary>
    Task<IEnumerable<LfiSavingsAccount>> GetProductDataListAsync(int productQuoteId);

    /// <summary>
    /// Searches for current account records based on filter criteria.
    /// </summary>
    Task<IEnumerable<LfiSavingsAccount>> GetProductDataSearchAsync(
         string? fromDate = null,
        string? toDate = null,
        string? type = null,
        string? description = null,
        decimal? minimumBalance = null,
        decimal? annualReturn = null,
        string? documentationType = null,
        string? feesName = null,
        string? currency = null, 
        string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<LfiSavingsAccount?> GetProductDataByRefIdAsync(long requestId);
}