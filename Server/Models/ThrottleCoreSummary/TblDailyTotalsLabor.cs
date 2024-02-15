using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblDailyTotalsLabor", Schema = "dbo")]
    public partial class TblDailyTotalsLabor
    {
        [Column("fldCustomer-RecordID")]
        public int? fldCustomerRecordID { get; set; }

        [Column("fldCustomer-Stores-RecordID")]
        public int? fldCustomerStoresRecordID { get; set; }

        [Required]
        public DateTime fldDate { get; set; }

        [Column("fldHelper-Labor-RecordID")]
        public int? fldHelperLaborRecordID { get; set; }

        public byte? fldNumberofService { get; set; }

        public byte? fldNumberOfInvoices { get; set; }

        public float? fldPercentofService { get; set; }

        public decimal? fldDollarofService { get; set; }

        public float? fldPercentofTotalSales { get; set; }

        public decimal? fldCostAmt { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fldRecordID { get; set; }

    }
}