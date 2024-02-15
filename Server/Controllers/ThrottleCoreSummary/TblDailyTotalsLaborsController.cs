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
    [Route("odata/Throttle_Core_Summary/TblDailyTotalsLabors")]
    public partial class TblDailyTotalsLaborsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblDailyTotalsLaborsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor> GetTblDailyTotalsLabors()
        {
            var items = this.context.TblDailyTotalsLabors.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor>();
            this.OnTblDailyTotalsLaborsRead(ref items);

            return items;
        }

        partial void OnTblDailyTotalsLaborsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsLabor> items);
    }
}
