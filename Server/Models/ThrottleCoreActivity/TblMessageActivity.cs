using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblMessage_Activity", Schema = "dbo")]
    public partial class TblMessageActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fldRecordID { get; set; }

        public string fldAccountSID { get; set; }

        public string fldApiVersion { get; set; }

        public string fldBody { get; set; }

        public DateTime? fldDateCreated { get; set; }

        public DateTime? fldDateSent { get; set; }

        public DateTime? fldDateUpdated { get; set; }

        public string fldDirection { get; set; }

        public string fldErrorCode { get; set; }

        public string fldErrorMessage { get; set; }

        public string fldFromNumber { get; set; }

        public string fldMessagingServiceSID { get; set; }

        public int? fldNumMedia { get; set; }

        public int? fldNumSegments { get; set; }

        public decimal? fldPrice { get; set; }

        public string fldPriceUnit { get; set; }

        public string fldSid { get; set; }

        public string fldStatus { get; set; }

        public string fldSubbresourceUris { get; set; }

        public string fldToNumber { get; set; }

        public string fldUri { get; set; }

        public decimal? fldCarrierFees { get; set; }

        public decimal? fldCampaignFees { get; set; }

        public decimal? fldPhoneNumberFees { get; set; }

        public int? fldErrorNotificationID { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}