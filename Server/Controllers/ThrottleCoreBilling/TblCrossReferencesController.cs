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

namespace ThrottleCoreCRM.Server.Controllers.Throttle_Core_Billing
{
    [Route("odata/Throttle_Core_Billing/TblCrossReferences")]
    public partial class TblCrossReferencesController : ODataController
    {
        private ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context;

        public TblCrossReferencesController(ThrottleCoreCRM.Server.Data.Throttle_Core_BillingContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> GetTblCrossReferences()
        {
            var items = this.context.TblCrossReferences.AsQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference>();
            this.OnTblCrossReferencesRead(ref items);

            return items;
        }

        partial void OnTblCrossReferencesRead(ref IQueryable<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> items);

        partial void OnTblCrossReferenceGet(ref SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Throttle_Core_Billing/TblCrossReferences(fldRecordID={fldRecordID})")]
        public SingleResult<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> GetTblCrossReference(int key)
        {
            var items = this.context.TblCrossReferences.Where(i => i.fldRecordID == key);
            var result = SingleResult.Create(items);

            OnTblCrossReferenceGet(ref result);

            return result;
        }
        partial void OnTblCrossReferenceDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);
        partial void OnAfterTblCrossReferenceDeleted(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);

        [HttpDelete("/odata/Throttle_Core_Billing/TblCrossReferences(fldRecordID={fldRecordID})")]
        public IActionResult DeleteTblCrossReference(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.TblCrossReferences
                    .Where(i => i.fldRecordID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnTblCrossReferenceDeleted(item);
                this.context.TblCrossReferences.Remove(item);
                this.context.SaveChanges();
                this.OnAfterTblCrossReferenceDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCrossReferenceUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);
        partial void OnAfterTblCrossReferenceUpdated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);

        [HttpPut("/odata/Throttle_Core_Billing/TblCrossReferences(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutTblCrossReference(int key, [FromBody]ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item)
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
                this.OnTblCrossReferenceUpdated(item);
                this.context.TblCrossReferences.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCrossReferences.Where(i => i.fldRecordID == key);
                
                this.OnAfterTblCrossReferenceUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Throttle_Core_Billing/TblCrossReferences(fldRecordID={fldRecordID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchTblCrossReference(int key, [FromBody]Delta<ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.TblCrossReferences.Where(i => i.fldRecordID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnTblCrossReferenceUpdated(item);
                this.context.TblCrossReferences.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCrossReferences.Where(i => i.fldRecordID == key);
                
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnTblCrossReferenceCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);
        partial void OnAfterTblCrossReferenceCreated(ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ThrottleCoreCRM.Server.Models.Throttle_Core_Billing.TblCrossReference item)
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

                this.OnTblCrossReferenceCreated(item);
                this.context.TblCrossReferences.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.TblCrossReferences.Where(i => i.fldRecordID == item.fldRecordID);

                

                this.OnAfterTblCrossReferenceCreated(item);

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
