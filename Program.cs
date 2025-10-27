using DataSharing_API.IService.LFI;
using DataSharing_API.IService.TPP;
using DataSharing_API.Service.LFI;
using DataSharing_API.Service.TPP;

internal class Program
{
    private static readonly Logger _logger = LogManager.GetLogger("DataSharing_API.Logger");
    private static void Main(string[] args)
    {
        
    var builder = WebApplication.CreateBuilder(args);



        
        builder.Services.AddHttpClient("HttpClient")
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        });

        // Example HttpClient with BaseAddress
        var httpBinBaseUrl = builder.Configuration["HttpClients:HttpBinBaseUrl"];
        builder.Services.AddHttpClient("HttpBinClient", client =>
        {
            client.BaseAddress = new Uri(httpBinBaseUrl);
        });

        // ------------------------ Configuration ------------------------
        var configuration = builder.Configuration;
        ConfigureApplicationSettings(builder.Services, configuration);
        // ------------------------ Database Connection ------------------------
        RegisterDbConnection(builder.Services);
        // ------------------------ EF Core DbContexts ------------------------
        ConfigureBalanceDbContext(builder.Services);
        ConfigureAccountDbContext(builder.Services);
        // ------------------------ Transient Services ------------------------
        RegisterTransientServices(builder.Services);
        // ------------------------ Singleton Services ------------------------
        RegisterSingletonServices(builder.Services);



        // ------------------------ CORS ------------------------
        var AllowSpecificOrigins = "DataSharing_API";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: AllowSpecificOrigins, policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        // ------------------------ Controllers & Swagger ------------------------
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(type => type.FullName); // avoids duplicate schema names
        });

        // ------------------------ Health Checks ------------------------
        builder.Services.AddHealthChecks();

        var app = builder.Build();

        // ------------------------ Middleware ------------------------
        app.UseHttpsRedirection();
        app.UseCors(AllowSpecificOrigins);
        app.UseAuthorization();

        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();

        // ------------------------ Health Check Endpoint ------------------------
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.Run();


       
    }
    private static void ConfigureApplicationSettings(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServiceParams>(configuration.GetSection(nameof(ServiceParams)));
        services.Configure<StoredProcedureParams>(configuration.GetSection(nameof(StoredProcedureParams)));
        services.Configure<DataBaseConnectionParams>(configuration.GetSection(nameof(DataBaseConnectionParams)));
    }
    private static void RegisterDbConnection(IServiceCollection services)
    {
        services.AddScoped<IDbConnection>(provider =>
        {
            var config = provider.GetRequiredService<IOptions<DataBaseConnectionParams>>().Value;

            var connectionString = SqlConManager.GetConnectionString(
                config.DBConnection!,
                config.IsEncrypted
            );

            var dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            return dbConnection;
        });

        
    }
    // EF Core DbContext
    private static void ConfigureBalanceDbContext(IServiceCollection services)
    {
        services.AddDbContext<BalanceDbContext>((provider, options) =>
        {
            var config = provider.GetRequiredService<IOptions<DataBaseConnectionParams>>().Value;

            var connectionString = SqlConManager.GetConnectionString(
                config.DBConnection!,
                config.IsEncrypted
            );

            options.UseSqlServer(connectionString);


        });
    }
    // EF Core DbContext
    private static void ConfigureAccountDbContext(IServiceCollection services)
    {
        services.AddDbContext<AccountDbContext>((provider, options) =>
        {
            var config = provider.GetRequiredService<IOptions<DataBaseConnectionParams>>().Value;

            var connectionString = SqlConManager.GetConnectionString(
                config.DBConnection!,
                config.IsEncrypted
            );

            options.UseSqlServer(connectionString);
        });
    }
    private static void RegisterTransientServices(IServiceCollection services)
    {
        services.AddTransient<ConnectCustom>();
        services.AddTransient<IBalanceDataService, BalanceDataService>();
        services.AddTransient<ICustomerDataService, CustomerDataService>();
        services.AddTransient<IAccountDataService, AccountDataService>();
        services.AddTransient<IBeneficiariesDataService, BeneficiariesDataService>();
        services.AddTransient<ILfiTransactionalDataService, LfiTransactionalDataService>();
        services.AddTransient<IProductDataService, ProductDataService>();
        services.AddTransient<ISchedPaymentDataService, SchedPaymentDataService>();
        services.AddTransient<IStatementDataService, StatementDataService>();
        services.AddTransient<IDirectDebitDataService, DirectDebitDataService>();
        services.AddTransient<IStandingOrderDataService, StandingOrderDataService>();
        services.AddTransient<ICreateBalanceDataService, CreateBalanceDataService>();
        services.AddTransient<IDashboardService, DashboardService>();
        services.AddTransient<ITppCustomerDataService, TppCustomerDataService>();
        services.AddTransient<ICreateAccountDataService, CreateAccountDataService>();
        services.AddTransient<ILfiCopQueryDataService, LfiCopQueryDataService>();
        services.AddTransient<ILfiCurrentAccountService, LfiCurrentAccountService>();
        services.AddTransient<ILfiSavingsAccountService, LfiSavingsAccountService>();
        services.AddTransient<ILfiCreditCardService, LfiCreditCardService>();
        services.AddTransient<ILfiPersonalLoanService, LfiPersonalLoanService>();
        services.AddTransient<ILfiMortgageService, LfiMortgageService>();
        services.AddTransient<ILfiProductQuoteMasters, LfiProductQuoteMasters>();
        services.AddTransient<HttpClientHandler>();
        services.AddTransient<Logger>(sp =>
        {
            return LogManager.GetLogger("DataSharing_API.Logger");
        });

    }

    private static void RegisterSingletonServices(IServiceCollection services)
    {
        services.AddSingleton<BaseLogger>();
        services.AddSingleton<DataSharingLogger>();
    }
    
}
