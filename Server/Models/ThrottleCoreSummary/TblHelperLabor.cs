using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblHelperLabor", Schema = "dbo")]
    public partial class TblHelperLabor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fldRecordID { get; set; }

        [Column("fldCustomer-RecordID")]
        public int? fldCustomerRecordID { get; set; }

        [Column("fldCustomer-Stores-RecordID")]
        public int? fldCustomerStoresRecordID { get; set; }

        public int? fldOpCode_RecordID { get; set; }

        public string fldLabor_Description { get; set; }

        public bool? fldLabor_FixedPrice { get; set; }

        public decimal? fldLabor_Time { get; set; }

        public decimal? fldLabor_Amount { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}