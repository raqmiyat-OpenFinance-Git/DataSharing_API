using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSharing_API.Model.LFI;

[Table("Tpp_Balances_Response")]
public class CentralBankBalanceResponseEF
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long BalanceId { get; set; }
    public Guid CorrelationId { get; set; }
    public string? AccountId { get; set; }
    public string? AccountBalanceCreditDebitIndicator { get; set; }
    public string? AccountBalanceType { get; set; }
    public DateTime? AccountBalanceTimestamp { get; set; }
    public decimal? AccountBalanceAmount { get; set; }
    public string? AccountBalanceCurrency { get; set; }
    public bool BalanceCreditLineIncluded { get; set; }
    public string? BalanceCreditLineCreditType { get; set; }
    public decimal? BalanceCreditLineAmount { get; set; }
    public string? BalanceCreditLineCurrency { get; set; }
    public decimal? TotalPages { get; set; }
    public decimal? TotalRecords { get; set; }
    public string? Status { get; set; }
    // public string? RequestType { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string? ResponseJson { get; set; }
}
