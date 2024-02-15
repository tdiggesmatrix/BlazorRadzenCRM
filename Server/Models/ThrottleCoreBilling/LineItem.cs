using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("Line_Item", Schema = "dbo")]
    public partial class LineItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string ITEM_CODE { get; set; }

        public string TRACKING { get; set; }

        public string PRODUCT { get; set; }

        public string PRODUCT_DESC_1 { get; set; }

        public string PRODUCT_DESC_2 { get; set; }

        public string PRODUCT_CATEGORY { get; set; }

        public string SPEC_REF { get; set; }

        public string REMARKS { get; set; }

        public string VENDOR { get; set; }

        public string VEND_Q_NUM { get; set; }

        public string VEND_J_NUM { get; set; }

        public string AP_SEQ { get; set; }

        public decimal? SELL_QUANTITY_ORDERED { get; set; }

        public decimal? SELL_QUANTITY_SHIPPED { get; set; }

        public string SELL_UNIT_OF_MEASURE { get; set; }

        public decimal? BUY_QUANTITY_ORDERED { get; set; }

        public decimal? BUY_QUANTITY_SHIPPED { get; set; }

        public string BUY_UNIT_OF_MEASURE { get; set; }

        public DateTime? DATE_ORDERED { get; set; }

        public DateTime? DATE_DUE { get; set; }

        public DateTime? DATE_FOLLOW_UP { get; set; }

        public string COST_CENTER { get; set; }

        public decimal? PRICE { get; set; }

        public decimal? COST { get; set; }

        public string SWITCHES { get; set; }

        public string TAX_EXEMPT { get; set; }

        public string SWITCHES2 { get; set; }

        public string ALT_GL_SALE { get; set; }

        public string JOB_NUMBER { get; set; }

        public DateTime? DATE_SHIPPED { get; set; }

        public DateTime? DATE_REORDER { get; set; }

        public string ALT_SALES_TAX { get; set; }

        public decimal? EXT_TAXABLE_AMOUNT { get; set; }

        public string GL_DIV { get; set; }

        public string MANUFACTURE_ID { get; set; }

        public byte? RESTRICT_RECORD { get; set; }

        public decimal? QUANTITY_RECEIVED { get; set; }

        public string IMAGE_ID { get; set; }

        public string LONGDESC_ID { get; set; }

        public string VENDORINS_ID { get; set; }

        public string WAREHOUSEINS_ID { get; set; }

        public string MASTER_ITEM_CODE { get; set; }

        public short? ITEM_ORDER { get; set; }

        public DateTime? DATE_SHIP_BY { get; set; }

        public string CUSTOM_SWITCHES { get; set; }

        public string IMPRINT_TEMPLATE_ID { get; set; }

        public string SHIP_TO_CONTACT_ID { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}