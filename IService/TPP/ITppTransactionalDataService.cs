namespace DataSharing_API.IService.LFI;

public interface ITppTransactionalDataService
{
    Task<IEnumerable<TppTransactionalData>> GetTppTransactionalDataListAsync(string paymentCategory);

    Task<TppTransactionalData> GetTppTransactionalDataByRefIdAsync(long requestId);

    Task<IEnumerable<TppTransactionalData>> GetTppTransactionalDataSearchByIdAsync(string? fromdate, string? toDate,
        string? consentId, string? accountId, string? currentStatus, string? paymentCategory, string? OrganizationId, string? ClientId,string? PaymentTransactionId);
}
