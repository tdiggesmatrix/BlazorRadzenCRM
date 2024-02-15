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
    [Route("odata/Throttle_Core_Activity/TblMessageDirections")]
    public partial class TblMessageDirectionsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageDirectionsController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> GetTblMessageDirections()
        {
            var items = this.context.TblMessageDirections.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection>();
            this.OnTblMessageDirectionsRead(ref items);

            return items;
        }

        partial void OnTblMessageDirectionsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> items);

        partial void OnTblMessageDirectionGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageDirections(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> GetTblMessageDirection(int key)
        {
            var items = this.context.TblMessageDirections.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageDirectionGet(ref result);

            return result;
        }
        partial void OnTblMessageDirectionDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);
        partial void OnAfterTblMessageDirectionDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageDirections(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageDirection(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageDirections
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageDirectionDeleted(item);
                this.context.TblMessageDirections.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageDirectionDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageDirectionUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);
        partial void OnAfterTblMessageDirectionUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageDirections(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageDirection(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item)
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
                this.OnTblMessageDirectionUpdated(item);
                this.context.TblMessageDirections.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageDirections.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageDirectionUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageDirections(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageDirection(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageDirections.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageDirectionUpdated(item);
                this.context.TblMessageDirections.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageDirections.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageDirectionCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);
        partial void OnAfterTblMessageDirectionCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageDirection item)
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

                this.OnTblMessageDirectionCreated(item);
                this.context.TblMessageDirections.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageDirections.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageDirectionCreated(item);

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
