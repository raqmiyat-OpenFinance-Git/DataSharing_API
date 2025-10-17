namespace DataSharing_API.Model.LFI;
public class LfiProfitSharingRate
{
    public Guid Id { get; set; }
    public long RequestId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Deposit and returns
    public decimal? MinimumDepositAmount { get; set; }
    public string Currency { get; set; }
    public decimal? AnnualReturn { get; set; }

    // Investment period
    public string InvestmentPeriodName { get; set; }
    public string InvestmentPeriodDescription { get; set; }

    // Annual return options
    public string AnnualReturnName { get; set; }
    public string AnnualReturnDescription { get; set; }

    // Additional information
    public string AdditionalInfoType { get; set; }
    public string AdditionalInfoDescription { get; set; }
}
