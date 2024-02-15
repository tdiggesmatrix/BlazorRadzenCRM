using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblMessage_Notifications", Schema = "dbo")]
    public partial class TblMessageNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public short? fldSourceType { get; set; }

        public int? fldSourceidpk { get; set; }

        public int? fldNotificationType { get; set; }

        public DateTime? fldDateCreated { get; set; }

        public string fldEmailAddress { get; set; }

        public DateTime? fldLastModifiedDate { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}