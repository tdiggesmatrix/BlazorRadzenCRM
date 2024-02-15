using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblData-Import-Stores", Schema = "dbo")]
    public partial class TblDataImportStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string fldDatabaseName { get; set; }

        public int? fldCompany_FK_ID { get; set; }

        public int? fldStore_FK_ID { get; set; }

        public bool? fldActive { get; set; }

        public string fldDealerCode { get; set; }

        public string fldDealerGroup { get; set; }

        public string fldParseMethod { get; set; }

        public string fldStore_ID { get; set; }

        public string fldDMS_Username { get; set; }

        public short? fldSysUserID { get; set; }

        public short? fldSysCompID { get; set; }

        public DateTime? fldSysDate_Created { get; set; }

        public DateTime? fldSysDate_LastModified { get; set; }

    }
}