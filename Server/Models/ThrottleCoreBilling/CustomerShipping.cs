using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("Customer_Shipping", Schema = "dbo")]
    public partial class CustomerShipping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string CUSTOMER_CODE { get; set; }

        public string COMPANY_NAME { get; set; }

        public string ADDRESS_LINE_1 { get; set; }

        public string ADDRESS_LINE_2 { get; set; }

        public string CITY { get; set; }

        public string STATE { get; set; }

        public string ZIP_CODE { get; set; }

        public string PHONE_NUMBER { get; set; }

        public string FAX_NUMBER { get; set; }

        public string EMAIL_ADDRESS { get; set; }

        public string BILL_REFERENCE { get; set; }

        public string MASTER_CUSTOMER { get; set; }

        public string COST_CENTER { get; set; }

        public string CONTACT { get; set; }

        public string SALUTATION { get; set; }

        public string SALES_REP { get; set; }

        public string TAX_LOCATION { get; set; }

        public string CATEGORY { get; set; }

        public string NOTES { get; set; }

        public string SWITCHES { get; set; }

        public bool? INACTIVE { get; set; }

        public string OPERATOR_CODE { get; set; }

        public string HTML_CODE { get; set; }

        public string DUNS { get; set; }

        public string SHARED_SECRET { get; set; }

        public byte? BASE64_ORDER { get; set; }

        public byte? ECOMMERCE_ENABLED { get; set; }

        public DateTime? LAST_INV_DATE { get; set; }

        public byte? CUSTOMER_ITEM_NUMBER_DISCOUNTS { get; set; }

        public string EDI_CODE { get; set; }

        public string FEDEX_ACCOUNT { get; set; }

        public string FEDEX_METER_NUM { get; set; }

        public string FEDEX_KEY { get; set; }

        public string FEDEX_PASSWORD { get; set; }

        public byte? FEDEX_RATE_TYPE { get; set; }

        public string DEFAULT_CONTACT_ID { get; set; }

        public string REBATE_CODE { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}