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
    public partial class UspDashboardGetStatisticsTopVehiclesServicedsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public UspDashboardGetStatisticsTopVehiclesServicedsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/Throttle_Core_Summary/UspDashboardGetStatisticsTopVehiclesServicedsFunc(WebUserID={WebUserID},CustomerID={CustomerID},Stores={Stores},Groups={Groups},StartDate={StartDate},EndDate={EndDate},OnlyActiveStores={OnlyActiveStores},ext_TopXNumberofVehicles={ext_TopXNumberofVehicles},ext_IncludeVehicleYear={ext_IncludeVehicleYear})")]
        public IActionResult UspDashboardGetStatisticsTopVehiclesServicedsFunc([FromODataUri] int? WebUserID, [FromODataUri] int? CustomerID, [FromODataUri] string Stores, [FromODataUri] string Groups, [FromODataUri] string StartDate, [FromODataUri] string EndDate, [FromODataUri] bool? OnlyActiveStores, [FromODataUri] int? ext_TopXNumberofVehicles, [FromODataUri] bool? ext_IncludeVehicleYear)
        {
            this.OnUspDashboardGetStatisticsTopVehiclesServicedsDefaultParams(ref WebUserID, ref CustomerID, ref Stores, ref Groups, ref StartDate, ref EndDate, ref OnlyActiveStores, ref ext_TopXNumberofVehicles, ref ext_IncludeVehicleYear);


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
              new SqlParameter("@ext_TopXNumberofVehicles", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = ext_TopXNumberofVehicles},
              new SqlParameter("@ext_IncludeVehicleYear", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ext_IncludeVehicleYear},

            };

            foreach(var _p in @params)
            {
                if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[uspDashboardGetStatisticsTopVehiclesServiced] @WebUserID, @CustomerID, @Stores, @Groups, @StartDate, @EndDate, @OnlyActiveStores, @ext_TopXNumberofVehicles, @ext_IncludeVehicleYear", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnUspDashboardGetStatisticsTopVehiclesServicedsInvoke(ref result);

            return Ok(result);
        }

        partial void OnUspDashboardGetStatisticsTopVehiclesServicedsDefaultParams(ref int? WebUserID, ref int? CustomerID, ref string Stores, ref string Groups, ref string StartDate, ref string EndDate, ref bool? OnlyActiveStores, ref int? ext_TopXNumberofVehicles, ref bool? ext_IncludeVehicleYear);
      partial void OnUspDashboardGetStatisticsTopVehiclesServicedsInvoke(ref int result);
    }
}
