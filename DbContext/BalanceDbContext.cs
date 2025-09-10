using DataSharing_API.Models;
using Microsoft.EntityFrameworkCore;
using OF.DataSharing.Model.EFModel;

namespace OF.ServiceInitiation.CoreBankConn.API.EFModel;

public class BalanceDbContext : DbContext
{
    public BalanceDbContext(DbContextOptions<BalanceDbContext> options) : base(options) { }

    public DbSet<TppBalancesRequest> TppBalancesRequest { get; set; }
    public DbSet<TppBalancesResponse> TppBalancesResponse { get; set; }
    public DbSet<CustomerRequest>? CustomerRequest { get; set; }
    public DbSet<CustomerResponse>? CustomerResponse { get; set; }
   // public DbSet<CentralBankBalanceResponseEF> CentralBankBalanceDBResponse { get; set; }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    //// TppBalancesRequest
    //    //modelBuilder.Entity<TppBalancesRequest>(entity =>
    //    //{
    //    //    entity.ToTable("Tpp_Balances_Request");
    //    //    entity.HasKey(e => e.BalanceRequestId);

    //    //});


    //}
}
