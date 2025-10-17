namespace DataSharing_API.Model.LFI
{
    public class BeneficiariesModel
    {
        public List<BeneficiariesResponse>? benificiariesDataResponsesList { get; set; }

        public BeneficiariesResponse? benificiariesDataResponses { get; set; }

    }
    public class BeneficiariesResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? BeneficiaryId { get; set; }
        public string? BeneficiaryType { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? Reference { get; set; }
        public string? ServicerSchemeName { get; set; }
        public string? ServicerIdentification { get; set; }
        public string? ServicerName { get; set; }
        public string? AddressType { get; set; }
        public string? AddressLine { get; set; }
        public string? BuildingNumber { get; set; }
        public string? BuildingName { get; set; }
        public string? Floor { get; set; }
        public string? StreetName { get; set; }
        public string? DistrictName { get; set; }
        public string? PostBox { get; set; }
        public string? TownName { get; set; }
        public string? CountrySubDivision { get; set; }
        public string? Country { get; set; }
        public string? CreditorSchemeName { get; set; }
        public string? CreditorIdentification { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}

