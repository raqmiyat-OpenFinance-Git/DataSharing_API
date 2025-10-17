namespace DataSharing_API.Model.TPP
{
    public class TppBalancesViewModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? ConsentId { get; set; }
        public string? AccountId { get; set; }
        public string? Action { get; set; }
        public List<TppBalancesDetailDto>? tppBalancesDetailDtos { get; set; }
        public TppBalancesRequest? tppBalancesRequest { get; set; }
        public TppBalancesResponse? tppBalancesResponse { get; set; }
    }
}
