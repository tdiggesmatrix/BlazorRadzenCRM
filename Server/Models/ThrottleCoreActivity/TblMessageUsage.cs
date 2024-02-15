using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblMessage_Usage", Schema = "dbo")]
    public partial class TblMessageUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fldRecordID { get; set; }

        public string fldAccountSID { get; set; }

        public string fldApiVersion { get; set; }

        public string fldAsOf { get; set; }

        public string fldCategory { get; set; }

        public string fldCategoryEnum { get; set; }

        public string fldCount { get; set; }

        public string fldCountUnit { get; set; }

        public string fldDescription { get; set; }

        public DateTime? fldEndDate { get; set; }

        public decimal? fldPrice { get; set; }

        public string fldPriceUnit { get; set; }

        public DateTime? fldStartDate { get; set; }

        public string fldSubresourceUris { get; set; }

        public string fldURI { get; set; }

        public string fldUsage { get; set; }

        public string fldUsageUnit { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}