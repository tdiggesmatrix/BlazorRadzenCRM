using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Customer
{
    [Table("tblCustomerStores", Schema = "dbo")]
    public partial class TblCustomerStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public int? fldCustomerRecordID { get; set; }

        public string fldStoreName { get; set; }

        public string fldDBA { get; set; }

        public int? fldStoreNumber { get; set; }

        public string fldStoreNumberLiteral { get; set; }

        public string fldStoreNickName { get; set; }

        public string fldAddress1 { get; set; }

        public string fldAddress2 { get; set; }

        public string fldAddress3 { get; set; }

        public string fldCity { get; set; }

        public string fldState { get; set; }

        public string fldZip { get; set; }

        public string fldCountry { get; set; }

        public string fldPhone { get; set; }

        public string fldFax { get; set; }

        public string fldStoreWebsiteUrl { get; set; }

        public string fldStoreGeneralEmailAddress { get; set; }

        public string fldStoreAlternateEmail { get; set; }

        public bool? fldActive { get; set; }

        public decimal? fldLatitude { get; set; }

        public decimal? fldLongitude { get; set; }

        public string fldCompanyGooglePlacesID { get; set; }

        public string fldHours1 { get; set; }

        public string fldHours2 { get; set; }

        public string fldHours3 { get; set; }

        public short? fldOpenHoursPerDay { get; set; }

        public short? fldOpenHoursPerWeek { get; set; }

        public int? fldDMSProviderRecordID { get; set; }

        public string fldAccountingInterfaceID { get; set; }

        public string fldThrottleInterfaceID { get; set; }

        public string fldSOPUSNumber { get; set; }

        public DateTime? fldStoreOpenedDate { get; set; }

        public DateTime? fldStoreClosedDate { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}