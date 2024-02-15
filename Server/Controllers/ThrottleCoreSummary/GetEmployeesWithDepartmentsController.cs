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
    public partial class GetEmployeesWithDepartmentsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public GetEmployeesWithDepartmentsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("odata/Throttle_Core_Summary/GetEmployeesWithDepartmentsFunc(id={id})")]
        public IActionResult GetEmployeesWithDepartmentsFunc([FromODataUri] int? id)
        {
            this.OnGetEmployeesWithDepartmentsDefaultParams(ref id);


            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@id", SqlDbType.Int, -1) {Direction = ParameterDirection.Input, Value = id},

            };

            foreach(var _p in @params)
            {
                if((_p.Direction == ParameterDirection.Input || _p.Direction == ParameterDirection.InputOutput) && _p.Value == null)
                {
                    _p.Value = DBNull.Value;
                }
            }

            this.context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[GetEmployeesWithDepartment] @id", @params);

            int result = Convert.ToInt32(@params[0].Value);

            this.OnGetEmployeesWithDepartmentsInvoke(ref result);

            return Ok(result);
        }

        partial void OnGetEmployeesWithDepartmentsDefaultParams(ref int? id);
      partial void OnGetEmployeesWithDepartmentsInvoke(ref int result);
    }
}
