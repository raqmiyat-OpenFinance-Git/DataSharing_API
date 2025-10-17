using OpenTelemetry.Trace;
using System.Net.NetworkInformation;

namespace DataSharing_API.IService.LFI;

public interface ILfiPersonalLoanService
{
    /// <summary>
    /// Retrieves all product data records linked to a specific product quote.
    /// </summary>
    Task<IEnumerable<LfiPersonalLoan>> GetProductDataListAsync(int productQuoteId);

    /// <summary>
    /// Searches for current account records based on filter criteria.
    /// </summary>
    Task<IEnumerable<LfiPersonalLoan>> GetProductDataSearchAsync(
         string? fromDate = null,
        string? toDate = null,
        string? type = null,
        string? description = null,
        decimal? minimumLoanAmount = null,
        string? minimumLoanCurrency = null,
        decimal? minTenure = null,
        decimal? indicativeRateFrom = null,
        string? rateType = null,
        string? documentationType = null,
        string? feesName = null,
        string? benefitsName = null,
        string? status = null);

    /// <summary>
    /// Retrieves detailed product data by the RequestId (unique reference).
    /// </summary>
    Task<LfiPersonalLoan?> GetProductDataByRefIdAsync(long requestId);
}


