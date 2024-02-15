using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblDataImportVerification", Schema = "dbo")]
    public partial class TblDataImportVerification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public int? fldCompany_RecordID { get; set; }

        public int? fldStore_RecordID { get; set; }

        public DateTime? fldfile_date { get; set; }

        public string fldfile_name { get; set; }

        public int? fldpostype_RecordID { get; set; }

        public int? fldfiletype_Record_ID { get; set; }

        public string fldstore_id { get; set; }

        public string fldstore_number { get; set; }

        public int? fldproduct_Record_ID { get; set; }

        public int? fldInvoiceCount { get; set; }

        public decimal? fldInvoiceSum { get; set; }

        public short? fldSysUserID { get; set; }

        public short? fldSysCompID { get; set; }

        public DateTime? fldSysDate_Created { get; set; }

        public DateTime? fldSysDate_LastModified { get; set; }

    }
}