namespace DataSharing_API.Model.LFI;
using System.Text.Json.Serialization;

public class CentralBankCustomerResponse
{
    public Data? data { get; set; }
    public Meta? meta { get; set; }
}

public class Data
{
    public string? id { get; set; }
    public string? number { get; set; }
    public string? customerCategory { get; set; }
    public List<VerifiedClaim>? verifiedClaims { get; set; }
}

public class VerifiedClaim
{
    public Verification? verification { get; set; }
    public Claims? claims { get; set; }
    public organisationClaims? organisationClaims { get; set; }

}
public class organisationClaims
{
    public string? name { get; set; }
}
public class Verification
{
    public string? trustFramework { get; set; }
    public string? assuranceLevel { get; set; }
    public AssuranceProcess? assuranceProcess { get; set; }
    public string? time { get; set; }
    public string? verificationProcess { get; set; }
    public Evidence? evidence { get; set; }
}

public class AssuranceProcess
{
    public string? policy { get; set; }
    public string? procedure { get; set; }
    public List<AssuranceDetail>? assuranceDetails { get; set; }
}

public class AssuranceDetail
{
    public string? assuranceType { get; set; }
    public string? assuranceClassification { get; set; }
    public List<EvidenceRef>? evidenceRef { get; set; }
}

public class EvidenceRef
{
    public string? txn { get; set; }
    public EvidenceMetadata? evidenceMetadata { get; set; }
}

public class EvidenceMetadata
{
    public string? evidenceClassification { get; set; }
}

public class Evidence
{
    public string? type { get; set; }
    public List<CheckDetail>? checkDetails { get; set; }
    public Verifier? verifier { get; set; }
    public string? time { get; set; }
    public DocumentDetails? documentDetails { get; set; }
    public Attachments? attachments { get; set; }
}

public class CheckDetail
{
    public string? checkMethod { get; set; }
    public string? organization { get; set; }
    public string? txn { get; set; }
    public string? time { get; set; }
}

public class Verifier
{
    public string? organization { get; set; }
    public string? txn { get; set; }
}

public class DocumentDetails
{
    public string? type { get; set; }
    public string? documentNumber { get; set; }
    public string? personalNumber { get; set; }
    public string? serialNumber { get; set; }
    public string? calendarType { get; set; }
    public string? dateOfIssuance { get; set; }
    public string? dateOfExpiry { get; set; }
    public Issuer? issuer { get; set; }
}

public class Issuer
{
    public string? name { get; set; }
    public Address? address { get; set; }
    public CountryCode? countryCode { get; set; }
    public string? jurisdiction { get; set; }
}

public class Address
{
    public string? addressType { get; set; }
    public List<string>? addressLine { get; set; }
    public string? buildingNumber { get; set; }
    public string? buildingName { get; set; }
    public string? floor { get; set; }
    public string? streetName { get; set; }
    public string? districtName { get; set; }
    public string? postBox { get; set; }
    public string? townName { get; set; }
    public string? countrySubDivision { get; set; }
    public string? country { get; set; }
}

public class CountryCode
{
    [JsonPropertyName("CountryCode")]
    public string? Code { get; set; }
}

public class Attachments
{
    public List<AEPartyIdentityEvidenceAttachment>? AEPartyIdentityEvidenceAttachments { get; set; }
}

public class AEPartyIdentityEvidenceAttachment
{
    public string? desc { get; set; }
    public string? contentType { get; set; }
    public string? content { get; set; }
    public string? txn { get; set; }
}

public class Claims
{
    public string? identityType { get; set; }
    public string? fullName { get; set; }
    public string? givenName { get; set; }
    public string? familyName { get; set; }
    public string? middleName { get; set; }
    public string? nickname { get; set; }
    public string? emiratesId { get; set; }
    public string? emiratesIdExpiryDate { get; set; }
    public string? birthDate { get; set; }
    public string? sourceOfIncome { get; set; }
    public decimal salary { get; set; }
    public string? nationality { get; set; }
    public Address? residentialAddress { get; set; }
    public string? mobileNumber { get; set; }
    public string? email { get; set; }
    public string? maritalStatus { get; set; }
    public string? salutation { get; set; }
    public string? language { get; set; }
    public string? employerName { get; set; }
    public string? employmentSinceDate { get; set; }
    public bool powerofAttorney { get; set; }
    public bool salaryTransfer { get; set; }
    public string? profession { get; set; }
    public string? updatedAt { get; set; }
}

public class Meta
{
    public bool paginated { get; set; }
    public decimal totalPages { get; set; }
    public decimal totalRecords { get; set; }
}
