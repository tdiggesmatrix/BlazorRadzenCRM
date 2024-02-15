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
    [Route("odata/Throttle_Core_Activity/TblDataDmSFileActivities")]
    public partial class TblDataDmSFileActivitiesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblDataDmSFileActivitiesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> GetTblDataDmSFileActivities()
        {
            var items = this.context.TblDataDmSFileActivities.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity>();
            this.OnTblDataDmSFileActivitiesRead(ref items);

            return items;
        }

        partial void OnTblDataDmSFileActivitiesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> items);

        partial void OnTblDataDmSFileActivityGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblDataDmSFileActivities(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> GetTblDataDmSFileActivity(int key)
        {
            var items = this.context.TblDataDmSFileActivities.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDataDmSFileActivityGet(ref result);

            return result;
        }
        partial void OnTblDataDmSFileActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);
        partial void OnAfterTblDataDmSFileActivityDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblDataDmSFileActivities(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDataDmSFileActivity(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDataDmSFileActivities
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDataDmSFileActivityDeleted(item);
                this.context.TblDataDmSFileActivities.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDataDmSFileActivityDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSFileActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);
        partial void OnAfterTblDataDmSFileActivityUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);

        [HttpPut("/odata/Throttle_Core_Activity/TblDataDmSFileActivities(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDataDmSFileActivity(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item)
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
                this.OnTblDataDmSFileActivityUpdated(item);
                this.context.TblDataDmSFileActivities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileActivities.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDataDmSFileActivityUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblDataDmSFileActivities(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDataDmSFileActivity(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDataDmSFileActivities.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDataDmSFileActivityUpdated(item);
                this.context.TblDataDmSFileActivities.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileActivities.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDataDmSFileActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);
        partial void OnAfterTblDataDmSFileActivityCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblDataDmSFileActivity item)
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

                this.OnTblDataDmSFileActivityCreated(item);
                this.context.TblDataDmSFileActivities.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDataDmSFileActivities.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDataDmSFileActivityCreated(item);

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
