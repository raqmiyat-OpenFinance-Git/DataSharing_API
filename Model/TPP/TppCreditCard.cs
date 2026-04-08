namespace DataSharing_API.Model.TPP;

public class TppCreditCard
{

    //TppProductDataRequest
    public long RequestId { get; set; }
    public Guid CorrelationId { get; set; }
    public string? Authorization { get; set; }
    public string CustomerIpAddress { get; set; }
    public string ProductCategory { get; set; }
    public bool? IsShariaCompliant { get; set; }
    public string LastUpdatedDateTime { get; set; }
    public string SortOrder { get; set; }
    public string SortField { get; set; }
    public string Status { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string RequestJson { get; set; }


    //TppProductDataResponse

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

    //Credit Card
    public Guid CreditCardId { get; set; }
    public long CreditCardRequestId { get; set; }
    public string Type { get; set; }
    public string CreditCardDescription { get; set; }

    public decimal? FixedRate { get; set; }

    // Documentation
    public string DocumentationType { get; set; }
    public string DocumentationDescription { get; set; }

    // Features
    public string FeaturesType { get; set; }
    public string FeaturesDescription { get; set; }

    // Charges
    public string? ChargeType { get; set; }
    public string? ChargeDescription { get; set; }
    public string? ChargeName { get; set; }
    public decimal? ChargeAmount { get; set; }
    public string? ChargeCurrency { get; set; }
    public decimal? ChargeRate { get; set; }
    public string? ChargeApplicationFrequency { get; set; }
    public string? ChargeInterestCalculationMethod { get; set; }
    public decimal? MaximumChargeAmount { get; set; }
    public string? MaximumChargeCurrency { get; set; }
    public string? ChargeBasis { get; set; }

    // Conditions

    public string? ConditionsField { get; set; }
    public string? ConditionsOperator { get; set; }
    public string? ConditionsValue { get; set; }
    public string? ConditionsDescription { get; set; }

    public string? Justification { get; set; }
    public string? Frequency { get; set; }

    public bool? DonatedToCharity { get; set; }

    public string? Notes { get; set; }
    public string? SupplementaryInformation { get; set; }

    // Limits
    public string LimitsType { get; set; }
    public string LimitsDescription { get; set; }
    public decimal? LimitsAmount { get; set; }
    public string? LimitsCurrency { get; set; }
    public decimal? LimitsValue { get; set; }
}
