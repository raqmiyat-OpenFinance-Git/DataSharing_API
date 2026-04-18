namespace DataSharing_API.Logging;

public class DataSharingLogger : BaseLogger
{
    public DataSharingLogger(IConfiguration configuration) : base(configuration)
    {
        bool siemEnabled = configuration.GetValue<bool>("SIEM-Ready-Log");

        if (siemEnabled)
        {
            LogManager.Setup().LoadConfigurationFromFile("NLog.config");
            Log = LogManager.GetLogger("DataSharingJsonLogger");
        }
        else
        {
            Log = LogManager.GetLogger("DataSharingLogger");
        }
    }
}



