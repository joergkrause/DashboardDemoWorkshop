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
  internal class WidgetConfiguration : IEntityTypeConfiguration<Widget>
  {
    public void Configure(EntityTypeBuilder<Widget> builder)
    {
      builder.ToTable("Widgets");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();
      builder.Property(e => e.Name).HasMaxLength(32).IsRequired();
      builder.Property(e => e.Color).HasColumnType("char(6)");
      builder.Property(e => e.Description).HasMaxLength(256).IsRequired(false);

    }
  }
}
