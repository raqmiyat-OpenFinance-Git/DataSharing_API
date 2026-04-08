using OpenTelemetry.Trace;

namespace DataSharing_API.IService.TPP;

public interface ITppSavingsAccountService
{
    /// <summary>
    /// Retrieves all product data records linked to a specific product quote.
    /// </summary>
    Task<IEnumerable<TppSavingsAccount>> GetProductDataListAsync(int productQuoteId);

    /// <summary>
    /// Searches for current account records based on filter criteria.
    /// </summary>
    Task<IEnumerable<TppSavingsAccount>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
    string? type = null,
    decimal? minimumBalance = null,
    string? documentationType = null,
    string? rateType = null,
    decimal? annualRate = null,
    string? chargeName = null,
    decimal? chargeAmount = null,
    decimal? limitsAmount = null,
    string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<TppSavingsAccount?> GetProductDataByRefIdAsync(long requestId);
}