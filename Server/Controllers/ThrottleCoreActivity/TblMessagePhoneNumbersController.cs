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
    [Route("odata/Throttle_Core_Activity/TblMessagePhoneNumbers")]
    public partial class TblMessagePhoneNumbersController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessagePhoneNumbersController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> GetTblMessagePhoneNumbers()
        {
            var items = this.context.TblMessagePhoneNumbers.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber>();
            this.OnTblMessagePhoneNumbersRead(ref items);

            return items;
        }

        partial void OnTblMessagePhoneNumbersRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> items);

        partial void OnTblMessagePhoneNumberGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessagePhoneNumbers(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> GetTblMessagePhoneNumber(long key)
        {
            var items = this.context.TblMessagePhoneNumbers.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessagePhoneNumberGet(ref result);

            return result;
        }
        partial void OnTblMessagePhoneNumberDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);
        partial void OnAfterTblMessagePhoneNumberDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessagePhoneNumbers(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessagePhoneNumber(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessagePhoneNumbers
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessagePhoneNumberDeleted(item);
                this.context.TblMessagePhoneNumbers.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessagePhoneNumberDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessagePhoneNumberUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);
        partial void OnAfterTblMessagePhoneNumberUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessagePhoneNumbers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessagePhoneNumber(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item)
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
                this.OnTblMessagePhoneNumberUpdated(item);
                this.context.TblMessagePhoneNumbers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessagePhoneNumbers.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessagePhoneNumberUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessagePhoneNumbers(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessagePhoneNumber(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessagePhoneNumbers.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessagePhoneNumberUpdated(item);
                this.context.TblMessagePhoneNumbers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessagePhoneNumbers.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessagePhoneNumberCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);
        partial void OnAfterTblMessagePhoneNumberCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessagePhoneNumber item)
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

                this.OnTblMessagePhoneNumberCreated(item);
                this.context.TblMessagePhoneNumbers.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessagePhoneNumbers.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessagePhoneNumberCreated(item);

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
