using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Customer
{
    [Table("tblCustomer-Groups", Schema = "dbo")]
    public partial class TblCustomerGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldCustomer-RecordID")]
        [Required]
        public int fldCustomerRecordID { get; set; }

        [Required]
        public string fldGroupName { get; set; }

        public string fldNotes { get; set; }

        public bool? fldActive { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}