using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Customer
{
    [Table("tblCustomer-Industry-Stores-Join", Schema = "dbo")]
    public partial class TblCustomerIndustryStoresJoin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldCustomer-RecordID")]
        [Required]
        public int fldCustomerRecordID { get; set; }

        [Column("fldCustomer-Industry-RecordID")]
        [Required]
        public int fldCustomerIndustryRecordID { get; set; }

        [Column("fldCustomer-Stores-RecordID")]
        public int? fldCustomerStoresRecordID { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}