namespace DataSharing_API.Model.LFI;

public class LfiBankProductData
{
    public LfiProductDataRequest? LfiProductDataRequest { get; set; }
    public LfiProductDataResponse? LfiProductDataResponse { get; set; }

    public LfiCurrentAccount? LfiCurrentAccount { get; set; }
    public LfiSavingsAccount? LfiSavingsAccount { get; set; }
    public LfiPersonalLoan? LfiPersonalLoan { get; set; }
    public LfiCreditCard? LfiCreditCard { get; set; }
    public LfiMortgage? LfiMortgage { get; set; }
}
