namespace DataSharing_API.Model.TPP
{
    public class TppAccountsViewModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? ConsentId { get; set; }
        public string? AccountId { get; set; }
        public string? Action { get; set; }
        public List<TppAccountsDetailDto>? tppAccountsDetailDtos { get; set; }
        public TppAccountsRequest? tppAccountsRequest { get; set; }
        public TppAccountsResponse? tppAccountsResponse { get; set; }
    }
}
