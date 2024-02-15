using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("Job", Schema = "dbo")]
    public partial class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string JOB_NUMBER { get; set; }

        public byte? STATUS { get; set; }

        public string CUSTOMER { get; set; }

        public string CONTACT { get; set; }

        public string SALES_REP { get; set; }

        public byte? TYPE { get; set; }

        public DateTime? QUOTE_DATE { get; set; }

        public DateTime? ORDER_DATE { get; set; }

        public string CUSTOMER_PO { get; set; }

        public DateTime? DUE_DATE { get; set; }

        public string INVOICE_NUMBER { get; set; }

        public DateTime? INVOICE_DATE { get; set; }

        public DateTime? DATE_PAID { get; set; }

        public string CARRIER { get; set; }

        public string FOB { get; set; }

        public string TAX_STATE_1 { get; set; }

        public decimal? SALES_TAX_1 { get; set; }

        public string SWITCHES { get; set; }

        public decimal? SPECIAL_COMMISSION { get; set; }

        public string BILLING_CUSTOMER { get; set; }

        public DateTime? DATE_COMPLETED { get; set; }

        public string ALTADD_SEQ { get; set; }

        public string SALES_TAX_NUMBER { get; set; }

        public string GL_DIV { get; set; }

        public bool? RESTRICT_RECORD { get; set; }

        public string BULK_BILLING_ID { get; set; }

        public string IBSA_BILLING_ID { get; set; }

        public string SPECIAL_INS_ID { get; set; }

        public string COST_CENTER { get; set; }

        public string ORDERED_BY_CONTACT_ID { get; set; }

        public string SHIP_TO_CONTACT_ID { get; set; }

        public string BILL_TO_CONTACT_ID { get; set; }

        public string OPERATOR_CODE { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}