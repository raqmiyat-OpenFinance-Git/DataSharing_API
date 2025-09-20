namespace DataSharing_API.Models;

public class TppBalancesDetailDto
{
    // ------------------------
    // TppBalancesRequest fields
    // ------------------------
    public long BalanceRequestId { get; set; }   // Primary Key

    public Guid CorrelationId { get; set; }   // Unique Key

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

    public string? AccountId { get; set; }
    public string? RequestStatus { get; set; }

    public string? RequestCreatedBy { get; set; }
    public DateTime? RequestCreatedOn { get; set; }
    public string? RequestModifiedBy { get; set; }
    public DateTime? RequestModifiedOn { get; set; }

    public string? RequestJson { get; set; }



    // ------------------------
    // TppBalancesResponse fields
    // ------------------------
    public long BalanceResponseId { get; set; }   // Primary Key
    public string? AccountBalanceCreditDebitIndicator { get; set; }
    public string? AccountBalanceType { get; set; }
    public DateTime? AccountBalanceTimestamp { get; set; }
    public decimal? AccountBalanceAmount { get; set; }
    public string? AccountBalanceCurrency { get; set; }

    public bool BalanceCreditLineIncluded { get; set; }  // NOT NULL (bit)

    public string? BalanceCreditLineCreditType { get; set; }
    public decimal? BalanceCreditLineAmount { get; set; }
    public string? BalanceCreditLineCurrency { get; set; }

    public decimal? TotalPages { get; set; }
    public decimal? TotalRecords { get; set; }

    public string? ResponseStatus { get; set; }   // CHECK constraint: PENDING, FAILED, PROCESSED

    public string? ResponseCreatedBy { get; set; }
    public DateTime? ResponseCreatedOn { get; set; }
    public string? ResponseModifiedBy { get; set; }
    public DateTime? ResponseModifiedOn { get; set; }

    public string? ResponseJson { get; set; }

    public string? TPPID { get; set; }
    public string? TPPName { get; set; }
}