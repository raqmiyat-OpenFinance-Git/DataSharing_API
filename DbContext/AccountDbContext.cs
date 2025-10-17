namespace DataSharing_API.EFModel;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) { }

    public DbSet<TppAccountsRequest> tppAccountsRequests { get; set; }
    public DbSet<TppAccountsResponse> tppAccountsResponses { get; set; }
   
}
