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
    [Route("odata/Throttle_Core_Activity/TblMessageActivities")]
    public partial class TblMessageActivitiesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageActivitiesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> GetTblMessageActivities()
        {
            var items = this.context.TblMessageActivities.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity>();
            this.OnTblMessageActivitiesRead(ref items);

            return items;
        }

        partial void OnTblMessageActivitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> items);

        partial void OnTblMessageActivityGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageActivities(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> GetTblMessageActivity(long key)
        {
            var items = this.context.TblMessageActivities.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageActivityGet(ref result);

            return result;
        }
        partial void OnTblMessageActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);
        partial void OnAfterTblMessageActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageActivities(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageActivity(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageActivities
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageActivityDeleted(item);
                this.context.TblMessageActivities.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageActivityDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);
        partial void OnAfterTblMessageActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageActivities(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageActivity(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item)
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
                this.OnTblMessageActivityUpdated(item);
                this.context.TblMessageActivities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageActivities.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageActivityUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageActivities(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageActivity(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageActivities.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageActivityUpdated(item);
                this.context.TblMessageActivities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageActivities.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);
        partial void OnAfterTblMessageActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageActivity item)
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

                this.OnTblMessageActivityCreated(item);
                this.context.TblMessageActivities.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageActivities.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageActivityCreated(item);

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
