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
    [Route("odata/Throttle_Core_Summary/TblHelperParts")]
    public partial class TblHelperPartsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblHelperPartsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> GetTblHelperParts()
        {
            var items = this.context.TblHelperParts.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart>();
            this.OnTblHelperPartsRead(ref items);

            return items;
        }

        partial void OnTblHelperPartsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> items);

        partial void OnTblHelperPartGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblHelperParts(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> GetTblHelperPart(long key)
        {
            var items = this.context.TblHelperParts.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblHelperPartGet(ref result);

            return result;
        }
        partial void OnTblHelperPartDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);
        partial void OnAfterTblHelperPartDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblHelperParts(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblHelperPart(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblHelperParts
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblHelperPartDeleted(item);
                this.context.TblHelperParts.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblHelperPartDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperPartUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);
        partial void OnAfterTblHelperPartUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);

        [HttpPut("/odata/Throttle_Core_Summary/TblHelperParts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblHelperPart(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item)
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
                this.OnTblHelperPartUpdated(item);
                this.context.TblHelperParts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperParts.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblHelperPartUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblHelperParts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblHelperPart(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblHelperParts.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblHelperPartUpdated(item);
                this.context.TblHelperParts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperParts.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperPartCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);
        partial void OnAfterTblHelperPartCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperPart item)
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

                this.OnTblHelperPartCreated(item);
                this.context.TblHelperParts.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperParts.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblHelperPartCreated(item);

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
