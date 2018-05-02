using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataLayer
{
 

    public partial class RestDbContent : DbContext
    {
        public RestDbContent()
            : base("name=RestDbContent")
        {
        }

        public virtual DbSet<Restaurants> restaurants { get; set; }
        public virtual DbSet<ReviewModel> reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurants>()
                .Property(e => e.Restaurant)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurants>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurants>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurants>()
                .Property(e => e.Rating)
                .HasPrecision(2, 1);

            modelBuilder.Entity<Restaurants>()
                .Property(e => e.Cuisine)
                .IsUnicode(false);
        }
    }
}
