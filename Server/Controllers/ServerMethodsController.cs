using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ThrottleCoreCRM.Server.Models;
using ThrottleCoreCRM.Server.Models.Throttle_Core_WebSite;
using ThrottleCoreCRM.Client.Pages;
using ThrottleCoreCRM.Server.Data;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

using System.Globalization;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Bibliography;
//Shane added this line here 
using ThrottleCoreCRM.Server.Controllers.Throttle_Core_Summary;

namespace Throttle_Core_CRM.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ServerMethodsController : Controller
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext webSiteContext; //  context;


        public ServerMethodsController(ThrottleCoreCRM.Server.Data.Throttle_Core_WebSiteContext context)
        {
            this.webSiteContext = context;
        }

        public IActionResult Iact_MonthlyStats()
        {
            double wonOpportunities = webSiteContext.Opportunities
                                .Include(opportunity => opportunity.OpportunityStatus)
                                .Where(opportunity => opportunity.OpportunityStatus.Name == "Won")
                                .Count();

            var totalOpportunities = webSiteContext.Opportunities.Count();

            var ratio = wonOpportunities / totalOpportunities;

            var stats = webSiteContext.Opportunities
                                .Include(opportunity => opportunity.OpportunityStatus)
                                .Where(opportunity => opportunity.OpportunityStatus.Name == "Won")
                                .ToList()
                                .GroupBy(opportunity => new DateTime(opportunity.CloseDate.Year, opportunity.CloseDate.Month, 1))
                                .Select(group => new
                                {
                                    Month = group.Key,
                                    Revenue = group.Sum(opportunity => opportunity.Amount),
                                    Opportunities = group.Count(),
                                    AverageDealSize = group.Average(opportunity => opportunity.Amount),
                                    Ratio = ratio
                                })
                                .OrderBy(deals => deals.Month)
                                .LastOrDefault();
            return Ok(System.Text.Json.JsonSerializer.Serialize(stats, new System.Text.Json.JsonSerializerOptions { PropertyNamingPolicy = null }));
        }

        public IActionResult Iact_RevenueByCompany()
        {
            var result = webSiteContext.Opportunities
                                .Include(opportunity => opportunity.Contact)
                                .ToList()
                                .GroupBy(opportunity => opportunity.Contact.Company)
                                .Select(group => new {
                                        Company = group.Key,
                                        Revenue = group.Sum(opportunity => opportunity.Amount)
                                });

            return Ok(System.Text.Json.JsonSerializer.Serialize(result, new System.Text.Json.JsonSerializerOptions
            {
                    PropertyNamingPolicy = null
            }));
        }

        public IActionResult Iact_RevenueByEmployee()
        {
            var result = webSiteContext.Opportunities
                                .Include(opportunity => opportunity.UserId)
                                .ToList()
                                .GroupBy(opportunity => $"{opportunity.Contact.FirstName} {opportunity.Contact.LastName}")
                                .Select(group => new
                                {
                                    Employee = group.Key,
                                    Revenue = group.Sum(opportunity => opportunity.Amount)
                                });


            return Ok(System.Text.Json.JsonSerializer.Serialize(result, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            }));
        }

        public IActionResult Iact_RevenueByMonth()
        {

            var result = webSiteContext.Opportunities
                                .Include(opportunity => opportunity.OpportunityStatus)
                                .Where(opportunity => opportunity.OpportunityStatus.Name == "Won")
                                .ToList()
                                .GroupBy(opportunity => new DateTime(opportunity.CloseDate.Year, opportunity.CloseDate.Month, 1))
                                .Select(group => new {
                                    Revenue = group.Sum(opportunity => opportunity.Amount),
                                    Month = group.Key
                                })
                                .OrderBy(deals => deals.Month);

            return Ok(System.Text.Json.JsonSerializer.Serialize(result, new System.Text.Json.JsonSerializerOptions
            {
                    PropertyNamingPolicy = null
            }));
        }

        //Shane - New section to get daily sales statistics
        public IActionResult IAct_GetEmployeesWithDepartment()
        {
            // Step 2
            var employees = webSiteContext.SP_GetEmployeesWithDepartment(2)
                                .ToList()
                                .Select(group => new
                                {
                                    ID = group.Id,
                                    Name = group.Name,
                                    DepartmentID = group.DepartmentId,
                                    ManagerID = group.ManagerId,
                                    Salary = group.Salary,
                                    Bonus = group.Bonus,
                                    Department = group.Department
                                })
                                .OrderBy(group => group.ID)
                                .LastOrDefault();

            return Ok(System.Text.Json.JsonSerializer.Serialize(employees, new System.Text.Json.JsonSerializerOptions 
            { 
                PropertyNamingPolicy = null 
            }));
        }


        //This section of values would be passed to the procedcure

        //int wID = 1;
        //int cID = 1;
        //DateTime sdt = DateTime.ParseExact("11/13/2023", "M/d/yyyy", CultureInfo.InvariantCulture);
        //DateTime edt = DateTime.ParseExact("11/13/2023", "M/d/yyyy", CultureInfo.InvariantCulture);
        //string strs = "1";
        //string grp = "1,2,3,4";
        //int swd = 1;
        //int act = 0;
        //var TransactionClassId = new SqlParameter("@TransactionClassId", 3);

        //var DailyStats1 = sumDBContext.usp_GetDashboardValues
        //    .FromSql("EXECUTE dbo.Reporting_Monthly_Totals @TransactionClassId;", TransactionClassId)
        //    .ToList();

        //var sqlParams = new SqlParameter[]
        //{
        //    new SqlParameter("@WebUserID", wID),
        //    new SqlParameter("@CustomerID", cID),
        //    new SqlParameter("@StartDate", sdt),
        //    new SqlParameter("@EndDate", edt),
        //    new SqlParameter("@Stores", strs),
        //    new SqlParameter("@Groups", grp),
        //    new SqlParameter("@StartOfWeekDay", swd),
        //    new SqlParameter("@ActiveOnly", act)
        //};

        //  or

        //var WebUserID = new SqlParameter("@WebUserID", wID); 
        //var CustomerID = new SqlParameter("@CustomerID", cID);
        //var StartDate = new SqlParameter("@StartDate", sdt);
        //var EndDate = new SqlParameter("@EndDate", edt);
        //var Stores = new SqlParameter("@Stores", strs);
        //var Groups = new SqlParameter("@Groups", grp);
        //var StartOfWeekDay = new SqlParameter("@StartOfWeekDay", swd);
        //var ActiveOnly = new SqlParameter("@ActiveOnly", act);


        //// OK to use the same names as for the SqlParameter identifiers. Does not interfere.
        //var sql = "SpGetDashboardValues " + String.Join(", ", sqlParams.Select(x =>
        //  $"@{x.ParameterName} = @{x.ParameterName}" +
        //  (x.Direction == ParameterDirection.Output ? " OUT" : "")
        //  ));
        //sumDBContext..Database.ExecuteSqlRaw(sql, sqlParams);
        //var outputId = (int)(sqlParams.First(p => p.Direction == ParameterDirection.Output).Value);



        //''context.Database.ExecuteSqlCommand("myprocedure @p1, @p2", dt1, dt2);

        //var DailyStats = sumDBContext.usp_GetDashboardValues  
        //            .FromSql("SpGetDashboardValues @CategoryID, @WebUserID, @CustomerID, @StartDate, @EndDate, @Stores, @Groups, @StartOfWeekDay, @ActiveOnly",
        //                        new SqlParameter("@WebUserID", wID),
        //                        new SqlParameter("@CustomerID", cID),
        //                        new SqlParameter("@StartDate", sdt),
        //                        new SqlParameter("@EndDate", edt),
        //                        new SqlParameter("@Stores", strs),
        //                        new SqlParameter("@Groups", grp),
        //                        new SqlParameter("@StartOfWeekDay", swd),
        //                        new SqlParameter("@ActiveOnly", act))
        //                        .ToList;




        //            "//            var stats = sumDBContext.SpGetDashboardValues.ToList


        //var daystats = sumDBContext.SpGetDashboardValues
        //    .FromSql($"EXECUTE dbo.SpGetDashboardValues {WebUserID} , @CustomerID,@StartDate,@EndDate,@Stores,@Groups,@StartOfWeekDay,@ActiveOnly\"")
        //    .ToList();

        //public void MyStoredProc(int inputValue, out decimal outputValue1, out decimal outputValue2)
        //  {
        //            var parameters = new[] {
        //    new SqlParameter("@0", inputValue),
        //    new SqlParameter("@1", SqlDbType.Decimal) { Direction = ParameterDirection.Output },
        //    new SqlParameter("@2", SqlDbType.Decimal) { Direction = ParameterDirection.Output }
        //};

        //            context.ExecuteStoreCommand("exec MyStoredProc @InParamName=@0, @OutParamName1=@1 output, @OutParamName2=@2 output", parameters);

        //            outputValue1 = (decimal)parameters[1].Value;
        //            outputValue2 = (decimal)parameters[2].Value;
        //        }




    }
}