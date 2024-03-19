using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configuration
{
  internal class DashboardConfiguration : IEntityTypeConfiguration<Dashboard>
  {
    public virtual void Configure(EntityTypeBuilder<Dashboard> builder)
    {
      builder.ToTable("Dashboards");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();
      builder.Property(e => e.Name).HasMaxLength(64);
    }
  }

  internal class DashboardConfigurationSql : DashboardConfiguration
  {
    public override void Configure(EntityTypeBuilder<Dashboard> builder)
    {
      base.Configure(builder);
      // 
    }
  }
}
