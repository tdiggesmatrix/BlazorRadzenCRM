using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblData-DMS-File-Archive-Activity", Schema = "dbo")]
    public partial class TblDataDmSFileArchiveActivity
    {
        [Key]
        [Required]
        public int fldRecordID { get; set; }

        public string fldDMS_Archive_Filename { get; set; }

        public int? fldDMS_Archive_Server_RecordID { get; set; }

        public string fldDMS_Archive_Directory { get; set; }

        public DateTime? fldDMS_Archive_Created_DateTime { get; set; }

        public DateTime? fldDMS_Archive_LastModified_DateTime { get; set; }

        public DateTime? fldLastModifiedDate { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}