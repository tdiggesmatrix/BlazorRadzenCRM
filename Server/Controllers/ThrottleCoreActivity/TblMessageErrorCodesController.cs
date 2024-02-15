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
    [Route("odata/Throttle_Core_Activity/TblMessageErrorCodes")]
    public partial class TblMessageErrorCodesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageErrorCodesController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> GetTblMessageErrorCodes()
        {
            var items = this.context.TblMessageErrorCodes.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode>();
            this.OnTblMessageErrorCodesRead(ref items);

            return items;
        }

        partial void OnTblMessageErrorCodesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> items);

        partial void OnTblMessageErrorCodeGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageErrorCodes(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> GetTblMessageErrorCode(int key)
        {
            var items = this.context.TblMessageErrorCodes.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageErrorCodeGet(ref result);

            return result;
        }
        partial void OnTblMessageErrorCodeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);
        partial void OnAfterTblMessageErrorCodeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageErrorCodes(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageErrorCode(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageErrorCodes
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageErrorCodeDeleted(item);
                this.context.TblMessageErrorCodes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageErrorCodeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageErrorCodeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);
        partial void OnAfterTblMessageErrorCodeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageErrorCodes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageErrorCode(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item)
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
                this.OnTblMessageErrorCodeUpdated(item);
                this.context.TblMessageErrorCodes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageErrorCodes.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageErrorCodeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageErrorCodes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageErrorCode(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageErrorCodes.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageErrorCodeUpdated(item);
                this.context.TblMessageErrorCodes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageErrorCodes.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageErrorCodeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);
        partial void OnAfterTblMessageErrorCodeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageErrorCode item)
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

                this.OnTblMessageErrorCodeCreated(item);
                this.context.TblMessageErrorCodes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageErrorCodes.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageErrorCodeCreated(item);

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
