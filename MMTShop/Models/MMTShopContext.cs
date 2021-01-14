using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MMTShop.Models
{
    public class MMTShopContext : DbContext
    {
        #region Contructor
        public MMTShopContext(DbContextOptions<MMTShopContext> options) : base(options)
        {

        }
        #endregion


        #region Public properties
        public DbSet<MMTProduct> Products { get; set; }
        public DbSet<MMTProductCategory> ProductCategory { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MMTProduct>().HasKey(x => x.Id);
            modelBuilder.Entity<MMTProductCategory>().HasKey(x => x.Name);
            modelBuilder.Entity<MMTProductCategory>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }
        #endregion


        #region Private methods
        private List<MMTProductCategory> GetProducts()
        {
            return new List<MMTProductCategory>
                {
                    new MMTProductCategory { Name = "Home"},
                    new MMTProductCategory { Name = "Garden"},
                    new MMTProductCategory { Name = "Electronics"},
                    new MMTProductCategory { Name = "Fitness"},
                    new MMTProductCategory { Name = "Toys"}
                };
        }
        #endregion
    }
}
