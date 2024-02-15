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
    public partial class GetDashboardValuesOriginalsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public GetDashboardValuesOriginalsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/Throttle_Core_Summary/GetDashboardValuesOriginalsFunc(WebUserID={WebUserID},CustomerID={CustomerID},StartDate={StartDate},EndDate={EndDate},Stores={Stores},Groups={Groups},StartOfWeekDay={StartOfWeekDay},ActiveOnly={ActiveOnly})")]
        public IActionResult GetDashboardValuesOriginalsFunc([FromODataUri] int? WebUserID, [FromODataUri] int? CustomerID, [FromODataUri] string StartDate, [FromODataUri] string EndDate, [FromODataUri] string Stores, [FromODataUri] string Groups, [FromODataUri] int? StartOfWeekDay, [FromODataUri] bool? ActiveOnly)
        {
            this.OnGetDashboardValuesOriginalsDefaultParams(ref WebUserID, ref CustomerID, ref StartDate, ref EndDate, ref Stores, ref Groups, ref StartOfWeekDay, ref ActiveOnly);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@WebUserID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = WebUserID},
              new SqlParameter("@CustomerID", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = CustomerID},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@Stores", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Stores},
              new SqlParameter("@Groups", SqlDbType.VarChar, -1) {Direction = ParameterDirection.Input, Value = Groups},
              new SqlParameter("@StartOfWeekDay", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = StartOfWeekDay},
              new SqlParameter("@ActiveOnly", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ActiveOnly},

            };

            foreach(var _p in @params)
            {
                if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[GetDashboardValuesOriginal] @WebUserID, @CustomerID, @StartDate, @EndDate, @Stores, @Groups, @StartOfWeekDay, @ActiveOnly", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnGetDashboardValuesOriginalsInvoke(ref result);

            return Ok(result);
        }

        partial void OnGetDashboardValuesOriginalsDefaultParams(ref int? WebUserID, ref int? CustomerID, ref string StartDate, ref string EndDate, ref string Stores, ref string Groups, ref int? StartOfWeekDay, ref bool? ActiveOnly);
      partial void OnGetDashboardValuesOriginalsInvoke(ref int result);
    }
}
