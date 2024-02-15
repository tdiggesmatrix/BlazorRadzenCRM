using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite
{
    [Table("tblWebSiteLanguage", Schema = "dbo")]
    public partial class TblWebSiteLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string fldLanguage { get; set; }

        [Column("fldLanguage-InLanguage")]
        public string fldLanguageInLanguage { get; set; }

        [Column("fldLocation-Type")]
        public string fldLocationType { get; set; }

        [Column("fldLanguage-ID")]
        public string fldLanguageID { get; set; }

        [Column("fldLanguage-Tag")]
        public string fldLanguageTag { get; set; }

        public byte[] fldImage { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}