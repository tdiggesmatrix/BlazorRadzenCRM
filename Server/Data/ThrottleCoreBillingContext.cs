using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ThrottleCoreCRM.Server.Models.Throttle_Core_Billing;

namespace ThrottleCoreCRM.Server.Data
{
    public partial class Throttle_Core_BillingContext : DbContext
    {
        public Throttle_Core_BillingContext()
        {
        }

        public Throttle_Core_BillingContext(DbContextOptions<Throttle_Core_BillingContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetBillingDetailsByDateByAccount>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetGeocodeByAddressOrPlaceResult>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpInsertDataFromXebra>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.DATE_CREATED)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.INVOICE_DATE_FROM)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.INVOICE_DATE_TO)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.EXPORTED)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>()
              .Property(p => p.CUSTOMER_SINCE)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>()
              .Property(p => p.TAX_EXEMPT_EXPIRES)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>()
              .Property(p => p.LAST_INV_DATE)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.QUOTE_DATE)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.ORDER_DATE)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.DUE_DATE)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.INVOICE_DATE)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.DATE_PAID)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.DATE_COMPLETED)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.DATE_ORDERED)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.DATE_DUE)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.DATE_FOLLOW_UP)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.DATE_SHIPPED)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.DATE_REORDER)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.DATE_SHIP_BY)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");
            this.OnModelBuilding(builder);
        }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.BulkBilling> BulkBillings { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CurrentStore> CurrentStores { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerBilling> CustomerBillings { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.CustomerShipping> CustomerShippings { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Job> Jobs { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.LineItem> LineItems { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.Product> Products { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.ProductCategory> ProductCategories { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.RemindersSettingsAdmin> RemindersSettingsAdmins { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsConfiguration> SettingsConfigurations { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SettingsContact> SettingsContacts { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> TblCrossReferences { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetBillingDetailsByDateByAccount> SpGetBillingDetailsByDateByAccounts { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpGetGeocodeByAddressOrPlaceResult> SpGetGeocodeByAddressOrPlaces { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.SpInsertDataFromXebra> SpInsertDataFromXebras { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    
    }
}