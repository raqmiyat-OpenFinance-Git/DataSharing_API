//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//namespace DataSharing_API.Models
//{


//    [Table("Tpp_Balances_Response")]
//    public class TppBalancesResponse
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public long BalanceResponseId { get; set; }   // PK
//        public long BalanceRequestId { get; set; }    // FK 
//        public Guid CorrelationId { get; set; }  

//        public string? AccountId { get; set; }
//        public string? AccountBalanceCreditDebitIndicator { get; set; }
//        public string? AccountBalanceType { get; set; }
//        public DateTime? AccountBalanceTimestamp { get; set; }
//        public decimal? AccountBalanceAmount { get; set; }
//        public string? AccountBalanceCurrency { get; set; }

//        public bool BalanceCreditLineIncluded { get; set; }  // NOT NULL (bit)

//        public string? BalanceCreditLineCreditType { get; set; }
//        public decimal? BalanceCreditLineAmount { get; set; }
//        public string? BalanceCreditLineCurrency { get; set; }

//        public decimal? TotalPages { get; set; }
//        public decimal? TotalRecords { get; set; }

//        public string? Status { get; set; }   // CHECK constraint: PENDING, FAILED, PROCESSED

//        public string? CreatedBy { get; set; }
//        public DateTime? CreatedOn { get; set; }
//        public string? ModifiedBy { get; set; }
//        public DateTime? ModifiedOn { get; set; }

//        public string? ResponseJson { get; set; }

//        // Navigation property to Request (FK)
//        public TppBalancesRequest? TppBalancesRequest { get; set; }
//    }
//}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSharing_API.Models
{
    [Table("Tpp_Balances_Response")]
    public class TppBalancesResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BalanceResponseId { get; set; }   // PK

        public long BalanceRequestId { get; set; }    // FK 
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

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string? ResponseJson { get; set; }

        //// Explicitly tell EF Core the foreign key
        //[ForeignKey(nameof(BalanceRequestId))]
        //public TppBalancesRequest? TppBalancesRequest { get; set; }
    }
}
