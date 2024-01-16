using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SessionNine.Domains;
using SessionNine.Domains.Entity;
using SessionNine.Infrastructure.Data.Config;

namespace SessionNine.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options): base(options) 
            {

                
            }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SecurityConfig());
        }

        #region Entity

        public DbSet<Product> Product { get; set; }
        public DbSet<Security> Security { get; set; }

        #endregion

    }
}
