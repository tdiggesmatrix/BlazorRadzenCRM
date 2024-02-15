using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("Customer_Billing", Schema = "dbo")]
    public partial class CustomerBilling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string BILL_CODE { get; set; }

        public string COMPANY_NAME { get; set; }

        public string ADDRESS_LINE_1 { get; set; }

        public string ADDRESS_LINE_2 { get; set; }

        public string CITY { get; set; }

        public string STATE { get; set; }

        public string ZIP { get; set; }

        public string PHONE { get; set; }

        public string FAX { get; set; }

        public string EMAIL { get; set; }

        public string CONTACT { get; set; }

        public string SALUTATION { get; set; }

        public string TERMS { get; set; }

        public decimal? CREDIT_LIMIT { get; set; }

        public string TAX_EXEMPT { get; set; }

        public DateTime? CUSTOMER_SINCE { get; set; }

        public string SWITCHES { get; set; }

        public short? GRACE_DAYS { get; set; }

        public short? PRICING_LEVEL { get; set; }

        public string TAX_EXEMPT_NUMBER { get; set; }

        public string SHIPPING_ACCOUNT_NUMBER { get; set; }

        public string CCD_REF_ID { get; set; }

        public bool? INACTIVE { get; set; }

        public DateTime? TAX_EXEMPT_EXPIRES { get; set; }

        public string EDI_CODE { get; set; }

        public string DEFAULT_CONTACT_ID { get; set; }

        public bool? EMAIL_INVOICES { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}