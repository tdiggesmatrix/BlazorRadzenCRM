using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("Product_Category", Schema = "dbo")]
    public partial class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string PRODUCT_CATEGORY_CODE { get; set; }

        public string PRODUCT_CATEGORY_DESC { get; set; }

        public string CATEGORY_SHORT_DESC { get; set; }

        public short? SPECIAL_COMMISSION_SELECT { get; set; }

        public string ALT_GL_SALES_REF { get; set; }

        public string ALT_GL_PURCHASE_REF { get; set; }

        public string SWITCHES { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}