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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Summary
{
    public partial class UspDashboardGetValuesSalesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public UspDashboardGetValuesSalesController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/Throttle_Core_Summary/UspDashboardGetValuesSalesFunc(WebUserID={WebUserID},CustomerID={CustomerID},Stores={Stores},Groups={Groups},StartDate={StartDate},EndDate={EndDate},OnlyActiveStores={OnlyActiveStores},ext_Daily={ext_Daily},ext_WTD={ext_WTD},ext_MTD={ext_MTD},ext_YTD={ext_YTD},ext_DOD={ext_DOD},ext_WOW={ext_WOW},ext_MOM={ext_MOM},ext_YOY={ext_YOY})")]
        public IActionResult UspDashboardGetValuesSalesFunc([FromODataUri] int? WebUserID, [FromODataUri] int? CustomerID, [FromODataUri] string Stores, [FromODataUri] string Groups, [FromODataUri] string StartDate, [FromODataUri] string EndDate, [FromODataUri] bool? OnlyActiveStores, [FromODataUri] bool? ext_Daily, [FromODataUri] bool? ext_WTD, [FromODataUri] bool? ext_MTD, [FromODataUri] bool? ext_YTD, [FromODataUri] bool? ext_DOD, [FromODataUri] bool? ext_WOW, [FromODataUri] bool? ext_MOM, [FromODataUri] bool? ext_YOY)
        {
            this.OnUspDashboardGetValuesSalesDefaultParams(ref WebUserID, ref CustomerID, ref Stores, ref Groups, ref StartDate, ref EndDate, ref OnlyActiveStores, ref ext_Daily, ref ext_WTD, ref ext_MTD, ref ext_YTD, ref ext_DOD, ref ext_WOW, ref ext_MOM, ref ext_YOY);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@WebUserID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = WebUserID},
              new SqlParameter("@CustomerID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = CustomerID},
              new SqlParameter("@Stores", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Stores},
              new SqlParameter("@Groups", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Groups},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@OnlyActiveStores", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = OnlyActiveStores},
              new SqlParameter("@ext_Daily", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_Daily},
              new SqlParameter("@ext_WTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_WTD},
              new SqlParameter("@ext_MTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_MTD},
              new SqlParameter("@ext_YTD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_YTD},
              new SqlParameter("@ext_DOD", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_DOD},
              new SqlParameter("@ext_WOW", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_WOW},
              new SqlParameter("@ext_MOM", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_MOM},
              new SqlParameter("@ext_YOY", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_YOY},

            };

            foreach(var _p in @params)
            {
                if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[uspDashboardGetValuesSales] @WebUserID, @CustomerID, @Stores, @Groups, @StartDate, @EndDate, @OnlyActiveStores, @ext_Daily, @ext_WTD, @ext_MTD, @ext_YTD, @ext_DOD, @ext_WOW, @ext_MOM, @ext_YOY", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnUspDashboardGetValuesSalesInvoke(ref result);

            return Ok(result);
        }

        partial void OnUspDashboardGetValuesSalesDefaultParams(ref int? WebUserID, ref int? CustomerID, ref string Stores, ref string Groups, ref string StartDate, ref string EndDate, ref bool? OnlyActiveStores, ref bool? ext_Daily, ref bool? ext_WTD, ref bool? ext_MTD, ref bool? ext_YTD, ref bool? ext_DOD, ref bool? ext_WOW, ref bool? ext_MOM, ref bool? ext_YOY);
      partial void OnUspDashboardGetValuesSalesInvoke(ref int result);
    }
}
