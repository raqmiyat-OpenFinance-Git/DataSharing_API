namespace DataSharing_API.Logging;

public class BaseLogger
{

    public required Logger Log { get; set; }



    public void Debug(string message)
    {
        Log.Debug(FormStructuredLog(message));
    }

    public void Error(string message)
    {
        Log.Error(FormStructuredLog(message));
    }

    public void Error(Exception ex, string storeProcedure)
    {
        Log.Error(FormStructuredLog($"Exception: {ex.Message}", storeProcedure));

        if (ex.InnerException != null)
        {
            Log.Error(FormStructuredLog($"InnerException: {ex.InnerException.Message}", storeProcedure));
        }
        Log.Error(FormStructuredLog($"StackTrace: {ex.StackTrace}", storeProcedure));
    }

    public void Error(Exception ex)
    {
        Log.Error(FormStructuredLog($"Exception: {ex.Message}"));

        if (ex.InnerException != null)
        {
            Log.Error(FormStructuredLog($"InnerException: {ex.InnerException.Message}"));
        }

        Log.Error(FormStructuredLog($"StackTrace: {ex.StackTrace}"));
    }

    public void Info(string message)
    {
        Log.Info(FormStructuredLog(message));
    }

    public void Warn(string message)
    {
        Log.Warn(FormStructuredLog(message));

    }

    public void Trace(string message)
    {
        Log.Trace(FormStructuredLog(message));

    }

    public static string FormStructuredLog(string message, string storeProcedure)
    {
        var (className, methodName, lineNumber) = ExtractCallerInfo();
        var newLine = "\r\n";
        var separator = "-------------------------------------------------------------------------------------";

        return $"{newLine}Class Name : {className}{newLine}Method Name : {methodName}{newLine}Line Number : {lineNumber}{newLine}StoreProcedure : {storeProcedure}{newLine}Message : {message}{newLine}{separator}";
    }

    public static string FormStructuredLog(string message)
    {
        var (className, methodName, lineNumber) = ExtractCallerInfo();
        var newLine = "\r\n";
        var separator = "-------------------------------------------------------------------------------------";

        return $"{newLine}Class Name : {className}{newLine}Method Name : {methodName}{newLine}Line Number : {lineNumber}{newLine}Message : {message}{newLine}{separator}";
    }

    private static (string className, string methodName, int lineNumber) ExtractCallerInfo()
    {
        string className = "Unknown", methodName = "Unknown";
        int lineNumber = 0;

        try
        {
            string[] ignored = [
                "Start",
                "AsyncMethodBuilderCore",
                "ExecutionContextCallback",
                "RunInternal",
                "RunOrScheduleAction",
                "Info",
                "FormStructuredLog"
            ];

            var stack = new StackTrace(true);

            for (int i = 1; i < stack.FrameCount; i++)
            {
                var frame = stack.GetFrame(i);
                var method = frame?.GetMethod();

                if (method?.DeclaringType != null &&
                    method.DeclaringType != typeof(BaseLogger) &&
                    !ignored.Contains(method.Name))
                {
                    //className = method.DeclaringType.Name;
                    //methodName = method.Name;
                    //lineNumber = frame.GetFileLineNumber();



                    className = method.DeclaringType.Name;
                    methodName = method.Name;
                    lineNumber = frame!.GetFileLineNumber();

                    string filePath = frame.GetFileName() ?? "Unknown";
                    string methodNameWithSuffix = method.Name;
                    string fileName = Path.GetFileName(filePath);

                    int startIndex = className.IndexOf('<') + 1;
                    int endIndex = className.IndexOf('>');

                    if (startIndex != -1 && endIndex != -1)
                    {
                        methodName = className[startIndex..endIndex];
                        className = fileName.Replace(".cs", "");
                    }
                    else
                    {
                        methodName = methodNameWithSuffix;
                    }
                    break;
                }



            }
        }
        catch
        {
            // Safe ignore
        }

        return (className, methodName, lineNumber);
    }
}
