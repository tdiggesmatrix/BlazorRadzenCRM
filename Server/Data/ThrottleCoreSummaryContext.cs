using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ThrottleCoreCRM.Server.Models.Throttle_Core_Summary;

namespace ThrottleCoreCRM.Server.Data
{
    public partial class Throttle_Core_SummaryContext : DbContext
    {
        public Throttle_Core_SummaryContext()
        {
        }

        public Throttle_Core_SummaryContext(DbContextOptions<Throttle_Core_SummaryContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.GetDashboardValuesOriginal>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.GetEmployeesWithDepartment>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDashboardGetStatisticsCustomer>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDashboardGetStatisticsTopVehiclesServiced>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDashboardGetValuesCampaign>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDashboardGetValuesSale>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDataCreateVehicleSummaryDatum>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>()
              .Property(p => p.fldRecordID)
              .ValueGeneratedOnAddOrUpdate()
              .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>()
              .Property(p => p.fldDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>()
              .Property(p => p.fldDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>()
              .Property(p => p.fldDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>()
              .Property(p => p.fldDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>()
              .Property(p => p.fldDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>()
              .Property(p => p.fldDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>()
              .Property(p => p.fldDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>()
              .Property(p => p.fldDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");
            this.OnModelBuilding(builder);
        }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> TblDailyTotals { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor> TblDailyTotalsLabors { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> TblDailyTotalsOperators { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> TblDailyTotalsParts { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperCoupon> TblHelperCoupons { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> TblHelperEmailStatusCodes { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> TblHelperLabors { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperMailAddressError> TblHelperMailAddressErrors { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> TblHelperParts { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCampaign> TblSummaryCampaigns { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryCustomer> TblSummaryCustomers { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> TblSummarySales { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummaryVehicle> TblSummaryVehicles { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.GetDashboardValuesOriginal> GetDashboardValuesOriginals { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.GetEmployeesWithDepartment> GetEmployeesWithDepartments { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDashboardGetStatisticsCustomer> UspDashboardGetStatisticsCustomers { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDashboardGetStatisticsTopVehiclesServiced> UspDashboardGetStatisticsTopVehiclesServiceds { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDashboardGetValuesCampaign> UspDashboardGetValuesCampaigns { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDashboardGetValuesSale> UspDashboardGetValuesSales { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.UspDataCreateVehicleSummaryDatum> UspDataCreateVehicleSummaryData { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    
    }
}