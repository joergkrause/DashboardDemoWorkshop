using DataAccessLayer.Configuration;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer;

public class DashboardContext : DbContext
{

  public DashboardContext(DbContextOptions options) : base(options)
  {

  }

  public override int SaveChanges()
  {
    throw new InvalidOperationException("This method is not supported. Use SaveChangesAsync instead.");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {


    modelBuilder.ApplyConfiguration(new DashboardConfiguration());
    modelBuilder.ApplyConfiguration(new WidgetConfiguration());

    base.OnModelCreating(modelBuilder);
  }

  public class DashboardContextFactory : IDesignTimeDbContextFactory<DashboardContext>
  {
    public DashboardContext CreateDbContext(string[] args)
    {
      var options = new DbContextOptionsBuilder<DashboardContext>()
        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AkgDashboardDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
        .Options;
      return new DashboardContext(options);
    }
  }

}