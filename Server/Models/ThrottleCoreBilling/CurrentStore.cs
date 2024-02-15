using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("CurrentStores", Schema = "dbo")]
    public partial class CurrentStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string BRAND { get; set; }

        public string SUB_BRAND { get; set; }

        public string STORE { get; set; }

        public string STORE_INFO_1 { get; set; }

        public string STORE_INFO_2 { get; set; }

        public string STORE_INFO_3 { get; set; }

        public string CUSTOMER { get; set; }

        public string BILLING_CUSTOMER { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}