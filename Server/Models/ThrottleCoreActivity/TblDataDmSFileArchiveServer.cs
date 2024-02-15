using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblData-DMS-File-Archive-Server", Schema = "dbo")]
    public partial class TblDataDmSFileArchiveServer
    {
        [Key]
        [Required]
        public int fldRecordID { get; set; }

        public string fldDMS_Server_Name { get; set; }

        public string fldDMS_Server_IP { get; set; }

        public string fldDMS_Server_Default_Directory { get; set; }

        public DateTime? fldLastModifiedDate { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}