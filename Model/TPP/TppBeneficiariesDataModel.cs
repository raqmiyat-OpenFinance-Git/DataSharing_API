namespace DataSharing_API.Model.TPP
{
    public class TppBeneficiariesDataModel
    {

        public List<TppBeneficiariesResponse>? tppbenificiariesDataResponsesList { get; set; }
        public TppBeneficiariesResponse? tppbenificiariesDataResponses { get; set; }

    }
    public class TppBeneficiariesResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public string? BeneficiaryId { get; set; }
        public string? BeneficiaryType { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? Reference { get; set; }
        public string? CreditorAgentSchemeName { get; set; }
        public string? CreditorAgentIdentification { get; set; }
        public string? CreditorAgentName { get; set; }
        public string? PostalAddressType { get; set; }
        public string? PostalAddressLine { get; set; }
        public string? BuildingNumber { get; set; }
        public string? BuildingName { get; set; }
        public string? Floor { get; set; }
        public string? StreetName { get; set; }
        public string? DistrictName { get; set; }
        public string? PostBox { get; set; }
        public string? TownName { get; set; }
        public string? CountrySubDivision { get; set; }
        public string? Country { get; set; }
        public string? CreditorAccountSchemeName { get; set; }
        public string? CreditorAccountIdentification { get; set; }
        public string? LinksSelf { get; set; }
        public string? LinksFirst { get; set; }
        public string? LinksPrev { get; set; }
        public string? LinksNext { get; set; }
        public string? LinksLast { get; set; }
        public string? LFIName { get; set; }
        public string? ConsentId { get; set; }
        public string? LFIId { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
    }
}

