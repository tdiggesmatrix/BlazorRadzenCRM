using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite
{
    [Table("tblWebSiteUsers", Schema = "dbo")]
    public partial class TblWebSiteUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string fldUserName { get; set; }

        public int? fldUserID { get; set; }

        [Column("fldLanguage-RecordID")]
        public int? fldLanguageRecordID { get; set; }

        public string fldFirstname { get; set; }

        public string fldLastname { get; set; }

        public string fldEmail { get; set; }

        public string fldPassword { get; set; }

        public short? fldStatus { get; set; }

        public bool? fldEnabled { get; set; }

        [Column("fldWebsite-SecurityGroups-RecordID")]
        public int? fldWebsiteSecurityGroupsRecordID { get; set; }

        [Column("fldDefault-Database-RecordID")]
        public int? fldDefaultDatabaseRecordID { get; set; }

        [Column("fldDefault-StoreGroup-RecordID")]
        public int? fldDefaultStoreGroupRecordID { get; set; }

        [Column("fldDefault-StoreList")]
        public string fldDefaultStoreList { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}