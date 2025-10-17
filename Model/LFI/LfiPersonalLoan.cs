namespace DataSharing_API.Model.LFI;
public class LfiPersonalLoan
{

    //LfiProductDataRequest
    public long RequestId { get; set; }
    public Guid CorrelationId { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string O3ProviderId { get; set; }
    public string O3AspspId { get; set; }
    public string O3CallerOrgId { get; set; }
    public string O3CallerClientId { get; set; }
    public string O3CallerSoftwareStatementId { get; set; }
    public string O3ApiUri { get; set; }
    public string O3ApiOperation { get; set; }
    public string O3CallerInteractionId { get; set; }
    public string O3OzoneInteractionId { get; set; }
    public string ProductCategory { get; set; }
    public bool? IsShariaCompliant { get; set; }
    public string LastUpdatedDateTime { get; set; }
    public string SortOrder { get; set; }
    public string SortField { get; set; }
    public string CustomerIpAddress { get; set; }
    public string Status { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string RequestJson { get; set; }


    //LfiProductDataResponse

    public long Id { get; set; }
    public long ResponseRequestId { get; set; }
    public string LFIId { get; set; }
    public string LFIBrandId { get; set; }
    public DateTime? ResponseLastUpdatedDateTime { get; set; }
    public bool? ResponseIsShariaCompliant { get; set; }
    public string ShariaInformation { get; set; }
    public bool? IsSalaryTransferRequired { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string ResponseProductCategory { get; set; }
    public string Description { get; set; }
    public DateTime? EffectiveFromDateTime { get; set; }
    public DateTime? EffectiveToDateTime { get; set; }
    public string ApplicationUri { get; set; }
    public string ApplicationPhoneNumber { get; set; }
    public string ApplicationEmail { get; set; }
    public string ApplicationDescription { get; set; }
    public string KfsUri { get; set; }
    public string OverviewUri { get; set; }
    public string TermsUri { get; set; }
    public string FeesAndPricingUri { get; set; }
    public string ScheduleOfChargesUri { get; set; }
    public string EligibilityUri { get; set; }
    public string CardImageUri { get; set; }
    public string ChannelsType { get; set; }
    public string ChannelsDescription { get; set; }
    public string ResidenceStatusType { get; set; }
    public string ResidenceStatusDescription { get; set; }
    public string EmploymentStatusType { get; set; }
    public string EmploymentStatusDescription { get; set; }
    public string CustomerTypeType { get; set; }
    public string CustomerTypeDescription { get; set; }
    public string AccountOwnershipType { get; set; }
    public string AccountOwnershipDescription { get; set; }
    public string AgeEligibilityType { get; set; }
    public string AgeEligibilityDescription { get; set; }
    public decimal? AgeEligibilityValue { get; set; }
    public string AdditionalEligibilityType { get; set; }
    public string AdditionalEligibilityDescription { get; set; }
    public string ResponseStatus { get; set; }
    public string ResponseCreatedBy { get; set; }
    public DateTime? ResponseCreatedOn { get; set; }
    public string ResponseModifiedBy { get; set; }
    public DateTime? ResponseModifiedOn { get; set; }
    public string ResponsePayload { get; set; }

    //Personal Loan

    public Guid PersonalLoanId { get; set; }
    public long PersonalLoanRequestId { get; set; }
    public string Type { get; set; }
    public string PersonalLoanDescription { get; set; }

    // Loan Amounts
    public decimal? MinimumLoanAmount { get; set; }
    public string MinimumLoanCurrency { get; set; }
    public decimal? MaximumLoanAmount { get; set; }
    public string MaximumLoanCurrency { get; set; }

    // Tenure
    public decimal? MinTenure { get; set; }
    public decimal? MaxTenure { get; set; }

    // Rate & Calculation
    public string CalculationMethod { get; set; }
    public string RateType { get; set; }
    public string RateDescription { get; set; }
    public string ReviewFrequency { get; set; }
    public decimal? IndicativeRateFrom { get; set; }
    public decimal? IndicativeRateTo { get; set; }
    public decimal? ProfitRateFrom { get; set; }
    public decimal? ProfitRateTo { get; set; }
    public string FixedRatePeriod { get; set; }
    public string DebtBurdenRatio { get; set; }
    public decimal? AnnualPercentageRateFrom { get; set; }
    public decimal? AnnualPercentageRateTo { get; set; }

    // Documentation
    public string DocumentationType { get; set; }
    public string DocumentationDescription { get; set; }

    // Features
    public string FeaturesType { get; set; }
    public string FeaturesDescription { get; set; }

    // Fees
    public string FeesType { get; set; }
    public string FeesPeriod { get; set; }
    public string FeesName { get; set; }
    public string FeesDescription { get; set; }
    public string FeesUnit { get; set; }
    public decimal? FeesAmount { get; set; }
    public string FeesCurrency { get; set; }
    public decimal? FeesPercentage { get; set; }
    public decimal? FeesUnitValue { get; set; }
    public decimal? FeesMaximumUnitValue { get; set; }

    // Limits
    public string LimitsType { get; set; }
    public string LimitsDescription { get; set; }
    public decimal? LimitsValue { get; set; }

    // Benefits
    public string BenefitsType { get; set; }
    public string BenefitsName { get; set; }
    public string BenefitsDescription { get; set; }
    public decimal? BenefitsValue { get; set; }

    // Additional Information
    public string AdditionalInfoType { get; set; }
    public string AdditionalInfoDescription { get; set; }
}
