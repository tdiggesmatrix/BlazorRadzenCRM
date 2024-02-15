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
    [Route("odata/Throttle_Core_Activity/TblMessageGroupingTerms")]
    public partial class TblMessageGroupingTermsController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context;

        public TblMessageGroupingTermsController(ThrottleCoreCRM.Server.Data.Throttle_Core_ActivityContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> GetTblMessageGroupingTerms()
        {
            var items = this.context.TblMessageGroupingTerms.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm>();
            this.OnTblMessageGroupingTermsRead(ref items);

            return items;
        }

        partial void OnTblMessageGroupingTermsRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> items);

        partial void OnTblMessageGroupingTermGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Activity/TblMessageGroupingTerms(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> GetTblMessageGroupingTerm(int key)
        {
            var items = this.context.TblMessageGroupingTerms.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblMessageGroupingTermGet(ref result);

            return result;
        }
        partial void OnTblMessageGroupingTermDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);
        partial void OnAfterTblMessageGroupingTermDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);

        [HttpDelete("/odata/Throttle_Core_Activity/TblMessageGroupingTerms(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblMessageGroupingTerm(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblMessageGroupingTerms
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblMessageGroupingTermDeleted(item);
                this.context.TblMessageGroupingTerms.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblMessageGroupingTermDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageGroupingTermUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);
        partial void OnAfterTblMessageGroupingTermUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);

        [HttpPut("/odata/Throttle_Core_Activity/TblMessageGroupingTerms(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblMessageGroupingTerm(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item)
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
                this.OnTblMessageGroupingTermUpdated(item);
                this.context.TblMessageGroupingTerms.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageGroupingTerms.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblMessageGroupingTermUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Activity/TblMessageGroupingTerms(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblMessageGroupingTerm(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblMessageGroupingTerms.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblMessageGroupingTermUpdated(item);
                this.context.TblMessageGroupingTerms.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageGroupingTerms.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblMessageGroupingTermCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);
        partial void OnAfterTblMessageGroupingTermCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Activity.TblMessageGroupingTerm item)
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

                this.OnTblMessageGroupingTermCreated(item);
                this.context.TblMessageGroupingTerms.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblMessageGroupingTerms.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblMessageGroupingTermCreated(item);

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
