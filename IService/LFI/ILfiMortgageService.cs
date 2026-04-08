using OpenTelemetry.Trace;
using System.Net.NetworkInformation;

namespace DataSharing_API.IService.LFI;

public interface ILfiMortgageService
{
    /// <summary>
    /// Retrieves all product data records linked to a specific product quote.
    /// </summary>
    Task<IEnumerable<LfiMortgage>> GetProductDataListAsync(int productQuoteId);

    /// <summary>
    /// Searches for current account records based on filter criteria.
    /// </summary>
    Task<IEnumerable<LfiMortgage>> GetProductDataSearchAsync(
    string? fromDate = null,
    string? toDate = null,
    decimal? minimumFinanceAmount = null,
    decimal? maximumFinanceAmount = null,
    decimal? chargeRate = null,
    decimal? fixedRate = null,
    string? chargeName = null,
    decimal? chargeAmount = null,
    decimal? limitsAmount = null,
    string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<LfiMortgage?> GetProductDataByRefIdAsync(long requestId);
}

