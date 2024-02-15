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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Billing
{
    public partial class SpGetBillingDetailsByDateByAccountsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public SpGetBillingDetailsByDateByAccountsController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/Throttle_Core_Billing/SpGetBillingDetailsByDateByAccountsFunc(StartDate={StartDate},EndDate={EndDate},DealerCloud={DealerCloud},Brand={Brand},SubBrand={SubBrand},ForPublication={ForPublication},ShowZeroPriceTrans={ShowZeroPriceTrans},ShowDetails={ShowDetails},SaveDatatoTemporaryTable={SaveDatatoTemporaryTable})")]
        public IActionResult SpGetBillingDetailsByDateByAccountsFunc([FromODataUri] string StartDate, [FromODataUri] string EndDate, [FromODataUri] string DealerCloud, [FromODataUri] string Brand, [FromODataUri] string SubBrand, [FromODataUri] bool? ForPublication, [FromODataUri] bool? ShowZeroPriceTrans, [FromODataUri] bool? ShowDetails, [FromODataUri] bool? SaveDatatoTemporaryTable)
        {
            this.OnSpGetBillingDetailsByDateByAccountsDefaultParams(ref StartDate, ref EndDate, ref DealerCloud, ref Brand, ref SubBrand, ref ForPublication, ref ShowZeroPriceTrans, ref ShowDetails, ref SaveDatatoTemporaryTable);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@StartDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@EndDate", SqlDbType.DateTime, -1) {Direction = ParameterDirection.Input, Value = string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@DealerCloud", SqlDbType.VarChar, 11) {Direction = ParameterDirection.Input, Value = DealerCloud},
              new SqlParameter("@Brand", SqlDbType.VarChar, 10) {Direction = ParameterDirection.Input, Value = Brand},
              new SqlParameter("@SubBrand", SqlDbType.VarChar, 10) {Direction = ParameterDirection.Input, Value = SubBrand},
              new SqlParameter("@ForPublication", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ForPublication},
              new SqlParameter("@ShowZeroPriceTrans", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ShowZeroPriceTrans},
              new SqlParameter("@ShowDetails", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = ShowDetails},
              new SqlParameter("@SaveDatatoTemporaryTable", SqlDbType.Bit, -1) {Direction = ParameterDirection.Input, Value = SaveDatatoTemporaryTable},

            };

            foreach(var _p in @params)
            {
                if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_Get_Billing_Details_By_Date_By_Account] @StartDate, @EndDate, @DealerCloud, @Brand, @SubBrand, @ForPublication, @ShowZeroPriceTrans, @ShowDetails, @SaveDatatoTemporaryTable", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnSpGetBillingDetailsByDateByAccountsInvoke(ref result);

            return Ok(result);
        }

        partial void OnSpGetBillingDetailsByDateByAccountsDefaultParams(ref string StartDate, ref string EndDate, ref string DealerCloud, ref string Brand, ref string SubBrand, ref bool? ForPublication, ref bool? ShowZeroPriceTrans, ref bool? ShowDetails, ref bool? SaveDatatoTemporaryTable);
      partial void OnSpGetBillingDetailsByDateByAccountsInvoke(ref int result);
    }
}
