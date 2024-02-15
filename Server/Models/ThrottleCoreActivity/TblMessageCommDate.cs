using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblMessage_CommDates", Schema = "dbo")]
    public partial class TblMessageCommDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public int? fldUID { get; set; }

        public short? fldType { get; set; }

        public DateTime? fldDateChecked { get; set; }

        public DateTime? fldMaxDateTime { get; set; }

        public int? fldRecordsAdded { get; set; }

        public int? fldRecordsAddedwithErrors { get; set; }

        public int? fldRecordsUpdated { get; set; }

        public int? fldRecordsUpdatedwithErrors { get; set; }

        public string fldCategory { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}