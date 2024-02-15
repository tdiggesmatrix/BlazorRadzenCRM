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
    [Route("odata/Throttle_Core_Activity/TblDataDmSFtPActivities")]
    public partial class TblDataDmSFtPActivitiesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataDmSFtPActivitiesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> GetTblDataDmSFtPActivities()
        {
            var items = this.context.TblDataDmSFtPActivities.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity>();
            this.OnTblDataDmSFtPActivitiesRead(ref items);

            return items;
        }

        partial void OnTblDataDmSFtPActivitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> items);

        partial void OnTblDataDmSFtPActivityGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataDmSFtPActivities(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> GetTblDataDmSFtPActivity(int key)
        {
            var items = this.context.TblDataDmSFtPActivities.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataDmSFtPActivityGet(ref result);

            return result;
        }
        partial void OnTblDataDmSFtPActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);
        partial void OnAfterTblDataDmSFtPActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataDmSFtPActivities(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataDmSFtPActivity(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataDmSFtPActivities
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataDmSFtPActivityDeleted(item);
                this.context.TblDataDmSFtPActivities.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataDmSFtPActivityDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSFtPActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);
        partial void OnAfterTblDataDmSFtPActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataDmSFtPActivities(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataDmSFtPActivity(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item)
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
                this.OnTblDataDmSFtPActivityUpdated(item);
                this.context.TblDataDmSFtPActivities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFtPActivities.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataDmSFtPActivityUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataDmSFtPActivities(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataDmSFtPActivity(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataDmSFtPActivities.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataDmSFtPActivityUpdated(item);
                this.context.TblDataDmSFtPActivities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFtPActivities.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSFtPActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);
        partial void OnAfterTblDataDmSFtPActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFtPActivity item)
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

                this.OnTblDataDmSFtPActivityCreated(item);
                this.context.TblDataDmSFtPActivities.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFtPActivities.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataDmSFtPActivityCreated(item);

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
