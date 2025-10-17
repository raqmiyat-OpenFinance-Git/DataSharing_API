namespace DataSharing_API.Model.LFI;
public class ProductQuoteMaster
{
    public int ProductQuoteId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryCode { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
