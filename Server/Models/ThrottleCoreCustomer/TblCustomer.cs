using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Customer
{
    [Table("tblCustomer", Schema = "dbo")]
    public partial class TblCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldCompany-Name")]
        public string fldCompanyName { get; set; }

        public string fldDoingBusinessAs { get; set; }

        public string fldAddress1 { get; set; }

        public string fldAddress2 { get; set; }

        public string fldAddress3 { get; set; }

        public string fldCity { get; set; }

        public string fldState { get; set; }

        public string fldZip { get; set; }

        public string fldCountry { get; set; }

        public string fldPhone { get; set; }

        public string fldAlternatePhone { get; set; }

        public string fldFax { get; set; }

        public string fldWebsiteUrl { get; set; }

        public string fldGeneralEmailAddress { get; set; }

        public string fldAlternateEmailAddress { get; set; }

        public bool? fldActive { get; set; }

        public decimal? fldLatitude { get; set; }

        public decimal? fldLongitude { get; set; }

        [Column("fldCompany-GooglePlacesID")]
        public string fldCompanyGooglePlacesID { get; set; }

        [Column("fldAccounting-Interface-ID")]
        public string fldAccountingInterfaceID { get; set; }

        [Column("fldCustomer-StartDate")]
        public DateTime? fldCustomerStartDate { get; set; }

        [Column("fldCustomer-EndDate")]
        public DateTime? fldCustomerEndDate { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}