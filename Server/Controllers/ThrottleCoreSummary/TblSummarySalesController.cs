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
    [Route("odata/Throttle_Core_Summary/TblSummarySales")]
    public partial class TblSummarySalesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblSummarySalesController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> GetTblSummarySales()
        {
            var items = this.context.TblSummarySales.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale>();
            this.OnTblSummarySalesRead(ref items);

            return items;
        }

        partial void OnTblSummarySalesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> items);

        partial void OnTblSummarySaleGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblSummarySales(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> GetTblSummarySale(int key)
        {
            var items = this.context.TblSummarySales.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblSummarySaleGet(ref result);

            return result;
        }
        partial void OnTblSummarySaleDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);
        partial void OnAfterTblSummarySaleDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblSummarySales(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblSummarySale(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblSummarySales
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblSummarySaleDeleted(item);
                this.context.TblSummarySales.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblSummarySaleDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblSummarySaleUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);
        partial void OnAfterTblSummarySaleUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);

        [HttpPut("/odata/Throttle_Core_Summary/TblSummarySales(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblSummarySale(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item)
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
                this.OnTblSummarySaleUpdated(item);
                this.context.TblSummarySales.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummarySales.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblSummarySaleUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblSummarySales(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblSummarySale(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblSummarySales.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblSummarySaleUpdated(item);
                this.context.TblSummarySales.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummarySales.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblSummarySaleCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);
        partial void OnAfterTblSummarySaleCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblSummarySale item)
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

                this.OnTblSummarySaleCreated(item);
                this.context.TblSummarySales.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblSummarySales.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblSummarySaleCreated(item);

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
