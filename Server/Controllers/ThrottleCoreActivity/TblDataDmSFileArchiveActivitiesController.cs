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
    [Route("odata/Throttle_Core_Activity/TblDataDmSFileArchiveActivities")]
    public partial class TblDataDmSFileArchiveActivitiesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataDmSFileArchiveActivitiesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> GetTblDataDmSFileArchiveActivities()
        {
            var items = this.context.TblDataDmSFileArchiveActivities.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity>();
            this.OnTblDataDmSFileArchiveActivitiesRead(ref items);

            return items;
        }

        partial void OnTblDataDmSFileArchiveActivitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> items);

        partial void OnTblDataDmSFileArchiveActivityGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataDmSFileArchiveActivities(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> GetTblDataDmSFileArchiveActivity(int key)
        {
            var items = this.context.TblDataDmSFileArchiveActivities.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataDmSFileArchiveActivityGet(ref result);

            return result;
        }
        partial void OnTblDataDmSFileArchiveActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);
        partial void OnAfterTblDataDmSFileArchiveActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataDmSFileArchiveActivities(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataDmSFileArchiveActivity(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataDmSFileArchiveActivities
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataDmSFileArchiveActivityDeleted(item);
                this.context.TblDataDmSFileArchiveActivities.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataDmSFileArchiveActivityDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSFileArchiveActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);
        partial void OnAfterTblDataDmSFileArchiveActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataDmSFileArchiveActivities(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataDmSFileArchiveActivity(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item)
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
                this.OnTblDataDmSFileArchiveActivityUpdated(item);
                this.context.TblDataDmSFileArchiveActivities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileArchiveActivities.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataDmSFileArchiveActivityUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataDmSFileArchiveActivities(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataDmSFileArchiveActivity(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataDmSFileArchiveActivities.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataDmSFileArchiveActivityUpdated(item);
                this.context.TblDataDmSFileArchiveActivities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileArchiveActivities.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSFileArchiveActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);
        partial void OnAfterTblDataDmSFileArchiveActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileArchiveActivity item)
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

                this.OnTblDataDmSFileArchiveActivityCreated(item);
                this.context.TblDataDmSFileArchiveActivities.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileArchiveActivities.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataDmSFileArchiveActivityCreated(item);

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
