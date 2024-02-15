using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Billing
{
    [Table("reminders_settings_admin", Schema = "dbo")]
    public partial class RemindersSettingsAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        public string dealercode { get; set; }

        public string processweeks { get; set; }

        public string seed_mail { get; set; }

        public string seed_name { get; set; }

        public string seed_address { get; set; }

        public string seed_city { get; set; }

        public string seed_state { get; set; }

        public string seed_zip { get; set; }

        public string seed_email { get; set; }

        public string seed_emailaddress { get; set; }

        public string globalcatalogusers { get; set; }

        public int? email_send_day { get; set; }

        public string email_reply_address { get; set; }

        public string barcode_format { get; set; }

        public string messaging_accountSID { get; set; }

        public string messaging_bannerplacements { get; set; }

        public int? newsletters_enabled { get; set; }

        public int? servicerecommendations_video_enabled { get; set; }

        public string servicerecommendations_video_provider { get; set; }

        public string weekly_budget_apportion { get; set; }

        public int? weekly_budget_limit { get; set; }

        public int? weekly_budget_mail_6 { get; set; }

        public int? weekly_budget_mail_9 { get; set; }

        public int? weekly_budget_mail_14 { get; set; }

        public int? weekly_budget_email { get; set; }

        public int? weekly_budget_sms { get; set; }

        public string weekly_budget_priority { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}