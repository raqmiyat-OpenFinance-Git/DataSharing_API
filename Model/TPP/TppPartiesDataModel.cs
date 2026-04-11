namespace DataSharing_API.Model.TPP
{
    public class TppPartiesDataModel
    {
        public List<TppPartiesResponse>? tpppartiesDataResponsesList { get; set; }
        public TppPartiesResponse? tpppartiesDataResponses { get; set; }
    }
    public class TppPartiesResponse
    {
        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? Authorization { get; set; }
        public string? AuthDate { get; set; }
        public string? ipAddress { get; set; }
        public string? InteractionId { get; set; }
        public string? CustomerUseragent { get; set; }
        public string? AccountId { get; set; }
        public string? PartyId { get; set; }
        public string? PartyNumber { get; set; }
        public string? PartyType { get; set; }
        public string? PartyCategory { get; set; }
        public string? AccountRole { get; set; }

        // Verification
        public string? TrustFramework { get; set; }
        public string? AssuranceLevel { get; set; }

        // Assurance Process
        public string? AssurancePolicy { get; set; }
        public string? AssuranceProcedure { get; set; }

        // AssuranceDetails
        public string? AssuranceType { get; set; }
        public string? AssuranceClassification { get; set; }

        // EvidenceRef
        public string? EvidenceTxn { get; set; }
        public string? EvidenceClassification { get; set; }

        public string? VerificationTime { get; set; }
        public string? VerificationProcess { get; set; }

        // Evidence
        public string? EvidenceType { get; set; }

        // CheckDetails (flattened)
        public string? CheckMethod { get; set; }
        public string? Organization { get; set; }
        public string? Txn { get; set; }
        public DateTime? Time { get; set; }

        // Verifier
        public string? VerifierOrganization { get; set; }
        public string? VerifierTxn { get; set; }

        public DateTime? EvidenceTime { get; set; }

        // Document Details
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? PersonalNumber { get; set; }
        public string? SerialNumber { get; set; }
        public string? CalendarType { get; set; }
        public DateTime? DateOfIssuance { get; set; }
        public DateTime? DateOfExpiry { get; set; }

        // Issuer
        public string? IssuerName { get; set; }
        public string? IssuerJurisdiction { get; set; }

        // Issuer Address
        public string? IssuerAddressType { get; set; }
        public string? IssuerAddressLine { get; set; }
        public string? IssuerBuildingNumber { get; set; }
        public string? IssuerBuildingName { get; set; }
        public string? IssuerFloor { get; set; }
        public string? IssuerStreetName { get; set; }
        public string? IssuerDistrictName { get; set; }
        public string? IssuerPostBox { get; set; }
        public string? IssuerTownName { get; set; }
        public string? IssuerCountrySubDivision { get; set; }
        public string? IssuerCountry { get; set; }
        public string? IssuerCountryCode { get; set; }

        // Attachments
        public string? AEPartyIdentityEvidenceAttachments { get; set; }
        public string? Description { get; set; }
        public string? ContentType { get; set; }
        public string? Content { get; set; }
        public string? TxnAttachment { get; set; } // renamed to avoid duplicate "Txn"

        // Claims
        public string? IdentityType { get; set; }
        public string? FullName { get; set; }
        public string? GivenName { get; set; }
        public string? Surname { get; set; }
        public string? MiddleName { get; set; }
        public string? Nickname { get; set; }

        public string? EmiratesId { get; set; }
        public DateTime? EmiratesIdExpiryDate { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? SourceOfIncome { get; set; }
        public decimal? Salary { get; set; }
        public string? Nationality { get; set; }

        // Residential Address
        public string? ResAddressType { get; set; }
        public string? ResAddressLine { get; set; }
        public string? ResBuildingNumber { get; set; }
        public string? ResBuildingName { get; set; }
        public string? ResFloor { get; set; }
        public string? ResStreetName { get; set; }
        public string? ResDistrictName { get; set; }
        public string? ResPostBox { get; set; }
        public string? ResTownName { get; set; }
        public string? ResCountrySubDivision { get; set; }
        public string? ResCountry { get; set; }

        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Salutation { get; set; }
        public string? Language { get; set; }

        public string? EmployerName { get; set; }
        public DateTime? EmploymentSinceDate { get; set; }

        public bool? PowerofAttorney { get; set; }
        public bool? SalaryTransfer { get; set; }
        public string? Profession { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Links
        public string? LinksSelf { get; set; }
        public string? LinksFirst { get; set; }
        public string? LinksPrev { get; set; }
        public string? LinksNext { get; set; }
        public string? LinksLast { get; set; }
        public int? TotalPages { get; set; }

        // Audit
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? ResponseJson { get; set; }
        public string? LFIName { get; set; }
        public string? ConsentId { get; set; }
        public string? LFIId { get; set; }
    }
}

