using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using HimsCountry.Data.Entities;
using System.Diagnostics.Metrics;
using HimsCountry.Data.Entities;

namespace HimsCountry.Data
{
    public class Context : DbContext
    {

        public Context() : base() { }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        //public DbSet<Member> MemberModel { get; set; }
        //public DbSet<Entities.Payment> payment { get; set; }
        public Context(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server = localhost; Database = MembersModel; User = root; Password = Hiba@123");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure YourEntity primary key
            modelBuilder.Entity<Currency>().HasKey(e => e.Id);
            modelBuilder.Entity<Country>().HasKey(e => e.Id);
            // Other configurations or relationships can be defined here

            base.OnModelCreating(modelBuilder);
        }


    }
}