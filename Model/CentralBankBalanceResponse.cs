
namespace DataSharing_API.Models
;
public class CentralBankBalanceResponse
{
    public List<BalanceData>? data { get; set; }
    public Metas? meta { get; set; }
  
}

public class BalanceData
{
    public string? accountId { get; set; }
    public string? creditDebitIndicator { get; set; }
    public string? balanceType { get; set; }
    public DateTime timestamp { get; set; }
    public BalanceAmount? amount { get; set; }
    public List<CreditLine>? creditLines { get; set; }
    public List<Component>? components { get; set; }
}

public class BalanceAmount
{
    public string? amount { get; set; }
    public string? currency { get; set; }
}

public class CreditLine
{
    public bool included { get; set; }
    public string? creditType { get; set; }
    public BalanceAmount? amount { get; set; }
}
public class Component
{
    public string? Amount { get; set; }
    public string? Currency { get; set; } // e.g., "SAR"
    public string? BalanceCategory { get; set; } // e.g., "Principal"
}


public class Metas
{
    public decimal totalPages { get; set; }
    public decimal totalRecords { get; set; }
}