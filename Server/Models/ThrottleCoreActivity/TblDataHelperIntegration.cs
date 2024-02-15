using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblData-Helper-Integrations", Schema = "dbo")]
    public partial class TblDataHelperIntegration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string fldCode { get; set; }

        public bool? fldIsActive { get; set; }

        public string fldName { get; set; }

        public string fldSoftwareName { get; set; }

        public string fldContactEmail { get; set; }

        public string fldContactName { get; set; }

        public string fldConnectionType { get; set; }

        public string fldHostname { get; set; }

        public string fldFTPFolderName { get; set; }

        public string fldUsername { get; set; }

        public string fldPassword { get; set; }

        public short? fldPort { get; set; }

        public string fldPrivateKey { get; set; }

        public bool? fldVerifyHost { get; set; }

        public bool? fldVerifyPeer { get; set; }

        public string fldFileType { get; set; }

        public string fldOptions { get; set; }

        public string fldRecordIndex { get; set; }

        public string fldNotes { get; set; }

        public short? fldSysUserID { get; set; }

        public short? fldSysCompID { get; set; }

        public DateTime? fldSysDate_Created { get; set; }

        public DateTime? fldSysDate_LastModified { get; set; }

    }
}