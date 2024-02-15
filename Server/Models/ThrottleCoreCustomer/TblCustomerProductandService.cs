using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Customer
{
    [Table("tblCustomer-ProductandServices", Schema = "dbo")]
    public partial class TblCustomerProductandService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public bool? fldProduct { get; set; }

        public bool? fldService { get; set; }

        public string fldProductName { get; set; }

        public string fldServiceName { get; set; }

        public bool? fldActive { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}