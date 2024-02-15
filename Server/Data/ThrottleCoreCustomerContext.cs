using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ThrottleCoreCRM.Server.Models.Throttle_Core_Customer;

namespace ThrottleCoreCRM.Server.Data
{
    public partial class Throttle_Core_CustomerContext : DbContext
    {
        public Throttle_Core_CustomerContext()
        {
        }

        public Throttle_Core_CustomerContext(DbContextOptions<Throttle_Core_CustomerContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>()
              .Property(p => p.fldCustomerStartDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>()
              .Property(p => p.fldCustomerEndDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>()
              .Property(p => p.fldStoreOpenedDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>()
              .Property(p => p.fldStoreClosedDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");
            this.OnModelBuilding(builder);
        }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomer> TblCustomers { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrand> TblCustomerBrands { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerBrandsStoresJoin> TblCustomerBrandsStoresJoins { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContact> TblCustomerContacts { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerContactsStoresJoin> TblCustomerContactsStoresJoins { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchise> TblCustomerFranchises { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerFranchisesStoresJoin> TblCustomerFranchisesStoresJoins { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroup> TblCustomerGroups { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerGroupsStoresJoin> TblCustomerGroupsStoresJoins { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustry> TblCustomerIndustries { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerIndustryStoresJoin> TblCustomerIndustryStoresJoins { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandService> TblCustomerProductandServices { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerProductandServicesStoresJoin> TblCustomerProductandServicesStoresJoins { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Customer.TblCustomerStore> TblCustomerStores { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    
    }
}