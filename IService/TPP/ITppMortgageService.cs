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
    string? type = null,
    string? description = null,
    decimal? minimumLoanAmount = null,
    decimal? maximumLoanAmount = null,
    decimal? minTenure = null,
    decimal? maxTenure = null,
    decimal? indicativeRateFrom = null,
    decimal? indicativeRateTo = null,
    string? rateType = null,
    string? documentationType = null,
    string? feesName = null,
    string? benefitsName = null,
    string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<TppMortgage?> GetProductDataByRefIdAsync(long requestId);
}

