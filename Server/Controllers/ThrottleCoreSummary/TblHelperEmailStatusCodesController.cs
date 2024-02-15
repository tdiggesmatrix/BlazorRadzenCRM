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
    [Route("odata/Throttle_Core_Summary/TblHelperEmailStatusCodes")]
    public partial class TblHelperEmailStatusCodesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblHelperEmailStatusCodesController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> GetTblHelperEmailStatusCodes()
        {
            var items = this.context.TblHelperEmailStatusCodes.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode>();
            this.OnTblHelperEmailStatusCodesRead(ref items);

            return items;
        }

        partial void OnTblHelperEmailStatusCodesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> items);

        partial void OnTblHelperEmailStatusCodeGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblHelperEmailStatusCodes(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> GetTblHelperEmailStatusCode(int key)
        {
            var items = this.context.TblHelperEmailStatusCodes.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblHelperEmailStatusCodeGet(ref result);

            return result;
        }
        partial void OnTblHelperEmailStatusCodeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);
        partial void OnAfterTblHelperEmailStatusCodeDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblHelperEmailStatusCodes(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblHelperEmailStatusCode(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblHelperEmailStatusCodes
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblHelperEmailStatusCodeDeleted(item);
                this.context.TblHelperEmailStatusCodes.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblHelperEmailStatusCodeDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperEmailStatusCodeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);
        partial void OnAfterTblHelperEmailStatusCodeUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);

        [HttpPut("/odata/Throttle_Core_Summary/TblHelperEmailStatusCodes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblHelperEmailStatusCode(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item)
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
                this.OnTblHelperEmailStatusCodeUpdated(item);
                this.context.TblHelperEmailStatusCodes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperEmailStatusCodes.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblHelperEmailStatusCodeUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblHelperEmailStatusCodes(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblHelperEmailStatusCode(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblHelperEmailStatusCodes.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblHelperEmailStatusCodeUpdated(item);
                this.context.TblHelperEmailStatusCodes.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperEmailStatusCodes.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperEmailStatusCodeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);
        partial void OnAfterTblHelperEmailStatusCodeCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperEmailStatusCode item)
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

                this.OnTblHelperEmailStatusCodeCreated(item);
                this.context.TblHelperEmailStatusCodes.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperEmailStatusCodes.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblHelperEmailStatusCodeCreated(item);

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
