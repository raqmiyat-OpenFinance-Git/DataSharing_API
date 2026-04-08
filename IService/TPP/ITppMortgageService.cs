using DataSharing_API.Model.TPP;
using OpenTelemetry.Trace;
using System.Net.NetworkInformation;

namespace DataSharing_API.IService.TPP;

public interface ITppMortgageService
{
    /// <summary>
    /// Retrieves all product data records linked to a specific product quote.
    /// </summary>
    Task<IEnumerable<TppMortgage>> GetProductDataListAsync(int productQuoteId);

    /// <summary>
    /// Searches for current account records based on filter criteria.
    /// </summary>
    Task<IEnumerable<TppMortgage>> GetProductDataSearchAsync(
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
    Task<TppMortgage?> GetProductDataByRefIdAsync(long requestId);
}

