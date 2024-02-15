using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblData-DMS-FTP-Activity", Schema = "dbo")]
    public partial class TblDataDmSFtPActivity
    {
        [Key]
        [Required]
        public int fldRecordID { get; set; }

        [Required]
        public string fldDMS_Source_Filename { get; set; }

        [Required]
        public string fldDMS_Source_Directory { get; set; }

        public long? fldDMS_Source_Size { get; set; }

        public DateTime? fldDMS_Source_Discovered_DateTime { get; set; }

        public DateTime? fldDMS_Source_Finalized_DateTime { get; set; }

        public bool? fldDMS_Source_File_Complete { get; set; }

        public DateTime? fldLastModifiedDate { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}