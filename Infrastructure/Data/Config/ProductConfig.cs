using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SessionNine.Domains.Entity;

namespace SessionNine.Infrastructure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseHiLo("ProductSeq").IsUnicode().IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(250);
            builder.Property(a => a.Description).IsRequired(false);
        }
    }
}