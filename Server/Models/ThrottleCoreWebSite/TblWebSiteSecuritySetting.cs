using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite
{
    [Table("tblWebSiteSecuritySettings", Schema = "dbo")]
    public partial class TblWebSiteSecuritySetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldWebSite-Menu-RecordID")]
        public int? fldWebSiteMenuRecordID { get; set; }

        [Column("fldWebSite-Users-RecordID")]
        public int? fldWebSiteUsersRecordID { get; set; }

        public string fldSecurityKey { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}