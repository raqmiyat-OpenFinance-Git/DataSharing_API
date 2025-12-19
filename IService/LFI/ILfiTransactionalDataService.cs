namespace DataSharing_API.IService.LFI;

public interface ILfiTransactionalDataService
{
    Task<IEnumerable<LfiTransactionalData>> GetTransactionalDataListAsync(string paymentCategory);

    Task<LfiTransactionalData> GetTransactionalDataByRefIdAsync(long requestId);

    Task<IEnumerable<LfiTransactionalData>> GetTransactionalDataSearchByIdAsync(string? fromdate, string? toDate,
        string? consentId, string? accountId, string? currentStatus, string? paymentCategory, string? OrganizationId, string? ClientId,string? PaymentTransactionId);
}
