using Microsoft.EntityFrameworkCore;
using PeopleUXComex.Core.Entities;

namespace PeopleUXComex.Infrastructure.Data
{
    public class PeopleUXComexContext : DbContext
    {
        public PeopleUXComexContext(DbContextOptions<PeopleUXComexContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Address>().ToTable("Address");
        }
    }
}
