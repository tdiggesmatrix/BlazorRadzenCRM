using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblMessage_ErrorCodes", Schema = "dbo")]
    public partial class TblMessageErrorCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string code { get; set; }

        public string message { get; set; }

        public string log_level { get; set; }

        public string secondary_message { get; set; }

        public string log_type { get; set; }

        public string docs { get; set; }

        public string causes { get; set; }

        public string solutions { get; set; }

        public string description { get; set; }

        public string product { get; set; }

        public string date_created { get; set; }

        public string last_updated { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}