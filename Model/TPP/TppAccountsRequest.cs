using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataSharing_API.Model.TPP
{
    [Table("Tpp_Accounts_Request")]
    public class TppAccountsRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? RequestJson { get; set; }
    }
}