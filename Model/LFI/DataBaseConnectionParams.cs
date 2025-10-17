namespace DataSharing_API.Model.LFI
{
    public class DataBaseConnectionParams
    {
        public string? DBConnection { get; set; }
        public bool IsEncrypted { get; set; }
        public int? CommandTimeout { get; set; }
    }
}
