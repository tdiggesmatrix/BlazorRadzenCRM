using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Activity
{
    [Table("tblMessage_PhoneNumbers", Schema = "dbo")]
    public partial class TblMessagePhoneNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fldRecordID { get; set; }

        public string fldAccountSid { get; set; }

        public string fldApiVersion { get; set; }

        public string fldBeta { get; set; }

        public string fldBundleSid { get; set; }

        public string fldCapabilities { get; set; }

        public DateTime? fldDateCreated { get; set; }

        public DateTime? fldDateUpdated { get; set; }

        public string fldddressRequirements { get; set; }

        public string fldEmergencyAddressSid { get; set; }

        public string fldEmergencyAddressStatus { get; set; }

        public string fldEmergencyStatus { get; set; }

        public string fldFriendlyName { get; set; }

        public string fldIdentitySid { get; set; }

        public string fldOrigin { get; set; }

        public string fldPhoneNumber { get; set; }

        public string fldSid { get; set; }

        public string fldSmsApplicationSid { get; set; }

        public string fldSmsFallbackMethod { get; set; }

        public string fldSmsFallbackUrl { get; set; }

        public string fldSmsMethod { get; set; }

        public string fldSmsUrl { get; set; }

        public string fldStatus { get; set; }

        public string fldStatusCallback { get; set; }

        public string fldStatusCallbackMethod { get; set; }

        public string fldTrunkSid { get; set; }

        public string fldUri { get; set; }

        public string fldVoiceApplicationSid { get; set; }

        public string fldVoiceCallerIdLookup { get; set; }

        public string fldVoiceFallbackMethod { get; set; }

        public string fldVoiceFallbackUrl { get; set; }

        public string fldVoiceMethod { get; set; }

        public string fldVoiceReceiveMode { get; set; }

        public string fldVoiceUrl { get; set; }

        public string fldStore { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}