using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblSummaryCustomers", Schema = "dbo")]
    public partial class TblSummaryCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldStore-RecordID")]
        [Required]
        public int fldStoreRecordID { get; set; }

        [Required]
        public DateTime fldDate { get; set; }

        [Column("fldNum-Address-Good")]
        public int? fldNumAddressGood { get; set; }

        [Column("fldNum-Address-New")]
        public int? fldNumAddressNew { get; set; }

        [Column("fldNum-Address-Blank")]
        public int? fldNumAddressBlank { get; set; }

        [Column("fldNum-Address-Bad")]
        public int? fldNumAddressBad { get; set; }

        [Column("fldNum-Address-Corrected")]
        public int? fldNumAddressCorrected { get; set; }

        [Column("fldNum-Email-Good")]
        public int? fldNumEmailGood { get; set; }

        [Column("fldNum-Email-New")]
        public int? fldNumEmailNew { get; set; }

        [Column("fldNum-Email-Blank")]
        public int? fldNumEmailBlank { get; set; }

        [Column("fldNum-Email-Bad")]
        public int? fldNumEmailBad { get; set; }

        [Column("fldNum-Mobile-Good")]
        public int? fldNumMobileGood { get; set; }

        [Column("fldNum-Mobile-New")]
        public int? fldNumMobileNew { get; set; }

        [Column("fldNum-Mobile-Blank")]
        public int? fldNumMobileBlank { get; set; }

        [Column("fldNum-Mobile-Bad")]
        public int? fldNumMobileBad { get; set; }

        [Column("fldNum-Customer-New")]
        public int? fldNumCustomerNew { get; set; }

        [Column("fldNum-Customer-Repeat")]
        public int? fldNumCustomerRepeat { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}