﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nrtlinq
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NorthwindEntities : DbContext
    {
        public NorthwindEntities()
            : base("name=NorthwindEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Bolge> Bolges { get; set; }
        public DbSet<Bolgeler> Bolgelers { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<MusteriDemographic> MusteriDemographics { get; set; }
        public DbSet<Musteriler> Musterilers { get; set; }
        public DbSet<Nakliyeciler> Nakliyecilers { get; set; }
        public DbSet<Personeller> Personellers { get; set; }
        public DbSet<Satis_Detaylari> Satis_Detaylaris { get; set; }
        public DbSet<Satislar> Satislars { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Tedarikciler> Tedarikcilers { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
    }
}
