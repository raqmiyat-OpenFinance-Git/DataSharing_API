namespace DataSharing_API.Custom
{

    public class ErrorDetail
    {
        public string? ErrorCode { get; set; }
        public string? ErrorDesc { get; set; }
    }

    public class ResponseStatus
    {
        public string? status { get; set; }
        public string? statusMessage { get; set; }
        public List<ErrorDetail>? errorDetails { get; set; }
    }
}
