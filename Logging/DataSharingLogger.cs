namespace DataSharing_API.Logging;

public class DataSharingLogger : BaseLogger
{
    public DataSharingLogger() 
    {
        Log = LogManager.GetLogger("DataSharingLogger");
    }
}



