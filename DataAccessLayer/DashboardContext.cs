using DataAccessLayer.Configuration;
using DomainModels;
using Microsoft.EntityFrameworkCore;
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
}

