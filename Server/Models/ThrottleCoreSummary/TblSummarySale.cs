using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblSummarySales", Schema = "dbo")]
    public partial class TblSummarySale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int fldRecordID { get; set; }

        [Column("fldStore-RecordID")]
        [Required]
        public int fldStoreRecordID { get; set; }

        [Required]
        public DateTime fldDate { get; set; }

        [Column("fldtot-GrossSales")]
        public decimal? fldtotGrossSales { get; set; }

        [Column("fldavg-GrossSales")]
        public decimal? fldavgGrossSales { get; set; }

        [Column("fldmed-GrossSales")]
        public decimal? fldmedGrossSales { get; set; }

        [Column("fldtot-NetSales")]
        public decimal? fldtotNetSales { get; set; }

        [Column("fldavg-NetSales")]
        public decimal? fldavgNetSales { get; set; }

        [Column("fldmed-NetSales")]
        public decimal? fldmedNetSales { get; set; }

        [Column("fldtot-Discounts")]
        public decimal? fldtotDiscounts { get; set; }

        [Column("fldavg-Discounts")]
        public decimal? fldavgDiscounts { get; set; }

        [Column("fldmed-Discounts")]
        public decimal? fldmedDiscounts { get; set; }

        [Column("fldtot-ServiceTime")]
        public TimeOnly? fldtotServiceTime { get; set; }

        [Column("fldavg-ServiceTime")]
        public TimeOnly? fldavgServiceTime { get; set; }

        [Column("fldmed-ServiceTime")]
        public TimeOnly? fldmedServiceTime { get; set; }

        [Column("fldtot-Sales-OilChangeInvoices")]
        public decimal? fldtotSalesOilChangeInvoices { get; set; }

        [Column("fldavg-Sales-OilChangeInvoices")]
        public decimal? fldavgSalesOilChangeInvoices { get; set; }

        [Column("fldmed-Sales-OilChangeInvoices")]
        public decimal? fldmedSalesOilChangeInvoices { get; set; }

        [Column("fldtot-Sales-NonOilChangeInvoices")]
        public decimal? fldtotSalesNonOilChangeInvoices { get; set; }

        [Column("fldavg-Sales-NonOilChangeInvoices")]
        public decimal? fldavgSalesNonOilChangeInvoices { get; set; }

        [Column("fldmed-Sales-NonOilChangeInvoices")]
        public decimal? fldmedSalesNonOilChangeInvoices { get; set; }

        [Column("fldtot-Sales-Customer-New")]
        public decimal? fldtotSalesCustomerNew { get; set; }

        [Column("fldavg-Sales-Customer-New")]
        public decimal? fldavgSalesCustomerNew { get; set; }

        [Column("fldmed-Sales-Customer-New")]
        public decimal? fldmedSalesCustomerNew { get; set; }

        [Column("fldtot-Sales-Customer-Repeat")]
        public decimal? fldtotSalesCustomerRepeat { get; set; }

        [Column("fldavg-Sales-Customer-Repeat")]
        public decimal? fldavgSalesCustomerRepeat { get; set; }

        [Column("fldmed-Sales-Customer-Repeat")]
        public decimal? fldmedSalesCustomerRepeat { get; set; }

        [Column("fldtot-Sales-Customer-Fleet")]
        public decimal? fldtotSalesCustomerFleet { get; set; }

        [Column("fldavg-Sales-Customer-Fleet")]
        public decimal? fldavgSalesCustomerFleet { get; set; }

        [Column("fldmed-Sales-Customer-Fleet")]
        public decimal? fldmedSalesCustomerFleet { get; set; }

        [Column("fldtot-Sales-Customer-Fleet-Non")]
        public decimal? fldtotSalesCustomerFleetNon { get; set; }

        [Column("fldavg-Sales-Customer-Fleet-Non")]
        public decimal? fldavgSalesCustomerFleetNon { get; set; }

        [Column("fldmed-Sales-Customer-Fleet-Non")]
        public decimal? fldmedSalesCustomerFleetNon { get; set; }

        [Column("fldnum-InvoiceCount")]
        public int? fldnumInvoiceCount { get; set; }

        [Column("fldnum-InvoiceCount-Discounts-With")]
        public int? fldnumInvoiceCountDiscountsWith { get; set; }

        [Column("fldnum-InvoiceCount-Discounts-Without")]
        public int? fldnumInvoiceCountDiscountsWithout { get; set; }

        [Column("fldnum-InvoiceCount-OilChange-With")]
        public int? fldnumInvoiceCountOilChangeWith { get; set; }

        [Column("fldnum-InvoiceCount-OilChange-Without")]
        public int? fldnumInvoiceCountOilChangeWithout { get; set; }

        [Column("fldnum-InvoiceCount-Customer-New")]
        public int? fldnumInvoiceCountCustomerNew { get; set; }

        [Column("fldnum-InvoiceCount-Customer-Repeat")]
        public int? fldnumInvoiceCountCustomerRepeat { get; set; }

        [Column("fldnum-InvoiceCount-Customer-Fleet")]
        public int? fldnumInvoiceCountCustomerFleet { get; set; }

        [Column("fldnum-InvoiceCount-Customer-Non-Fleet")]
        public int? fldnumInvoiceCountCustomerNonFleet { get; set; }

        [Column("fldpct-OilChange-vs-Non-OilChange")]
        public decimal? fldpctOilChangevsNonOilChange { get; set; }

        [Column("fldpct-New-vs-Repeat")]
        public decimal? fldpctNewvsRepeat { get; set; }

        [Column("fldpct-FleetNon-vs-Fleet")]
        public decimal? fldpctFleetNonvsFleet { get; set; }

        [Column("fldavg-Mileage-BetweenVisits")]
        public int? fldavgMileageBetweenVisits { get; set; }

        [Column("fldavg-Days-BetweenVisits")]
        public int? fldavgDaysBetweenVisits { get; set; }

        [Column("fldavg-Mileage-BetweenVisits-Fleet")]
        public int? fldavgMileageBetweenVisitsFleet { get; set; }

        [Column("fldavg-Days-BetweenVisits-Fleet")]
        public int? fldavgDaysBetweenVisitsFleet { get; set; }

        [Column("fldavg-Mileage-BetweenVisits-Fleet-non")]
        public int? fldavgMileageBetweenVisitsFleetnon { get; set; }

        [Column("fldavg-Days-BetweenVisits-Fleet-non")]
        public int? fldavgDaysBetweenVisitsFleetnon { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}