namespace DataSharing_API.Custom;

public class Utils
{
    private readonly IOptions<ServiceParams> _serviceParams;
    public Utils(IOptions<ServiceParams> serviceParams)
    {
        _serviceParams = serviceParams;
    }
    public async Task<bool> CheckValidXml(string message, Logger _logger)
    {
        bool xdocloaded = false;
        await Task.Run(() =>
        {
            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                    var xResDoc = new XmlDocument
                    {
                        PreserveWhitespace = true
                    };
                    xResDoc.LoadXml(message);
                    xdocloaded = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Utils", "CheckValidXml", ex.Message);
            }
        });
        return xdocloaded;
    }
    public async Task<string> Serialize<T>(T? objectToSerialize, Logger _logger)
    {
        string serializedObj = string.Empty;
        await Task.Run(() =>
        {
            try
            {
                StringBuilder sb = new();
                XmlWriterSettings settings = new() { Encoding = Encoding.UTF8, Indent = true };
                using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
                {
                    if (xmlWriter != null)
                    {
                        new XmlSerializer(typeof(T)).Serialize(xmlWriter, objectToSerialize);
                    }
                }
                serializedObj = sb.ToString();
                serializedObj = serializedObj.Replace("utf-16", "UTF-8");
            }
            catch (Exception ex)
            {
                _logger.Error("Utils", "Serialize", ex.Message);
            }
        });
        return serializedObj;
    }
    public async Task<T> Deserialize<T>(string xmlContent, Logger _logger) where T : class
    {
        T? deserializedObject = null;
        await Task.Run(() =>
        {
            try
            {
                XmlSerializer serializer = new(typeof(T));
                using StringReader stringReader = new(xmlContent);
                deserializedObject = serializer.Deserialize(stringReader) as T;
            }
            catch (Exception ex)
            {
                _logger.Error("Utils", "Deserialize", ex.Message);
            }
        });
        return deserializedObject!;
    }

    public async Task<bool> IsValidJson(string strInput, Logger _logger)
    {
        bool result = false;
        await Task.Run(() =>
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(strInput))
                {

                    strInput = strInput.Trim();
                    if (strInput.StartsWith('{') && strInput.EndsWith('}') || //For object
                        strInput.StartsWith('[') && strInput.EndsWith(']')) //For array
                    {
                        JToken.Parse(strInput);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Utils", "IsValidJson", ex.Message);
            }

        });
        return result;
    }
    public async Task<bool> IsValidXml(string strInput, Logger _logger)
    {
        bool result = false;
        await Task.Run(() =>
        {
            try
            {
                if (!string.IsNullOrEmpty(strInput) && strInput.TrimStart().StartsWith('<'))
                {
                    XDocument.Parse(strInput);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Utils", "IsValidXml", ex.Message);
            }
        });
        return result;
    }


}
