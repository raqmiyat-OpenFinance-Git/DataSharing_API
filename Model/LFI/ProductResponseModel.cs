namespace DataSharing_API.Model.LFI
{
    public class ProductResponseModel
    {
        public List<ProductResponse>? productDataResponsesList { get; set; }

        public ProductResponse? productDataResponses { get; set; }

    }
    public class ProductResponse
    {
        public long RequestId { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? ShariaStructure { get; set; }

        // == Charges == //
        public string? Charges_Type { get; set; }
        public string? Charges_Name { get; set; }
        public string? Charges_Description { get; set; }
        public string? Charges_Justification { get; set; }
        public string? Charges_Frequency { get; set; }
        public bool? Charges_DonatedToCharity { get; set; }
        public string? Charges_Notes { get; set; }
        public string? Charges_SupplementaryInformation { get; set; }
        public decimal Charge_Amount { get; set; }
        public string? Charge_Currency { get; set; }
        public decimal Charge_Rate { get; set; }
        public string? Charge_ApplicationFrequency { get; set; }
        public string? Charge_InterestCalculationMethod { get; set; }
        public decimal Charge_MaxAmount { get; set; }
        public string? Charge_MaxCurrency { get; set; }
        public string? Charge_Basis { get; set; }
        public string? Condition_Field { get; set; }
        public string? Condition_Operator { get; set; }
        public string? Condition_Value { get; set; }
        public string? Condition_Description { get; set; }

        // === Finance Rate ==== //

        public string? FinanceRates_RateType { get; set; }
        public decimal FinanceRates_Rate { get; set; }
        public string? FinanceRates_Description { get; set; }
        public string? FinanceRates_FixedRateEndDate { get; set; }
        public string? FinanceRates_CalculationFrequency { get; set; }
        public string? FinanceRates_CalculationMethod { get; set; }
        public string? FinanceRates_ApplicationFrequency { get; set; }
        public string? FinanceRates_InterestCalculationMethod { get; set; }
        public string? FinanceRates_AnnualPercentageRate_StartingFrom { get; set; }
        public string? FinanceRates_AnnualPercentageRate_UpTo { get; set; }
        public string? FinanceRates_Tier_Name { get; set; }
        public string? FinanceRates_Tier_Unit { get; set; }
        public string? FinanceRates_Tier_ApplicationMethod { get; set; }
        public decimal FinanceRates_BalanceTier_MinimumAmount { get; set; }
        public string? FinanceRates_BalanceTier_MinimumAmountCurrency { get; set; }
        public decimal FinanceRates_BalanceTier_MaximumAmount { get; set; }
        public string? FinanceRates_BalanceTier_MaximumAmountCurrency { get; set; }
        public decimal FinanceRates_BalanceTier_Rate { get; set; }
        public string? FinanceRates_LTVTier_Start { get; set; }
        public string? FinanceRates_LTVTier_End { get; set; }
        public decimal FinanceRates_LTVTier_Rate { get; set; }
        public decimal FinanceRates_RateRange_MinimumRate { get; set; }
        public decimal FinanceRates_LTVTier_MaximumRate { get; set; }
        public string? FinanceRates_LTVTier_AdditionalInformation { get; set; }
        public string? FinanceRates_Conditions_Field { get; set; }
        public string? FinanceRates_Conditions_Operator { get; set; }
        public string? FinanceRates_Conditions_Value { get; set; }
        public string? FinanceRates_Conditions_Description { get; set; }

        // == Deposit Rate === //

        public string? DepositRates_RateType { get; set; }
        public string? DepositRates_RateCategory { get; set; }
        public decimal DepositRates_AnnualRate { get; set; }
        public decimal DepositRates_AnnualRate_MinRate { get; set; }
        public decimal DepositRates_AnnualRate_MaxRate { get; set; }
        public string? DepositRates_CalculationFrequency { get; set; }
        public string? DepositRates_CalculationMethod { get; set; }
        public string? DepositRates_ApplicationFrequency { get; set; }
        public string? DepositRates_Tier_MinBalance { get; set; }
        public string? DepositRates_Tier_MaxBalance { get; set; }
        public string? DepositRates_Tier_Currency { get; set; }
        public string? DepositRates_Term { get; set; }
        public DateTime? DepositRates_EffectiveDate { get; set; }
        public DateTime? DepositRates_ExpiryDate { get; set; }

        public bool? IsSecured { get; set; }
        public bool? IsSalaryTransferRequired { get; set; }

        // == TENOR == //
        public string? OriginalTenor { get; set; }
        public string? RemainingTenor { get; set; }

        // == Asset Backed == //

        public string? Asset_Type { get; set; }
        public string? Asset_AssetType { get; set; }
        public string? Asset_Description { get; set; }
        public string? Asset_SupplementaryInformation { get; set; }
        public DateTime? Valuation_Date { get; set; }
        public decimal Valuation_Amount { get; set; }
        public string? Valuation_Currency { get; set; }
        public DateTime? TransferOfOwnershipDate { get; set; }
        public string? Ownership_Type { get; set; }
        public string? Ownership_Method { get; set; }
        public decimal Token_Amount { get; set; }
        public string? Token_Currency { get; set; }
        public string? Buyout_Frequency { get; set; }
        public decimal Buyout_Amount { get; set; }
        public string? Buyout_Currency { get; set; }
        public bool? Sale_Required { get; set; }
        public string? Sale_Execution { get; set; }
        public string? Sale_Price { get; set; }
        public string? Sale_Currency { get; set; }
        public string? Transfer_Condition { get; set; }

        // REWARDS 
        public string? Reward_Name { get; set; }
        public string? Reward_Description { get; set; }
        public string? Reward_Type { get; set; }
        public decimal Reward_Amount { get; set; }
        public string? Reward_Currency { get; set; }
        public string? Reward_Basis { get; set; }
        public string? Reward_FrequencyPaid { get; set; }

        // META
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

