﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPS410_CampusBikeRental.Code
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BikeRentalEntities : DbContext
    {
        public BikeRentalEntities()
            : base("name=BikeRentalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Bike_Condition> Bike_Condition { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Usertype> Usertypes { get; set; }
    }
}
