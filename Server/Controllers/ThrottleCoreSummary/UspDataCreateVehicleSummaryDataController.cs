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
    public partial class UspDataCreateVehicleSummaryDataController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public UspDataCreateVehicleSummaryDataController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/Throttle_Core_Summary/UspDataCreateVehicleSummaryDataFunc()")]
        public IActionResult UspDataCreateVehicleSummaryDataFunc()
        {
            this.OnUspDataCreateVehicleSummaryDataDefaultParams();


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

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[uspDataCreateVehicleSummaryData] ", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnUspDataCreateVehicleSummaryDataInvoke(ref result);

            return Ok(result);
        }

        partial void OnUspDataCreateVehicleSummaryDataDefaultParams();
      partial void OnUspDataCreateVehicleSummaryDataInvoke(ref int result);
    }
}
