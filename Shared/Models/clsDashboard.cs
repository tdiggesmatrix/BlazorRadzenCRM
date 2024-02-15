using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrottleCoreCRM.Shared.Models
{
    public class clsStats
    {
        public DateTime Month { get; set; }
        public decimal Revenue { get; set; }
        public int Opportunities { get; set; }
        public decimal AverageDealSize { get; set; }
        public double Ratio { get; set; }
    }

    public class clsRevenueByCompany
    {
        public string Company { get; set; }
        public decimal Revenue { get; set; }
    }

    public class clsRevenueByEmployee
    {
        public string Employee { get; set; }
        public decimal Revenue { get; set; }
    }

    public class clsRevenueByMonth
    {
        public DateTime Month { get; set; }
        public decimal Revenue { get; set; }
    }
    public class clsDailySalesStats
    {
        public DateTime DateofSales { get; set; }

        public decimal Daily_SalesAmount { get; set; }
        public int Daily_InvoiceCount { get; set; }
        public decimal Daily_Avg_SalesAmount { get; set; }
        public decimal Daily_Med_SalesAmount { get; set; }

        public decimal WTD_SalesAmount { get; set; }
        public int WTD_InvoiceCount { get; set; }
        public int WTD_Index { get; set; }
        public decimal WTD_Avg_SalesAmount { get; set; }
        public decimal WTD_Med_SalesAmount { get; set; }

        public decimal MTD_SalesAmount { get; set; }
        public int MTD_InvoiceCount { get; set; }
        public int MTD_Index { get; set; }
        public decimal MTD_Avg_SalesAmount { get; set; }
        public decimal MTD_Med_SalesAmount { get; set; }

        public decimal YTD_SalesAmount { get; set; }
        public int YTD_InvoiceCount { get; set; }
        public int YTD_Index { get; set; }
        public decimal YTD_Avg_SalesAmount { get; set; }
        public decimal YTD_Med_SalesAmount { get; set; }

        public decimal DOD_SalesAmount { get; set; }
        public int DOD_InvoiceCount { get; set; }
        public decimal DOD_Avg_SalesAmount { get; set; }
        public decimal DOD_Med_SalesAmount { get; set; }
        public int DOD_Index { get; set; }

        public decimal WOW_SalesAmount { get; set; }
        public int WOW_InvoiceCount { get; set; }
        public decimal WOW_Avg_SalesAmount { get; set; }
        public decimal WOW_Med_SalesAmount { get; set; }
        public int WOW_Index { get; set; }

        public decimal MOM_SalesAmount { get; set; }
        public int MOM_InvoiceCount { get; set; }
        public decimal MOM_Avg_SalesAmount { get; set; }
        public decimal MOM_Med_SalesAmount { get; set; }
        public int MOM_Index { get; set; }

        public decimal YOY_SalesAmount { get; set; }
        public int YOY_InvoiceCount { get; set; }
        public decimal YOY_Avg_SalesAmount { get; set; }
        public decimal YOY_Med_SalesAmount { get; set; }
        public int YOY_Index { get; set; }

    }

}
