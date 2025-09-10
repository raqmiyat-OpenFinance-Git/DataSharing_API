namespace DataSharing_API.Model
{
    public class CustomerDataResponseModel
    {
        public List<CustomerDataResponse>? customerDataResponsesList { get; set; }

        public CustomerDataResponse? customerDataResponses { get; set; }
    }
    public class CustomerDataResponse
    {

        public long Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string? AccountId { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerCategory { get; set; }

        public string? VerifiedClaimTrustFramework { get; set; }
        public string? VerifiedClaimAssuranceLevel { get; set; }
        public string? VerifiedClaimVerificationProcess { get; set; }
        public string? VerifiedClaimVerificationTime { get; set; }

        public string? AssuranceProcessPolicy { get; set; }
        public string? AssuranceProcessProcedure { get; set; }
        public string? AssuranceType { get; set; }
        public string? AssuranceClassification { get; set; }

        public string? EvidenceRefTxn { get; set; }
        public string? EvidenceClassification { get; set; }
        public string? EvidenceType { get; set; }
        public string? EvidenceTime { get; set; }

        public string? CheckDetailCheckMethod { get; set; }
        public string? CheckDetailOrganization { get; set; }
        public string? CheckDetailTxn { get; set; }
        public string? CheckDetailTime { get; set; }

        public string? VerifierOrganization { get; set; }
        public string? VerifierTxn { get; set; }

        public string? DocumentDetailType { get; set; }
        public string? DocumentDetailDocumentNumber { get; set; }
        public string? DocumentDetailPersonalNumber { get; set; }
        public string? DocumentDetailSerialNumber { get; set; }
        public string? DocumentDetailCalendarType { get; set; }
        public string? DocumentDetailDateOfIssuance { get; set; }
        public string? DocumentDetailDateOfExpiry { get; set; }

        public string? IssuerName { get; set; }
        public string? IssuerJurisdiction { get; set; }
        public string? IssuerCountryCode { get; set; }

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

        public string? AttachmentDescription { get; set; }
        public string? AttachmentContentType { get; set; }
        public string? AttachmentContent { get; set; }
        public string? AttachmentTxn { get; set; }

        public string? ClaimIdentityType { get; set; }
        public string? ClaimFullName { get; set; }
        public string? ClaimGivenName { get; set; }
        public string? ClaimFamilyName { get; set; }
        public string? ClaimMiddleName { get; set; }
        public string? ClaimNickname { get; set; }
        public string? ClaimEmiratesId { get; set; }
        public DateTime? ClaimEmiratesIdExpiryDate { get; set; }
        public string? ClaimBirthDate { get; set; }
        public string? ClaimSourceOfIncome { get; set; }
        public decimal? ClaimSalary { get; set; }
        public string? ClaimNationality { get; set; }
        public string? ClaimMobileNumber { get; set; }
        public string? ClaimEmail { get; set; }
        public string? ClaimMaritalStatus { get; set; }
        public string? ClaimSalutation { get; set; }
        public string? ClaimLanguage { get; set; }
        public string? ClaimEmployerName { get; set; }
        public DateTime? ClaimEmploymentSinceDate { get; set; }
        public bool? ClaimPowerOfAttorney { get; set; }
        public bool? ClaimSalaryTransfer { get; set; }
        public string? ClaimProfession { get; set; }
        public string? ClaimUpdatedAt { get; set; }

        public string? ResidentialAddressType { get; set; }
        public string? ResidentialAddressLine { get; set; }
        public string? ResidentialBuildingNumber { get; set; }
        public string? ResidentialBuildingName { get; set; }
        public string? ResidentialFloor { get; set; }
        public string? ResidentialStreetName { get; set; }
        public string? ResidentialDistrictName { get; set; }
        public string? ResidentialPostBox { get; set; }
        public string? ResidentialTownName { get; set; }
        public string? ResidentialCountrySubDivision { get; set; }
        public string? ResidentialCountry { get; set; }

        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ResponsePayload { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? O3CallerOrgId { get; set; }
        public string? O3CallerClientId { get; set; }
    }
}
