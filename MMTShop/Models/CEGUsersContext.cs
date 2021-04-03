using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CEGUsers.Models
{
    public class CEGUsersContext : DbContext
    {
        #region Contructor
        public CEGUsersContext(DbContextOptions<CEGUsersContext> options) : base(options)
        {

        }
        #endregion


        #region Public properties
        public DbSet<CEGUser> Users { get; set; }
        public DbSet<UserAddresses> Addresses { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CEGUser>().HasKey(x => x.ID);
            modelBuilder.Entity<UserAddresses>().HasKey(x => x.ID);
            //modelBuilder.Entity<UserAddresses>().HasData();   
            base.OnModelCreating(modelBuilder);
        }
        #endregion


        #region Private methods
       
        #endregion
    }
}
