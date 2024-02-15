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
    [Route("odata/Throttle_Core_Summary/TblHelperLabors")]
    public partial class TblHelperLaborsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context;

        public TblHelperLaborsController(ThrottleCoreCRM.Server.Data.Throttle_Core_SummaryContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> GetTblHelperLabors()
        {
            var items = this.context.TblHelperLabors.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor>();
            this.OnTblHelperLaborsRead(ref items);

            return items;
        }

        partial void OnTblHelperLaborsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> items);

        partial void OnTblHelperLaborGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Summary/TblHelperLabors(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> GetTblHelperLabor(long key)
        {
            var items = this.context.TblHelperLabors.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblHelperLaborGet(ref result);

            return result;
        }
        partial void OnTblHelperLaborDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);
        partial void OnAfterTblHelperLaborDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);

        [HttpDelete("/odata/Throttle_Core_Summary/TblHelperLabors(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblHelperLabor(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblHelperLabors
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblHelperLaborDeleted(item);
                this.context.TblHelperLabors.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblHelperLaborDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperLaborUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);
        partial void OnAfterTblHelperLaborUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);

        [HttpPut("/odata/Throttle_Core_Summary/TblHelperLabors(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblHelperLabor(long key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item)
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
                this.OnTblHelperLaborUpdated(item);
                this.context.TblHelperLabors.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperLabors.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblHelperLaborUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Summary/TblHelperLabors(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblHelperLabor(long key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblHelperLabors.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblHelperLaborUpdated(item);
                this.context.TblHelperLabors.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperLabors.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblHelperLaborCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);
        partial void OnAfterTblHelperLaborCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Summary.TblHelperLabor item)
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

                this.OnTblHelperLaborCreated(item);
                this.context.TblHelperLabors.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblHelperLabors.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblHelperLaborCreated(item);

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
