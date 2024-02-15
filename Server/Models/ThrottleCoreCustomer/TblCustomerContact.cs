using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Customer
{
    [Table("tblCustomer-Contacts", Schema = "dbo")]
    public partial class TblCustomerContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string fldFullName { get; set; }

        public string fldFirstName { get; set; }

        public string fldLastName { get; set; }

        public string fldEmail { get; set; }

        public string fldWorkEmail { get; set; }

        public string fldAddress1 { get; set; }

        public string fldAddress2 { get; set; }

        public string fldAddress3 { get; set; }

        public string fldCity { get; set; }

        public string fldState { get; set; }

        public string fldPostalCode { get; set; }

        public string fldCountry { get; set; }

        public string fldPhone { get; set; }

        public string fldAlternatePhone { get; set; }

        public string fldMobilePhone { get; set; }

        public string fldLinkedInProfile { get; set; }

        public string fldJobfunction { get; set; }

        public string fldJobTitle { get; set; }

        public string fldIndustry { get; set; }

        public string fldVertical { get; set; }

        public string fldEmailDomain { get; set; }

        public bool? fldEmailConfirmed { get; set; }

        public string fldContactowner { get; set; }

        public string fldClientCode { get; set; }

        public string fldWebsiteUrl { get; set; }

        public decimal? fldLatitude { get; set; }

        public decimal? fldLongitude { get; set; }

        [Column("fldCompany-GooglePlacesID")]
        public string fldCompanyGooglePlacesID { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}