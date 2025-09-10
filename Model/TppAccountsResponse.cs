
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSharing_API.Models
{
   
    [Table("Tpp_Accounts_Response")]
    public class TppAccountsResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AccountsResponseId { get; set; }
        public long AccountsRequestId { get; set; }
        public Guid CorrelationId { get; set; }

        public string? AccountId { get; set; }
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
        public bool? MultiAuth { get; set; }
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

        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ResponseJson { get; set; }
    }
}
