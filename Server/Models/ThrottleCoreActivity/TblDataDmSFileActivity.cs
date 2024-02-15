using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblData-DMS-File-Activity", Schema = "dbo")]
    public partial class TblDataDmSFileActivity
    {
        [Key]
        [Required]
        public int fldRecordID { get; set; }

        [Required]
        public int fldDMS_Provider_RecordID { get; set; }

        [Required]
        public string fldDMS_Source_Filename { get; set; }

        [Required]
        public string fldDMS_Source_Directory { get; set; }

        public int? fldDMS_Source_Size { get; set; }

        public DateTime? fldDMS_Source_Created_DateTime { get; set; }

        public DateTime? fldDMS_Source_Processed_DateTime { get; set; }

        public string fldDMS_Target_Filename { get; set; }

        public string fldDMS_Target_Directory { get; set; }

        public DateTime? fldDMS_Target_Moved_DateTime { get; set; }

        public int? fldDMS_ArchiveIDPK { get; set; }

        public DateTime? fldDMS_Archive_Added_DateTime { get; set; }

        public DateTime? fldLastModifiedDate { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}