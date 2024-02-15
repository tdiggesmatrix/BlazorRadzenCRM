using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblDailyTotalsParts", Schema = "dbo")]
    public partial class TblDailyTotalsPart
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

        [Column("fldItems-Category-RecordID")]
        [Required]
        public int fldItemsCategoryRecordID { get; set; }

        public int? fldNumberofService { get; set; }

        public int? fldNumberOfInvoices { get; set; }

        public float? fldPercentofService { get; set; }

        public decimal? fldDollarofService { get; set; }

        public float? fldPercentofTotalSales { get; set; }

        public decimal? fldCost { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}