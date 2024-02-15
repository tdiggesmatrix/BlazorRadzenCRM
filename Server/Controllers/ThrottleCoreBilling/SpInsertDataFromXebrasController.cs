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
    public partial class SpInsertDataFromXebrasController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public SpInsertDataFromXebrasController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/Throttle_Core_Billing/SpInsertDataFromXebrasFunc()")]
        public IActionResult SpInsertDataFromXebrasFunc()
        {
            this.OnSpInsertDataFromXebrasDefaultParams();


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},

            };

            foreach(var _p in @params)
            {
                if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_Insert_Data_From_Xebra] ", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnSpInsertDataFromXebrasInvoke(ref result);

            return Ok(result);
        }

        partial void OnSpInsertDataFromXebrasDefaultParams();
      partial void OnSpInsertDataFromXebrasInvoke(ref int result);
    }
}
