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
        string? description = null,
        decimal? Rate = null,
        string? documentationType = null,
        string? feesName = null,
        string? benefitsName = null,
        string? limitsType = null,
        string? currency = null, 
        string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<LfiCreditCard?> GetProductDataByRefIdAsync(long requestId);
}