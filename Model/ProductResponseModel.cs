namespace DataSharing_API.Model
{
    public class ProductResponseModel
    {
        public List<ProductResponse>? productDataResponsesList { get; set; }

        public ProductResponse? productDataResponses { get; set; }

    }
    public class ProductResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? ChargeName { get; set; }
        public string? ChargeDescription { get; set; }
        public string? ChargeAmount { get; set; }
        public string? ChargeNotes   { get; set; }
        public string? LendingType { get; set; }
        public string? LendingStartDate { get; set; }
        public string? LendingEndDate { get; set; }
        public string? LendingNotes { get; set; }
        public string? DepositType { get; set; }
        public string? DepositStartDate { get; set; }
        public string? DepositEndDate { get; set; }
        public string? DepositNotes { get; set; }
        public string? CollateralType { get; set; }
        public string? CollateralDescription { get; set; }
        public string? CollateralValuationDate { get; set; }
        public string? CollateralValuationAmount { get; set; }
        public string? RewardName { get; set; }
        public string? RewardDescription { get; set; }
        public string? RewardAmount { get; set; }
        public string? RewardNotes { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    }

