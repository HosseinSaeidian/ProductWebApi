using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SessionNine.Domains.Entity;

namespace SessionNine.Infrastructure.Data.Config
{
    public class SecurityConfig : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Security");
            builder.Property(a => a.Id).IsRequired(true);

            //! nathional Code is 10 char
            builder.Property(a => a.UserName).IsRequired(true).HasMaxLength(10);
            builder.Property(a => a.Password).IsRequired(true);
            builder.Property(a => a.Accses).IsRequired(false);
            builder.Property(a => a.Description).IsRequired(false).HasMaxLength(200);   
            builder.Property(a => a.DataCreated).IsRequired(true);
        }
    }
}
