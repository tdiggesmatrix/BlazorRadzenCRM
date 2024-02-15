using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("Product", Schema = "dbo")]
    public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string PRODUCT_CODE { get; set; }

        public string PRODUCT_DESC_1 { get; set; }

        public string PRODUCT_DESC_2 { get; set; }

        public string SPEC_REF { get; set; }

        public string CUSTOMER_CODE { get; set; }

        public string SELL_UNIT_OF_MEASURE { get; set; }

        public string BUY_UNIT_OF_MEASURE { get; set; }

        public string CUSTOMER_ITEM_NUMBER { get; set; }

        public string SUPPLIER_ITEM_NUMBER { get; set; }

        public decimal? PACK_QUANTITY { get; set; }

        public string PACK_UNIT_OF_MEASURE { get; set; }

        public string PER_UNIT_OF_MEASURE { get; set; }

        public string PRODUCT_CATEGORY { get; set; }

        public string INV_UNIT_OF_MEASURE { get; set; }

        public string SIZE_CODE { get; set; }

        public string ALT_SALES_TAX { get; set; }

        public string VENDOR_1 { get; set; }

        public string VENDOR_2 { get; set; }

        public string VENDOR_3 { get; set; }

        public string SWITCHES { get; set; }

        public string TAX_EXEMPT { get; set; }

        public byte? INACTIVE { get; set; }

        public string GROUP { get; set; }

        public string MANUFACTURE_ID { get; set; }

        public string IMAGE_ID { get; set; }

        public string LONGDESC_ID { get; set; }

        public string VENDORINS_ID { get; set; }

        public string WAREHOUSEINS_ID { get; set; }

        public string ORDERINGINS_ID { get; set; }

        public string PAPER_STOCK_PRODUCT_CODE { get; set; }

        public int? PAPER_STOCK_QUANTITY_PER_SHEET { get; set; }

        public byte? COST_ONLY { get; set; }

        public string IMPRINT_TEMPLATE_ID { get; set; }

        public bool? DO_NOT_CREATE_AP { get; set; }

        public string REBATE_CODE { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}