using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblSummaryVehicles", Schema = "dbo")]
    public partial class TblSummaryVehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldStore-RecordID")]
        [Required]
        public int fldStoreRecordID { get; set; }

        [Required]
        public DateTime fldDate { get; set; }

        [Column("fldVehicle-Year")]
        [Required]
        public short fldVehicleYear { get; set; }

        [Column("fldVehicle-Make")]
        [Required]
        public string fldVehicleMake { get; set; }

        [Column("fldVehicle-Model")]
        [Required]
        public string fldVehicleModel { get; set; }

        [Column("fldVehicle-Count")]
        [Required]
        public int fldVehicleCount { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}