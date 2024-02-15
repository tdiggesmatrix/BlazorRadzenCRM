using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("Bulk_Billing", Schema = "dbo")]
    public partial class BulkBilling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string ID { get; set; }

        public string DESC { get; set; }

        public string BILL_CODE { get; set; }

        public DateTime? DATE_CREATED { get; set; }

        public DateTime? INVOICE_DATE_FROM { get; set; }

        public DateTime? INVOICE_DATE_TO { get; set; }

        public DateTime? EXPORTED { get; set; }

        public bool? BULK_BILL { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}