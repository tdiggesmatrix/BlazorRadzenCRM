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
    [Route("odata/Throttle_Core_Activity/TblMessageCommDates")]
    public partial class TblMessageCommDatesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageCommDatesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> GetTblMessageCommDates()
        {
            var items = this.context.TblMessageCommDates.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate>();
            this.OnTblMessageCommDatesRead(ref items);

            return items;
        }

        partial void OnTblMessageCommDatesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> items);

        partial void OnTblMessageCommDateGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageCommDates(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> GetTblMessageCommDate(int key)
        {
            var items = this.context.TblMessageCommDates.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageCommDateGet(ref result);

            return result;
        }
        partial void OnTblMessageCommDateDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);
        partial void OnAfterTblMessageCommDateDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageCommDates(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageCommDate(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageCommDates
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageCommDateDeleted(item);
                this.context.TblMessageCommDates.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageCommDateDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageCommDateUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);
        partial void OnAfterTblMessageCommDateUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageCommDates(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageCommDate(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item)
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
                this.OnTblMessageCommDateUpdated(item);
                this.context.TblMessageCommDates.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageCommDates.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageCommDateUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageCommDates(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageCommDate(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageCommDates.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageCommDateUpdated(item);
                this.context.TblMessageCommDates.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageCommDates.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageCommDateCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);
        partial void OnAfterTblMessageCommDateCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageCommDate item)
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

                this.OnTblMessageCommDateCreated(item);
                this.context.TblMessageCommDates.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageCommDates.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageCommDateCreated(item);

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
