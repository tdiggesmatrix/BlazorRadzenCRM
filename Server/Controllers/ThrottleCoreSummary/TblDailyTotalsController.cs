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
    [Route("odata/Throttle_Core_Summary/TblDailyTotals")]
    public partial class TblDailyTotalsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblDailyTotalsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> GetTblDailyTotals()
        {
            var items = this.context.TblDailyTotals.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal>();
            this.OnTblDailyTotalsRead(ref items);

            return items;
        }

        partial void OnTblDailyTotalsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> items);

        partial void OnTblDailyTotalGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblDailyTotals(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> GetTblDailyTotal(long key)
        {
            var items = this.context.TblDailyTotals.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDailyTotalGet(ref result);

            return result;
        }
        partial void OnTblDailyTotalDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);
        partial void OnAfterTblDailyTotalDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblDailyTotals(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDailyTotal(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDailyTotals
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDailyTotalDeleted(item);
                this.context.TblDailyTotals.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDailyTotalDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDailyTotalUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);
        partial void OnAfterTblDailyTotalUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);

        [HttpPut("/odata/Throttle_Core_Summary/TblDailyTotals(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDailyTotal(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.fldRecordID != key))
                {
                    return BadRequest();
                }
                this.OnTblDailyTotalUpdated(item);
                this.context.TblDailyTotals.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotals.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDailyTotalUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblDailyTotals(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDailyTotal(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDailyTotals.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDailyTotalUpdated(item);
                this.context.TblDailyTotals.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotals.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDailyTotalCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);
        partial void OnAfterTblDailyTotalCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotal item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnTblDailyTotalCreated(item);
                this.context.TblDailyTotals.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotals.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDailyTotalCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
