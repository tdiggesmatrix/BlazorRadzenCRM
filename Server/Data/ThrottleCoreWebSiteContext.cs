using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite;
using ThrottleCoreCRM.Shared.Models;
using ThrottleCoreCRM.Server.Models.Throttle_Core_Summary;
using DocumentFormat.OpenXml.InkML;
using Microsoft.Data.SqlClient;

namespace ThrottleCoreCRM.Server.Data
{
    public partial class Throttle_Core_WebSiteContext : DbContext
    {
        public Throttle_Core_WebSiteContext()
        {
        }

        public Throttle_Core_WebSiteContext(DbContextOptions<Throttle_Core_WebSiteContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee>()
              .HasOne(i => i.Department)
              .WithMany(i => i.Employees)
              .HasForeignKey(i => i.DepartmentID)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>()
              .HasOne(i => i.Contact)
              .WithMany(i => i.Opportunities)
              .HasForeignKey(i => i.ContactId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>()
              .HasOne(i => i.OpportunityStatus)
              .WithMany(i => i.Opportunities)
              .HasForeignKey(i => i.StatusId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>()
              .HasOne(i => i.Opportunity)
              .WithMany(i => i.Tasks)
              .HasForeignKey(i => i.OpportunityId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>()
              .HasOne(i => i.TaskStatus)
              .WithMany(i => i.Tasks)
              .HasForeignKey(i => i.StatusId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>()
              .HasOne(i => i.TaskType)
              .WithMany(i => i.Tasks)
              .HasForeignKey(i => i.TypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task>()
              .Property(p => p.DueDate)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");
            this.OnModelBuilding(builder);
        }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Contact> Contacts { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Department> Departments { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Employee> Employees { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Opportunity> Opportunities { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.OpportunityStatus> OpportunityStatuses { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.Task> Tasks { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskStatus> TaskStatuses { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TaskType> TaskTypes { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblDatabase> TblDatabases { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteErrorDescription> TblWebSiteErrorDescriptions { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteLanguage> TblWebSiteLanguages { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteMenu> TblWebSiteMenus { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecurityGroup> TblWebSiteSecurityGroups { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteSecuritySetting> TblWebSiteSecuritySettings { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite.TblWebSiteUser> TblWebSiteUsers { get; set; }

        public virtual DbSet<GetEmployeesWithDepartment_Result> GetEmployeesWithDepartment_Results { get; set; }

        public IEnumerable<GetEmployeesWithDepartment_Result> SP_GetEmployeesWithDepartment(int id)
        {
            // Step 3

            return this.GetEmployeesWithDepartment_Results
                .FromSqlInterpolated($"[dbo].[GetEmployeesWithDepartment] {id}")
                .ToList();

        }
        public virtual DbSet<UspDashboardGetValuesSale> UspDashboardGetValuesSale_Results { get; set; }

        public IEnumerable<UspDashboardGetValuesSale> SP_UspDashboardGetValuesSale(int webUserId, int customerId, int stores, string groups, string startDate, string endDate, int onlyActiveStores, int extDaily, int extWtd, int extMtd, int extYtd, int extDod, int extWow, int extMom, int extYoy)
        {
            var webUserIdParam = new SqlParameter("@WebUserID", webUserId);
            var customerIdParam = new SqlParameter("@CustomerID", customerId);
            var storesParam = new SqlParameter("@Stores", stores);
            var groupsParam = new SqlParameter("@Groups", groups);
            var startDateParam = new SqlParameter("@StartDate", startDate);
            var endDateParam = new SqlParameter("@EndDate", endDate);
            var onlyActiveStoresParam = new SqlParameter("@OnlyActiveStores", onlyActiveStores);
            var extDailyParam = new SqlParameter("@ext_Daily", extDaily);
            var extWtdParam = new SqlParameter("@ext_WTD", extWtd);
            var extMtdParam = new SqlParameter("@ext_MTD", extMtd);
            var extYtdParam = new SqlParameter("@ext_YTD", extYtd);
            var extDodParam = new SqlParameter("@ext_DOD", extDod);
            var extWowParam = new SqlParameter("@ext_WOW", extWow);
            var extMomParam = new SqlParameter("@ext_MOM", extMom);
            var extYoyParam = new SqlParameter("@ext_YOY", extYoy);

            using (var context = new Throttle_Core_WebSiteContext()) // Replace Throttle_Core_WebSiteContext with your actual DbContext type
            {
                return context.UspDashboardGetValuesSale_Results
                    .FromSqlRaw("[dbo].[usp_Dashboard_Get_Values_Sales] @WebUserID, @CustomerID, @Stores, @Groups, @StartDate, @EndDate, @OnlyActiveStores, @ext_Daily, @ext_WTD, @ext_MTD, @ext_YTD, @ext_DOD, @ext_WOW, @ext_MOM, @ext_YOY",
                        webUserIdParam, customerIdParam, storesParam, groupsParam, startDateParam, endDateParam, onlyActiveStoresParam, extDailyParam, extWtdParam, extMtdParam, extYtdParam, extDodParam, extWowParam, extMomParam, extYoyParam)
                    .ToList();
            }
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    
    }
}