using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("settings_contact", Schema = "dbo")]
    public partial class SettingsContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string dealercode { get; set; }

        public int? clientstatus { get; set; }

        public string dealergroup { get; set; }

        public string franchisegroup { get; set; }

        public string corporatename { get; set; }

        public string displayname { get; set; }

        public string printname { get; set; }

        public string brandname { get; set; }

        public string manager { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip { get; set; }

        public double? latitude { get; set; }

        public double? longitude { get; set; }

        public string countrycode { get; set; }

        public string google_placeid { get; set; }

        public string phone { get; set; }

        public string website { get; set; }

        public string email_contact { get; set; }

        public string email_marketing { get; set; }

        public string email_reports { get; set; }

        public string return_address { get; set; }

        public string return_city { get; set; }

        public string return_state { get; set; }

        public string return_zip { get; set; }

        public string hours_1 { get; set; }

        public string hours_2 { get; set; }

        public string hours_3 { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}