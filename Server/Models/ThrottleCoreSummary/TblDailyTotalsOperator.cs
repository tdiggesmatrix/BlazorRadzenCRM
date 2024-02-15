using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblDailyTotalsOperator", Schema = "dbo")]
    public partial class TblDailyTotalsOperator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fldRecordID { get; set; }

        [Column("fldCustomer-RecordID")]
        public int? fldCustomerRecordID { get; set; }

        [Column("fldCustomer-Stores-RecordID")]
        public int? fldCustomerStoresRecordID { get; set; }

        [Required]
        public DateTime fldDate { get; set; }

        [Column("fldOperator-RecordID")]
        [Required]
        public int fldOperatorRecordID { get; set; }

        public byte? fldNumberofSales { get; set; }

        public decimal? fldDollarofSales { get; set; }

        public decimal? fldDollarRefundofSales { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}