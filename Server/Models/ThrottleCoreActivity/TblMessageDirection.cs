using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblMessage_Directions", Schema = "dbo")]
    public partial class TblMessageDirection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string fldDirection { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}