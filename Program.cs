using DataSharing_API.Custom;
using DataSharing_API.IService;
using DataSharing_API.Model;
using DataSharing_API.Service;
using DataSharing_API.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using OF.ServiceInitiation.CoreBankConn.API.EFModel;
using System.Data;
using Microsoft.EntityFrameworkCore;

NLogManagerService _logger = new NLogManagerService();
var builder = WebApplication.CreateBuilder(args);
var _dataBaseConnectionParams = builder.Configuration.GetSection(nameof(DataBaseConnectionParams)).Get<DataBaseConnectionParams>();
string Constr = SqlConManager.GetConnectionString(_dataBaseConnectionParams!.DBConnection!, _dataBaseConnectionParams.IsEncrypted);
builder.Services.Configure<StoredProcedureParams>(builder.Configuration.GetSection("StoredProcedureParams"));
builder.Services.Configure<DataBaseConnectionParams>(builder.Configuration.GetSection("DataBaseConnectionParams"));
builder.Services.Configure<ServiceParams>(builder.Configuration.GetSection("ServiceParams"));
builder.Services.AddTransient<HttpClientHandler>();
builder.Services.AddSingleton<ConnectCustom>();

builder.Services.AddHttpClient("HttpClient")
    .ConfigurePrimaryHttpMessageHandler(
        () => new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        }
    );

// EF Core DbContext
builder.Services.AddDbContext<BalanceDbContext>((sp, options) =>
{
    var dbParams = sp.GetRequiredService<IOptions<DataBaseConnectionParams>>().Value;
    var connStr = SqlConManager.GetConnectionString(dbParams.DBConnection!, dbParams.IsEncrypted);
    options.UseSqlServer(connStr);
});
builder.Services.AddSingleton(provider =>
{
    IDbConnection? dbConnection = null;
    try
    {
        var _dataBaseConnectionParams = builder.Configuration.GetSection(nameof(DataBaseConnectionParams)).Get<DataBaseConnectionParams>();
        dbConnection = new SqlConnection(SqlConManager.GetConnectionString(_dataBaseConnectionParams!.DBConnection!, _dataBaseConnectionParams.IsEncrypted));
        if (dbConnection.State != ConnectionState.Closed)
        {
            return dbConnection;
        }
        dbConnection.Open();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex);
        throw;
    }
    return dbConnection;
});
builder.Services.Configure<ServiceParams>(builder.Configuration.GetSection("ServiceParams"));

builder.Services.AddSingleton<NLogManagerService>();
builder.Services.AddSingleton<NLogDataSharingService>();
builder.Services.AddTransient<ConnectCustom>();



builder.Services.AddTransient<IBalanceDataService, BalanceDataService>();
builder.Services.AddTransient<ICustomerDataService, CustomerDataService>();
builder.Services.AddTransient<IAccountDataService, AccountDataService>();
builder.Services.AddTransient<IBeneficiariesDataService, BeneficiariesDataService>();
builder.Services.AddTransient<ITransactionDataService, TransactionDataService>();
builder.Services.AddTransient<IProductDataService, ProductDataService>();
builder.Services.AddTransient<ISchedPaymentDataService, SchedPaymentDataService>();
builder.Services.AddTransient<IStatementDataService, StatementDataService>();
builder.Services.AddTransient<IDirectDebitDataService, DirectDebitDataService>();
builder.Services.AddTransient<IStandingOrderDataService, StandingOrderDataService>();
builder.Services.AddTransient<ICreateBalanceDataService, CreateBalanceDataService>();
builder.Services.AddTransient<IDashboardService, DashboardService>();
builder.Services.AddTransient<ITppCustomerDataService, TppCustomerDataService>();
builder.Services.AddTransient<ICreateAccountDataService, CreateAccountDataService>();

var AllowSpecificOrigins = "OpenFinance";
builder.Services.AddCors(options => { options.AddPolicy(name: AllowSpecificOrigins, builder => { builder.AllowAnyOrigin().AllowAnyHeader(); }); });
bool isEncrypted = builder.Configuration.GetValue<bool>("DataBaseConnectionParams:IsEncrypted");

string encryptedConnectionString = builder.Configuration.GetValue<string>("DataBaseConnectionParams:DBConnection") ?? "";

if (string.IsNullOrEmpty(encryptedConnectionString))
{
    throw new InvalidOperationException("Encrypted connection string is null or empty.");
}

string decryptedConnectionString = isEncrypted ? SqlConManager.Decrypt(encryptedConnectionString) : encryptedConnectionString;



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var httpBinBaseUrl = builder.Configuration["HttpClients:HttpBinBaseUrl"];

builder.Services.AddHttpClient("HttpBinClient", client =>
{
    client.BaseAddress = new Uri(httpBinBaseUrl);
});

builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName); // prevents duplicate naming issues
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
