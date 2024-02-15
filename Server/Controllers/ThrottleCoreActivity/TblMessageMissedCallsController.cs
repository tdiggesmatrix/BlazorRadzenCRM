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
    [Route("odata/Throttle_Core_Activity/TblMessageMissedCalls")]
    public partial class TblMessageMissedCallsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageMissedCallsController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> GetTblMessageMissedCalls()
        {
            var items = this.context.TblMessageMissedCalls.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall>();
            this.OnTblMessageMissedCallsRead(ref items);

            return items;
        }

        partial void OnTblMessageMissedCallsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> items);

        partial void OnTblMessageMissedCallGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageMissedCalls(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> GetTblMessageMissedCall(int key)
        {
            var items = this.context.TblMessageMissedCalls.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageMissedCallGet(ref result);

            return result;
        }
        partial void OnTblMessageMissedCallDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);
        partial void OnAfterTblMessageMissedCallDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageMissedCalls(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageMissedCall(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageMissedCalls
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageMissedCallDeleted(item);
                this.context.TblMessageMissedCalls.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageMissedCallDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageMissedCallUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);
        partial void OnAfterTblMessageMissedCallUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageMissedCalls(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageMissedCall(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item)
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
                this.OnTblMessageMissedCallUpdated(item);
                this.context.TblMessageMissedCalls.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageMissedCalls.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageMissedCallUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageMissedCalls(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageMissedCall(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageMissedCalls.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageMissedCallUpdated(item);
                this.context.TblMessageMissedCalls.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageMissedCalls.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageMissedCallCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);
        partial void OnAfterTblMessageMissedCallCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageMissedCall item)
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

                this.OnTblMessageMissedCallCreated(item);
                this.context.TblMessageMissedCalls.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageMissedCalls.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageMissedCallCreated(item);

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
