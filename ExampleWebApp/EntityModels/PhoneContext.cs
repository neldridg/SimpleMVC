using System;
using ExampleWebApp.EntityModels.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApp.EntityModels
{
    public class PhoneContext : DbContext
    {
        public PhoneContext(DbContextOptions<PhoneContext> options) : base(options)
        {

        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Add a non-navigable property to your model that shadows the foreign key.
            // You almost never need to use this, so this won't be a property.
            // This is called a shadow property. You can add other if necessary.
            builder.Entity<Phone>()
                .Property<Guid>("BlogId");

            // Using the model builder to say that a phone has one manufacturer with many phones
            // You need to define this for both Phone and Manufacturer to make sure you can navigate
            // between them.
            builder.Entity<Phone>()
                .HasOne(phone => phone.Manufacturer)
                .WithMany(man => man.Phones)
                .HasForeignKey("BlogId");


            // Note here that we didn't define anything special besides the ability to look at all phones
            // belonging to a Manufacturer.
            builder.Entity<Manufacturer>()
                .HasMany(man => man.Phones)
                .WithOne(phone => phone.Manufacturer);
        }
    }
}
