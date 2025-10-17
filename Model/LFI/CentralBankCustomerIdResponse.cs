namespace DataSharing_API.Model.LFI;

public class CentralBankCustomerIdResponse
{
    public List<Datas>? data { get; set; }
    public Meta? meta { get; set; }
}

public class Datas
{
    public string? id { get; set; }
    public string? number { get; set; }
    public string? customerType { get; set; }
    public string? customerCategory { get; set; }
    public string? accountRole { get; set; }
    public List<VerifiedClaim>? verifiedClaims { get; set; }
}

