using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite;
using ThrottleCoreCRM.Shared.Models;

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

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    
    }
}