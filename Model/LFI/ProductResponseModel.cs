namespace DataSharing_API.Model.LFI
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
        public string? ShariaStructure { get; set; }
        public string? FinanceRates { get; set; }
        public bool? IsSecured { get; set; }
        public bool? IsSalaryTransferRequired { get; set; }
        public string? OriginalTenor { get; set; }
        public string? RemainingTenor { get; set; }
        public string? Charges_Type { get; set; }
        public string? Charges_Name { get; set; }
        public string? Charges_Description { get; set; }
        public string? Charges_Justification { get; set; }
        public string? Charges_Frequency { get; set; }
        public bool? Charges_DonatedToCharity { get; set; }
        public string? Charges_Notes { get; set; }
        public string? Charges_SupplementaryInformation { get; set; }

        public string? Charge_Amount { get; set; }
        public string? Charge_Currency { get; set; }
        public decimal? Charge_Rate { get; set; }
        public string? Charge_ApplicationFrequency { get; set; }
        public string? Charge_InterestCalculationMethod { get; set; }
        public string? Charge_MaxAmount { get; set; }
        public string? Charge_MaxCurrency { get; set; }
        public string? Charge_Basis { get; set; }
        public string? Condition_Field { get; set; }
        public string? Condition_Operator { get; set; }
        public string? Condition_Value { get; set; }
        public string? Condition_Description { get; set; }
        public string? RateType { get; set; }
        public string? RateCategory { get; set; }
        public decimal? AnnualRate { get; set; }
        public decimal? MinRate { get; set; }
        public decimal? MaxRate { get; set; }

        public string? Tier_MinBalance { get; set; }
        public string? Tier_MaxBalance { get; set; }
        public string? Tier_Currency { get; set; }

        public string? Term { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public string? CalculationMethod { get; set; }
        public string? CalculationFrequency { get; set; }
        public string? ApplicationFrequency { get; set; }
        public string? Deposit_Notes { get; set; }
        public string? Asset_Type { get; set; }
        public string? Asset_AssetType { get; set; }
        public string? Asset_Description { get; set; }
        public string? Asset_SupplementaryInformation { get; set; }
        public DateTime? Valuation_Date { get; set; }
        public string? Valuation_Amount { get; set; }
        public string? Valuation_Currency { get; set; }

        public DateTime? TransferOfOwnershipDate { get; set; }
        public string? Ownership_Type { get; set; }
        public string? Ownership_Method { get; set; }
        public string? Token_Amount { get; set; }
        public string? Token_Currency { get; set; }
        public string? Buyout_Frequency { get; set; }
        public string? Buyout_Amount { get; set; }
        public string? Buyout_Currency { get; set; }
        public bool? Sale_Required { get; set; }
        public string? Sale_Execution { get; set; }
        public string? Sale_Price { get; set; }
        public string? Sale_Currency { get; set; }
        public string? Transfer_Condition { get; set; }
        public string? Reward_Name { get; set; }
        public string? Reward_Description { get; set; }
        public string? Reward_Type { get; set; }
        public string? Reward_Amount { get; set; }
        public string? Reward_Currency { get; set; }
        public decimal? TotalPages { get; set; }
        public decimal? TotalRecords { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? ConsentId { get; set; }
        public string? TppName { get; set; }
        public string? TppId { get; set; }
        public string? Status { get; set; }
    }
}

