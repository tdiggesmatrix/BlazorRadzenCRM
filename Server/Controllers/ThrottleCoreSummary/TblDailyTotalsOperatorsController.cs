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
    [Route("odata/Throttle_Core_Summary/TblDailyTotalsOperators")]
    public partial class TblDailyTotalsOperatorsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblDailyTotalsOperatorsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> GetTblDailyTotalsOperators()
        {
            var items = this.context.TblDailyTotalsOperators.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator>();
            this.OnTblDailyTotalsOperatorsRead(ref items);

            return items;
        }

        partial void OnTblDailyTotalsOperatorsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> items);

        partial void OnTblDailyTotalsOperatorGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblDailyTotalsOperators(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> GetTblDailyTotalsOperator(long key)
        {
            var items = this.context.TblDailyTotalsOperators.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblDailyTotalsOperatorGet(ref result);

            return result;
        }
        partial void OnTblDailyTotalsOperatorDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);
        partial void OnAfterTblDailyTotalsOperatorDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblDailyTotalsOperators(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblDailyTotalsOperator(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblDailyTotalsOperators
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblDailyTotalsOperatorDeleted(item);
                this.context.TblDailyTotalsOperators.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblDailyTotalsOperatorDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDailyTotalsOperatorUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);
        partial void OnAfterTblDailyTotalsOperatorUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);

        [HttpPut("/odata/Throttle_Core_Summary/TblDailyTotalsOperators(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblDailyTotalsOperator(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item)
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
                this.OnTblDailyTotalsOperatorUpdated(item);
                this.context.TblDailyTotalsOperators.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotalsOperators.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblDailyTotalsOperatorUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblDailyTotalsOperators(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblDailyTotalsOperator(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblDailyTotalsOperators.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblDailyTotalsOperatorUpdated(item);
                this.context.TblDailyTotalsOperators.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotalsOperators.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblDailyTotalsOperatorCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);
        partial void OnAfterTblDailyTotalsOperatorCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblDailyTotalsOperator item)
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

                this.OnTblDailyTotalsOperatorCreated(item);
                this.context.TblDailyTotalsOperators.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblDailyTotalsOperators.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblDailyTotalsOperatorCreated(item);

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
