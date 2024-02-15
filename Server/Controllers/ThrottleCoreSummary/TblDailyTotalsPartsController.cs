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
    [Route("odata/Throttle_Core_Summary/TblDailyTotalsParts")]
    public partial class TblDailyTotalsPartsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblDailyTotalsPartsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> GetTblDailyTotalsParts()
        {
            var items = this.context.TblDailyTotalsParts.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart>();
            this.OnTblDailyTotalsPartsRead(ref items);

            return items;
        }

        partial void OnTblDailyTotalsPartsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> items);

        partial void OnTblDailyTotalsPartGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblDailyTotalsParts(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> GetTblDailyTotalsPart(long key)
        {
            var items = this.context.TblDailyTotalsParts.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDailyTotalsPartGet(ref result);

            return result;
        }
        partial void OnTblDailyTotalsPartDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);
        partial void OnAfterTblDailyTotalsPartDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblDailyTotalsParts(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDailyTotalsPart(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDailyTotalsParts
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDailyTotalsPartDeleted(item);
                this.context.TblDailyTotalsParts.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDailyTotalsPartDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDailyTotalsPartUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);
        partial void OnAfterTblDailyTotalsPartUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);

        [HttpPut("/odata/Throttle_Core_Summary/TblDailyTotalsParts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDailyTotalsPart(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item)
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
                this.OnTblDailyTotalsPartUpdated(item);
                this.context.TblDailyTotalsParts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotalsParts.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDailyTotalsPartUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblDailyTotalsParts(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDailyTotalsPart(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDailyTotalsParts.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDailyTotalsPartUpdated(item);
                this.context.TblDailyTotalsParts.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotalsParts.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDailyTotalsPartCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);
        partial void OnAfterTblDailyTotalsPartCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsPart item)
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

                this.OnTblDailyTotalsPartCreated(item);
                this.context.TblDailyTotalsParts.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotalsParts.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDailyTotalsPartCreated(item);

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
