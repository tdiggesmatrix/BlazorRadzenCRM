using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("settings_configuration", Schema = "dbo")]
    public partial class SettingsConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string dealercode { get; set; }

        public string parsemethod { get; set; }

        public string compensation_dmsid { get; set; }

        public string compensation_distributorid { get; set; }

        public string compensation_insightid { get; set; }

        public string billingcode_campaigns_email { get; set; }

        public string billingcode_newsletters_email { get; set; }

        public string billingcode_reminders_email { get; set; }

        public string billingcode_reminders_messaging { get; set; }

        public string rebate { get; set; }

        public string association_affiliation { get; set; }

        public string store_id { get; set; }

        public string dms_username { get; set; }

        public string graphic_logo { get; set; }

        public string mail_piece_templates { get; set; }

        public string global_catalog { get; set; }

        public int? report_week { get; set; }

        public string distance_unit { get; set; }

        public int? satellite { get; set; }

        public string smtp_domain { get; set; }

        public string classicplus_accountid { get; set; }

        public string classicplus_userid { get; set; }

        public string classicplus_password { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}