using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ThrottleCoreCRM.Server.Models.Throttle_Core_Activity;

namespace ThrottleCoreCRM.Server.Data
{
    public partial class Throttle_Core_ActivityContext : DbContext
    {
        public Throttle_Core_ActivityContext()
        {
        }

        public Throttle_Core_ActivityContext(DbContextOptions<Throttle_Core_ActivityContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.Userdetail>().HasNoKey();

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>()
              .Property(p => p.fldSysUserID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>()
              .Property(p => p.fldSysCompID)
              .HasDefaultValueSql(@"((1))");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>()
              .Property(p => p.fldSysDate_Created)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>()
              .Property(p => p.fldSysDate_LastModified)
              .HasDefaultValueSql(@"(getutcdate())");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldDMS_Source_Created_DateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldDMS_Source_Processed_DateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldDMS_Target_Moved_DateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldDMS_Archive_Added_DateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldLastModifiedDate)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldDMS_Archive_Created_DateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldDMS_Archive_LastModified_DateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldLastModifiedDate)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>()
              .Property(p => p.fldLastModifiedDate)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldDMS_Source_Discovered_DateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldDMS_Source_Finalized_DateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldLastModifiedDate)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>()
              .Property(p => p.fldLastModifiedDate)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>()
              .Property(p => p.fldfile_date)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldDateCreated)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldDateSent)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldDateUpdated)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>()
              .Property(p => p.fldDateChecked)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>()
              .Property(p => p.fldMaxDateTime)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>()
              .Property(p => p.fldDateCreated)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>()
              .Property(p => p.fldLastModifiedDate)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>()
              .Property(p => p.fldDateCreated)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>()
              .Property(p => p.fldDateUpdated)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>()
              .Property(p => p.fldEndDate)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>()
              .Property(p => p.fldStartDate)
              .HasColumnType("smalldatetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>()
              .Property(p => p.fldSysDate_Created)
              .HasColumnType("datetime");

            builder.Entity<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>()
              .Property(p => p.fldSysDate_LastModified)
              .HasColumnType("datetime");
            this.OnModelBuilding(builder);
        }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> TblDataDmSFileActivities { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> TblDataDmSFileArchiveActivities { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveServer> TblDataDmSFileArchiveServers { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> TblDataDmSFtPActivities { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSProvider> TblDataDmSProviders { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperAcknowledgementType> TblDataHelperAcknowledgementTypes { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperFileType> TblDataHelperFileTypes { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperIntegration> TblDataHelperIntegrations { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperPosType> TblDataHelperPosTypes { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataHelperProduct> TblDataHelperProducts { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportStore> TblDataImportStores { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataImportVerification> TblDataImportVerifications { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> TblMessageActivities { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> TblMessageCommDates { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> TblMessageDirections { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> TblMessageErrorCodes { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> TblMessageGroupingTerms { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingType> TblMessageGroupingTypes { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> TblMessageMissedCalls { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageNotification> TblMessageNotifications { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> TblMessagePhoneNumbers { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageSetting> TblMessageSettings { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> TblMessageUsages { get; set; }

        public DbSet<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.Userdetail> Userdetails { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    
    }
}