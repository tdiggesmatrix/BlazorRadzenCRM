using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblSummaryCampaigns", Schema = "dbo")]
    public partial class TblSummaryCampaign
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldStore-RecordID")]
        [Required]
        public int fldStoreRecordID { get; set; }

        [Required]
        public DateTime fldDate { get; set; }

        [Column("fldNum-Card-ToBeSent")]
        public int? fldNumCardToBeSent { get; set; }

        [Column("fldNum-Card-NotNeeded")]
        public int? fldNumCardNotNeeded { get; set; }

        [Column("fldNum-Card-Address-Corrected")]
        public int? fldNumCardAddressCorrected { get; set; }

        [Column("fldNum-Card-Address-Bad")]
        public int? fldNumCardAddressBad { get; set; }

        [Column("fldNum-Card-Address-Blank")]
        public int? fldNumCardAddressBlank { get; set; }

        [Column("fldNum-Card-Sent")]
        public int? fldNumCardSent { get; set; }

        [Column("fldCost-Card-Sent")]
        public decimal? fldCostCardSent { get; set; }

        [Column("fldSales-Card-Sent")]
        public decimal? fldSalesCardSent { get; set; }

        [Column("fldNum-Email-ToBeSent")]
        public int? fldNumEmailToBeSent { get; set; }

        [Column("fldNum-Email-NotNeeded")]
        public int? fldNumEmailNotNeeded { get; set; }

        [Column("fldNum-Email-Address-Verified")]
        public int? fldNumEmailAddressVerified { get; set; }

        [Column("fldNum-Email-Address-Bad")]
        public int? fldNumEmailAddressBad { get; set; }

        [Column("fldNum-Email-Address-Blank")]
        public int? fldNumEmailAddressBlank { get; set; }

        [Column("fldNum-Email-Sent")]
        public int? fldNumEmailSent { get; set; }

        [Column("fldCost-Email-Sent")]
        public decimal? fldCostEmailSent { get; set; }

        [Column("fldSales-Email-Sent")]
        public decimal? fldSalesEmailSent { get; set; }

        [Column("fldNum-SMS-ToBeSent")]
        public int? fldNumSMSToBeSent { get; set; }

        [Column("fldNum-SMS-NotNeeded")]
        public int? fldNumSMSNotNeeded { get; set; }

        [Column("fldNum-SMS-Address-Verified")]
        public int? fldNumSMSAddressVerified { get; set; }

        [Column("fldNum-SMS-Address-Bad")]
        public int? fldNumSMSAddressBad { get; set; }

        [Column("fldNum-SMS-Address-Blank")]
        public int? fldNumSMSAddressBlank { get; set; }

        [Column("fldNum-SMS-Sent")]
        public int? fldNumSMSSent { get; set; }

        [Column("fldNum-SMS-Segments-Sent")]
        public int? fldNumSMSSegmentsSent { get; set; }

        [Column("fldCost-SMS-Sent")]
        public decimal? fldCostSMSSent { get; set; }

        [Column("fldSales-SMS-Sent")]
        public decimal? fldSalesSMSSent { get; set; }

        [Column("fldNum-MMS-ToBeSent")]
        public int? fldNumMMSToBeSent { get; set; }

        [Column("fldNum-MMS-NotNeeded")]
        public int? fldNumMMSNotNeeded { get; set; }

        [Column("fldNum-MMS-Address-Verified")]
        public int? fldNumMMSAddressVerified { get; set; }

        [Column("fldNum-MMS-Address-Bad")]
        public int? fldNumMMSAddressBad { get; set; }

        [Column("fldNum-MMS-Address-Blank")]
        public int? fldNumMMSAddressBlank { get; set; }

        [Column("fldNum-MMS-Sent")]
        public int? fldNumMMSSent { get; set; }

        [Column("fldNum-MMS-Segments-Sent")]
        public int? fldNumMMSSegmentsSent { get; set; }

        [Column("fldCost-MMS-Sent")]
        public decimal? fldCostMMSSent { get; set; }

        [Column("fldSales-MMS-Sent")]
        public decimal? fldSalesMMSSent { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}