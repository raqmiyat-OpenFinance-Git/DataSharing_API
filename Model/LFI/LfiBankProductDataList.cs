namespace DataSharing_API.Model.LFI;

public class LfiBankProductDataList
{
    public List<LfiProductDataRequest>? LfiProductDataRequests { get; set; }
    public List<LfiProductDataResponse>? LfiProductDataResponses { get; set; }

    public List<LfiCurrentAccount>? LfiCurrentAccounts { get; set; }
    public List<LfiSavingsAccount>? LfiSavingsAccounts { get; set; }
    public List<LfiPersonalLoan>? LfiPersonalLoans { get; set; }
    public List<LfiCreditCard>? LfiCreditCards { get; set; }
    public List<LfiMortgage>? LfiMortgages { get; set; }
}
