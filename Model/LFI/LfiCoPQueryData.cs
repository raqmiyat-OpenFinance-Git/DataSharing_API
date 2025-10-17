namespace DataSharing_API.Model.LFI;

public class LfiCoPQueryData
{

    public long LfiCopQueryRequestId { get; set; }  // bigint IDENTITY(1,1)
    public string? O3ProviderId { get; set; }
    public string? O3AspspId { get; set; }
    public string? O3CallerOrgId { get; set; }
    public string? O3CallerClientId { get; set; }
    public string? O3CallerSoftwareStatementId { get; set; }
    public string? O3ApiUri { get; set; }
    public string? O3ApiOperation { get; set; }
    public string? O3CallerInteractionId { get; set; }
    public string? O3OzoneInteractionId { get; set; }
    public string? O3PsuIdentifier { get; set; }
    public Guid? CorrelationId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? SchemeName { get; set; }
    public string? Identification { get; set; }
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Status { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string? RequestPayload { get; set; }
    public string? CurrentStatus { get; set; }

    public long LfiCopQueryResponseId { get; set; }

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
    public string? IssuerAddressFormatted { get; set; }
    public string? IssuerStreetAddress { get; set; }
    public string? IssuerLocality { get; set; }
    public string? IssuerRegion { get; set; }
    public string? IssuerPostalCode { get; set; }
    public string? IssuerAddressCountryCode { get; set; }
    public string? IssuerCountryCode { get; set; }
    public string? IssuerJurisdiction { get; set; }

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
    public string? ClaimEmiratesIdExpiryDate { get; set; }
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
    public string? ClaimEmploymentSinceDate { get; set; }
    public bool? ClaimPowerOfAttorney { get; set; }
    public bool? ClaimSalaryTransfer { get; set; }
    public string? ClaimProfession { get; set; }
    public string? ClaimUpdatedAt { get; set; }

    public string? OrganisationName { get; set; }

    public string? ResidentialAddressFormatted { get; set; }
    public string? ResidentialStreetAddress { get; set; }
    public string? ResidentialLocality { get; set; }
    public string? ResidentialRegion { get; set; }
    public string? ResidentialPostalCode { get; set; }
    public string? ResidentialCountryCode { get; set; }

    public string? ResponseStatus { get; set; }
    public string? ResponseCreatedBy { get; set; }
    public DateTime? ResponseCreatedOn { get; set; }
    public string? ResponseModifiedBy { get; set; }
    public DateTime? ResponseModifiedOn { get; set; }

    public string? ResponsePayload { get; set; }
    public string? CopQueryStatus { get; set; }
}
