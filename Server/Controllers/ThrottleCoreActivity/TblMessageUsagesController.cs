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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Activity
{
    [Route("odata/Throttle_Core_Activity/TblMessageUsages")]
    public partial class TblMessageUsagesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageUsagesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> GetTblMessageUsages()
        {
            var items = this.context.TblMessageUsages.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage>();
            this.OnTblMessageUsagesRead(ref items);

            return items;
        }

        partial void OnTblMessageUsagesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> items);

        partial void OnTblMessageUsageGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageUsages(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> GetTblMessageUsage(long key)
        {
            var items = this.context.TblMessageUsages.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageUsageGet(ref result);

            return result;
        }
        partial void OnTblMessageUsageDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);
        partial void OnAfterTblMessageUsageDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageUsages(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageUsage(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageUsages
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageUsageDeleted(item);
                this.context.TblMessageUsages.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageUsageDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageUsageUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);
        partial void OnAfterTblMessageUsageUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageUsages(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageUsage(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item)
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
                this.OnTblMessageUsageUpdated(item);
                this.context.TblMessageUsages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageUsages.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageUsageUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageUsages(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageUsage(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageUsages.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageUsageUpdated(item);
                this.context.TblMessageUsages.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageUsages.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageUsageCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);
        partial void OnAfterTblMessageUsageCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageUsage item)
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

                this.OnTblMessageUsageCreated(item);
                this.context.TblMessageUsages.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageUsages.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageUsageCreated(item);

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
