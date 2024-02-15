using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThrottleCoreCRM.Server.Models.Throttle_Core_Summary
{
    [Table("tblDailyTotals", Schema = "dbo")]
    public partial class TblDailyTotal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fldRecordID { get; set; }

        [Column("fldCustomer-RecordID")]
        public int? fldCustomerRecordID { get; set; }

        [Column("fldCustomer-Stores-RecordID")]
        public int? fldCustomerStoresRecordID { get; set; }

        [Required]
        public DateTime fldDate { get; set; }

        public decimal? fldTotalSales { get; set; }

        public decimal? fldServiceParts { get; set; }

        public decimal? fldServiceLabor { get; set; }

        public decimal? fldNonServiceParts { get; set; }

        public decimal? fldNonServiceLabor { get; set; }

        public decimal? fldDiscounts { get; set; }

        public short? fldNumDiscounts { get; set; }

        public decimal? fldCoupons { get; set; }

        public short? fldNumCoupons { get; set; }

        public decimal? fldRefundsBeforeTax { get; set; }

        public decimal? fldRefundsAfterTax { get; set; }

        public short? fldNumRefunds { get; set; }

        public decimal? fldNetSales { get; set; }

        public decimal? fldTaxableTotal { get; set; }

        public decimal? fldNonTaxableTotal { get; set; }

        public decimal? fldTaxExemptTotal { get; set; }

        public decimal? fldGiftCardTotal { get; set; }

        public short? fldNumGiftCardTotal { get; set; }

        public double? fldPercentGiftCardTotal { get; set; }

        public double? fldAvgGiftCardTotal { get; set; }

        public decimal? fldSalesTax { get; set; }

        public decimal? fldSalesTaxCollected { get; set; }

        public decimal? fldSalesTaxCollected1 { get; set; }

        public decimal? fldSalesTaxCollected2 { get; set; }

        public decimal? fldSalesTaxRefunded { get; set; }

        public decimal? fldSalesTaxRefunded1 { get; set; }

        public decimal? fldSalesTaxRefunded2 { get; set; }

        public decimal? fldSalesTaxExempt { get; set; }

        public decimal? fldSalesTaxExempt1 { get; set; }

        public decimal? fldSalesTaxExempt2 { get; set; }

        public short? fldNumSalesTaxExempt { get; set; }

        public decimal? fldFleetPayments { get; set; }

        public short? fldNumFleetPayments { get; set; }

        public decimal? fldPaidIn { get; set; }

        public short? fldNumPaidIn { get; set; }

        public decimal? fldPaidOut { get; set; }

        public short? fldNumPaidOut { get; set; }

        public decimal? fldTotalReceipts { get; set; }

        public decimal? fldFleetSales { get; set; }

        public short? fldNumFleetSales { get; set; }

        public decimal? fldDayEndAddOns { get; set; }

        public decimal? fldTotalBalance { get; set; }

        public decimal? fldCashOverShort { get; set; }

        public decimal? fldChangeFund { get; set; }

        public decimal? fldLeftInDrawer { get; set; }

        public decimal? fldBankDeposit { get; set; }

        public decimal? fldLaborSalesTotal { get; set; }

        public double? fldLaborHours { get; set; }

        public double? fldLaborHoursPerVehicle { get; set; }

        public decimal? fldLaborSalesPerHour { get; set; }

        public decimal? fldInvoiceSubTotal { get; set; }

        public decimal? fldInvoiceTotal { get; set; }

        public short? fldNumInvoice { get; set; }

        public decimal? fldCostInvoiceTotal { get; set; }

        public double? fldProfitInvoiceTotal { get; set; }

        public double? fldAvgInvoiceTotal { get; set; }

        public short? fldVehicleAvgAge { get; set; }

        public int? fldVehicleAvgMileage { get; set; }

        public int? fldInvoiceStart { get; set; }

        public int? fldInvoiceEnd { get; set; }

        public short? fldAvgInvoiceWait { get; set; }

        public decimal? fldQuickSaleTotal { get; set; }

        public short? fldNumQuickSale { get; set; }

        public decimal? fldCostQuickSaleTotal { get; set; }

        public double? fldProfitQuickSaleTotal { get; set; }

        public double? fldAvgQuickSaleTotal { get; set; }

        public decimal? fldAvgTotalNetSale { get; set; }

        public double? fldTotalRepeat { get; set; }

        public decimal? fldInventoryEnd { get; set; }

        public decimal? fldInventoryRestocked { get; set; }

        public decimal? fldInventoryOrdered { get; set; }

        public decimal? fldInventoryOutPurch { get; set; }

        public decimal? fldSalesWithoutTax { get; set; }

        public decimal? fldCostOfSales { get; set; }

        public decimal? fldGrossProfit { get; set; }

        public decimal? fldEstimatedLabor { get; set; }

        public decimal? fldEstimatedProfit { get; set; }

        public decimal? fldAROpen { get; set; }

        public decimal? fldARDebit { get; set; }

        public decimal? fldARInterest { get; set; }

        public decimal? fldARPaymentDiscouts { get; set; }

        public decimal? fldARCredits { get; set; }

        public decimal? fldClerkTotalBalance { get; set; }

        public float? fldTotalRepeatPercent { get; set; }

        public int? fldTotalFirstTime { get; set; }

        public decimal? fldInventoryAdjusted { get; set; }

        public int? fldNumVoids { get; set; }

        public int? fldNumBayDelete { get; set; }

        public decimal? fldOverHead { get; set; }

        public decimal? fldSalesAmount5 { get; set; }

        public int? fldSalesCount5 { get; set; }

        public decimal? fldSalesAmount10 { get; set; }

        public int? fldSalesCount10 { get; set; }

        public decimal? fldSalesAmount15 { get; set; }

        public int? fldSalesCount15 { get; set; }

        public decimal? fldSalesAmount20 { get; set; }

        public int? fldSalesCount20 { get; set; }

        public decimal? fldSalesAmount30 { get; set; }

        public int? fldSalesCount30 { get; set; }

        public decimal? fldSalesAmount40 { get; set; }

        public int? fldSalesCount40 { get; set; }

        public decimal? fldAmtVoids { get; set; }

        public int? fldPrevRefundInvCount { get; set; }

        public decimal? fldPrevRefundInvAmt { get; set; }

        public int? fldPrevRefundQSCount { get; set; }

        public decimal? fldPrevRefundQSAmt { get; set; }

        public decimal? fldGCOnlyAmount { get; set; }

        public int? fldGCOnlyCount { get; set; }

        public decimal? fldGCOnlyAmountQS { get; set; }

        public int? fldGCOnlyCountQS { get; set; }

        public decimal? fldGiftCardTotalQS { get; set; }

        public short? fldNumGiftCardTotalQS { get; set; }

        public int? fldCashierCount { get; set; }

        public int? fldCashierTime { get; set; }

        public int? fldBay1Count { get; set; }

        public int? fldBay1Time { get; set; }

        public int? fldBay2Count { get; set; }

        public int? fldBay2Time { get; set; }

        public int? fldBay3Count { get; set; }

        public int? fldBay3Time { get; set; }

        public int? fldBay4Count { get; set; }

        public int? fldBay4Time { get; set; }

        public int? fldBusinessGroupListIDPK { get; set; }

        public short fldSysUserID { get; set; }

        public short fldSysCompID { get; set; }

        public DateTime fldSysDate_Created { get; set; }

        public DateTime fldSysDate_LastModified { get; set; }

    }
}