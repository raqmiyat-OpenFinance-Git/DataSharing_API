namespace DataSharing_API.EFModel;

public class BalanceDbContext : DbContext
{
    public BalanceDbContext(DbContextOptions<BalanceDbContext> options) : base(options) { }

    public DbSet<TppBalancesRequest> TppBalancesRequest { get; set; }
    public DbSet<TppBalancesResponse> TppBalancesResponse { get; set; }
    public DbSet<CustomerRequest>? CustomerRequest { get; set; }
    public DbSet<CustomerResponse>? CustomerResponse { get; set; }
   
}
