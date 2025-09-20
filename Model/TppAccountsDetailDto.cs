namespace DataSharing_API.Models;

public class TppAccountsDetailDto
{
    // ------------------------
    // TppAccountssRequest fields
    // ------------------------
    public long AccountsRequestId { get; set; }
    public Guid CorrelationId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? O3ProviderId { get; set; }
    public string? O3AspspId { get; set; }
    public string? O3CallerOrgId { get; set; }
    public string? O3CallerClientId { get; set; }
    public string? O3CallerSoftwareStatementId { get; set; }
    public string? O3ApiUri { get; set; }
    public string? O3ApiOperation { get; set; }
    public string? O3ConsentId { get; set; }
    public string? O3CallerInteractionId { get; set; }
    public string? O3OzoneInteractionId { get; set; }
    public string? O3PsuIdentifier { get; set; }
    public bool? O3IsCaapConsentOperation { get; set; }
    public string? O3CaapConsentUseCase { get; set; }
    public string? AccountId { get; set; }
    public string? Type { get; set; }
    public string? RequestStatus { get; set; }
    public string? RequestCreatedBy { get; set; }
    public DateTime? RequestCreatedOn { get; set; }
    public string? RequestModifiedBy { get; set; }
    public DateTime? RequestModifiedOn { get; set; }
    public string? RequestJson { get; set; }



    // ------------------------
    // TpAccountsResponse fields
    // ------------------------
    public long AccountsResponseId { get; set; }
    
    public string? AccountType { get; set; }
    public string? AccountSubType { get; set; }
    public string? Currency { get; set; }
    public string? AccountStatus { get; set; }
    public string? AccountHolderName { get; set; }
    public string? ServicerSchemeName { get; set; }
    public string? ServicerIdentification { get; set; }
    public string? AccountNumberName { get; set; }
    public string? AccountNumberSchemeName { get; set; }
    public string? AccountNumberIdentification { get; set; }
    public string? ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? BundleName { get; set; }
    public bool MultiAuth { get; set; }
    public string? BusinessCustomerId { get; set; }
    public string? BusinessCustomerName { get; set; }
    public string? CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? AccountHolderShortName { get; set; }
    public string? StatusUpdateDateTime { get; set; }
    public string? Description { get; set; }
    public string? NickName { get; set; }
    public string? OpeningDate { get; set; }
    public string? MaturityDate { get; set; }
    public bool? IsShariahCompliant { get; set; }
    public decimal? TotalPages { get; set; }
    public decimal? TotalRecords { get; set; }

    public string? ResponseType { get; set; }
    public string? ResponseStatus { get; set; }
    public string? ResponseCreatedBy { get; set; }
    public DateTime? ResponseCreatedOn { get; set; }
    public string? ResponseModifiedBy { get; set; }
    public DateTime? ResponseModifiedOn { get; set; }
    public string? ResponseJson { get; set; }

    public string? TPPID { get; set; }
    public string? TPPName { get; set; }
}