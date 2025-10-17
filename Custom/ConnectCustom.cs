namespace DataSharing_API.Custom;

public class ConnectCustom
{
    private readonly IOptions<DataBaseConnectionParams> _dataBaseConnectionParams;
    private readonly DataSharingLogger _logger;
    public ConnectCustom(IOptions<DataBaseConnectionParams> dataBaseConnectionParams, DataSharingLogger logger)
    {
        _dataBaseConnectionParams = dataBaseConnectionParams;
        _logger = logger;
    }

    public IDbConnection GetSingletonIDbConnection()
    {
        
        SqlConnection dbConnection = new SqlConnection(SqlConManager.GetConnectionString(_dataBaseConnectionParams.Value!.DBConnection!, _dataBaseConnectionParams.Value.IsEncrypted));
        if (dbConnection.State != ConnectionState.Closed)
        {
            _logger.Info("DBConnection is already opened.");
            return dbConnection;
        }
        dbConnection.Open();
        return dbConnection;

    }
    
}
