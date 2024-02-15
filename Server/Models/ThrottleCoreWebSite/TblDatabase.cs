using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite
{
    [Table("tblDatabase", Schema = "dbo")]
    public partial class TblDatabase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldDatabase-Name")]
        [Required]
        public string fldDatabaseName { get; set; }

        [Column("fldDatabase-Type")]
        [Required]
        public short fldDatabaseType { get; set; }

        [Column("fldDatabase-Server-Name")]
        [Required]
        public string fldDatabaseServerName { get; set; }

        [Column("fldDatabase-Server-IP")]
        public string fldDatabaseServerIP { get; set; }

        [Column("fldDatabase-Server-Master-UID")]
        public string fldDatabaseServerMasterUID { get; set; }

        [Column("fldDatabase-Server-Master-PWD")]
        public string fldDatabaseServerMasterPWD { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}