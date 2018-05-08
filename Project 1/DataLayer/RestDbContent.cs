using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DataLayer.Models;

namespace DataLayer
{
 

    public partial class RestDbContent : DbContext
    {
        public RestDbContent()
            : base("name=RestDbContent")
        {
        }

        public virtual DbSet<RestaurantModel> restaurants { get; set; }
        public virtual DbSet<ReviewModel> reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantModel>()
                .Property(e => e.Restaurant)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurantModel>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurantModel>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurantModel>()
                .Property(e => e.Rating)
                .HasPrecision(2, 1);

            modelBuilder.Entity<RestaurantModel>()
                .Property(e => e.Cuisine)
                .IsUnicode(false);

        }
    

        public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("Created").CurrentValue = DateTime.Now;
            });

            var ModifiedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            ModifiedEntities.ForEach(E =>
            {
                E.Property("Modified").CurrentValue = DateTime.Now;
            });
            return base.SaveChanges();
        }

       
    }
}
