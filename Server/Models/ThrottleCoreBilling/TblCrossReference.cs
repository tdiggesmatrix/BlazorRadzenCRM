using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("tblCrossReference", Schema = "dbo")]
    public partial class TblCrossReference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string Brand { get; set; }

        public string SubBrand { get; set; }

        public string StoreNum { get; set; }

        public string Nickname { get; set; }

        public string Address { get; set; }

        [Column("City-Province")]
        public string CityProvince { get; set; }

        public string PRODUCT_DESC_2 { get; set; }

        public string Dealercode { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}