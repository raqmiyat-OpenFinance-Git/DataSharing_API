using OpenTelemetry.Trace;
using System.Net.NetworkInformation;

namespace DataSharing_API.IService.LFI;

public interface ILfiCreditCardService
{
    /// <summary>
    /// Retrieves all product data records linked to a specific product quote.
    /// </summary>
    Task<IEnumerable<LfiCreditCard>> GetProductDataListAsync(int productQuoteId);

    /// <summary>
    /// Searches for current account records based on filter criteria.
    /// </summary>
    Task<IEnumerable<LfiCreditCard>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
    string? type = null,
    string? documentationType = null,
    decimal? chargeRate = null,
    decimal? fixedRate = null,
    string? chargeName = null,
    decimal? chargeAmount = null,
    decimal? limitsAmount = null,
    string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<LfiCreditCard?> GetProductDataByRefIdAsync(long requestId);
}